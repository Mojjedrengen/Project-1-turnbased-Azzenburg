using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppStart() {

        SceneManager.LoadScene(1);
    }

    public void AppQuit()
    {
        Application.Quit();

        Debug.Log("quiting"); 
    }
}
