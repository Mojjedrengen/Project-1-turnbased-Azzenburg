using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHUD : MonoBehaviour
{
    public GameObject pop;

    private int maxHp;
    private int maxMp;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = charSheet.player.hp;
        maxMp = charSheet.player.mp;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("HP").GetComponent<TextMeshProUGUI>().text = charSheet.player.hp + "/" + maxHp;
        GameObject.Find("MP").GetComponent<TextMeshProUGUI>().text = charSheet.player.mp + "/" + maxMp;

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
