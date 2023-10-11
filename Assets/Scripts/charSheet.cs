using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class charSheet : MonoBehaviour
{
    public static character player;
    public Image img;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI mp;
    public TextMeshProUGUI role;
    public TextMeshProUGUI bio;
    int charIndex = 0;
    public idex i;
    public static string charName;
    public CurrChar currchar;

    // Start is called before the first frame update
    void Start()
    {
        string charIndexPath = "Assets/Resources/index.json";
        StreamReader ir = new StreamReader(charIndexPath);
        string itemp = ir.ReadToEnd();
        ir.Close();
        i = JsonUtility.FromJson<idex>(itemp);
        info();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextChar() {
        if (charIndex < i.index.Length-1)
        {
            charIndex++;
        }
        else {
            charIndex = 0;
        }
        info();
    }
    public void prevChar() { 
        if(charIndex > 0)
        {
            charIndex--;
        } else
        {
            charIndex = i.index.Length-1;
        }
        info();
    }

    private void info() {
        string path = "Assets/Resources/" + i.index[charIndex] + ".json";
        StreamReader r = new StreamReader(path);
        string temp = r.ReadToEnd();
        r.Close();
        player = JsonUtility.FromJson<character>(temp);


        hp.text = "Hp : " + player.hp;
        mp.text = "Mp : " + player.mp;
        role.text = "School : " + player.role;
        bio.text = player.bio;
        img.sprite = (Sprite)Resources.Load(i.index[charIndex], typeof(Sprite));
        charName = i.index[charIndex];

        currchar.spellList[1] = player.spell;
        currchar.hp = player.hp;
        currchar.maxHp = player.hp;
        currchar.maxMp = player.mp;
        currchar.mp = player.mp;
        currchar.role = player.role.ToString();
        currchar.name = charName;
        currchar.pos = new Vector2(0.0f, 0.0f);
        currchar.coins = 10;
    }
}
