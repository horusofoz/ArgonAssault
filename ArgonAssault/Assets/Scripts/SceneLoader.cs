using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Invoke("LoadFirstScene", 2f);
    }

    // Load next scene
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    // Load same scene
    void LoadSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
