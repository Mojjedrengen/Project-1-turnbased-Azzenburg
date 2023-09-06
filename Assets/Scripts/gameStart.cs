using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{

    public static int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppStart() {
        sceneIndex++;
        SceneManager.LoadScene(1);
    }

    public void AppQuit()
    {
        Application.Quit();

        Debug.Log("quiting"); 
    }
}
