using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_Switch : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;


    }




}
