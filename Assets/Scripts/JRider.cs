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
        player.hp = 100;
        player.mp = 100;
        player.hpGrowth = 8;
        player.mpGrowth = 8;
        player.role = character.Role.Fire;
        player.bio = "A firce fire Wizard";

        player.spell = new Spells("test", 10, 10, 1, Spells.Type.FIRE, Spells.Target.ALLENEMY, "A test spell");

        string json = JsonUtility.ToJson(player);
        Debug.Log(json);
        string path = "Assets/test.json";
        StreamWriter t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
