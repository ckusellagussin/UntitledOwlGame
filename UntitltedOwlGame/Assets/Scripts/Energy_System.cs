using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_System : MonoBehaviour
{
    
    public float startEnergy;
    public float maxEnergy = 100f;
    public float energyConsumeRate = 1f;

    public Text energyIndicatorText;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        //Fuel Cap
        if(startEnergy > maxEnergy)
        {
            startEnergy = maxEnergy;

            UpdateUI();
        }

        
    }

    public void reduceEnergy()
    {
        //Energy is depleted at a fixed rate

        startEnergy -= Time.deltaTime * energyConsumeRate;
        UpdateUI();

    }


    // Update is called once per frame
    void UpdateUI()
    {
       //Output energy reading to the ui in game
        energyIndicatorText.text = "Energy left: " + startEnergy.ToString("0") + "%";



        if (startEnergy <= 0)
        {
            startEnergy = 0;
            energyIndicatorText.text = "Out of Energy";


        }

    }

    //If Owl hits any object with these tags then recover energy at the chosen rate
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Nest"))
            {
            startEnergy += Time.deltaTime * 5f;

            if (startEnergy > maxEnergy)
            {
                startEnergy = maxEnergy;


            }

            UpdateUI();

             }


        if (other.CompareTag("Ground"))
        {
            startEnergy += Time.deltaTime * 0.5f;

            if (startEnergy > maxEnergy)
            {
                startEnergy = maxEnergy;


            }

            UpdateUI();

        }





    }



}
