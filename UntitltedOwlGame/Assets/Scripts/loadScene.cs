using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
  
    public void sceneloader(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex,LoadSceneMode.Single);
        Time.timeScale = 1;

      


    }


}
