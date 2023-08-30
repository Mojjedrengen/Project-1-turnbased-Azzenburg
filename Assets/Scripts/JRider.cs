using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JRider : MonoBehaviour
{

    public character player;
    // Start is called before the first frame update
    void Start()
    {
        player.bio = "A firce fire Wizard";
        player.hp = 100;
        player.mp = 90;
        player.role = character.Role.Fire;

        string json = JsonUtility.ToJson(player);
        Debug.Log(json);
        string path = "Assets/CharSellectAssets/mojje.json";
        StreamWriter t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
