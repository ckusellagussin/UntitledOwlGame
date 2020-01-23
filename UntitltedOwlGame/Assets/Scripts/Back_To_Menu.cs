using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_To_Menu : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {

        //Loads up the scene with mouse showing on menu and time is not paused
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Time.timeScale = 1f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }
                
                
                


        
    }
}
