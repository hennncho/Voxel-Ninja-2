using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndex;


    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }    

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }    
}
