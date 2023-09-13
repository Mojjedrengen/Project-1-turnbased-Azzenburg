using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class loadUI : MonoBehaviour
{
    public static Character player;
    private TMP_Text test;
    private TMP_Text skill1;
    private TMP_Text b_skill1;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/player.json";
        StreamReader reader = new StreamReader(path);
        string f = reader.ReadToEnd();
        player = JsonUtility.FromJson<Character>(f);
        test = GameObject.FindGameObjectWithTag("test").GetComponent<TMP_Text>();
        skill1 = GameObject.FindGameObjectWithTag("skillSlot1").GetComponent<TMP_Text>();
        b_skill1 = GameObject.FindGameObjectWithTag("b_skillSlot1").GetComponentInChildren<TMP_Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(player.name);
        test.text = player.name;
        skill1.text = player.role.skills[0].name;
        b_skill1.text = ""+player.role.skills[0].target;
    }
}
