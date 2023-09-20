using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    public GameObject pop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            pop.SetActive(true);
        }
        if (Input.GetKeyDown("escape"))
        {
            pop.SetActive(false);
        }
    }
}
