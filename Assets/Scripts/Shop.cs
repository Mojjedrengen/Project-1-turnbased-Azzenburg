using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPop;
    public bool shopBool = false;
    public CurrChar currPlayer;

    public idex i;
    public List<Spells> allSpells = new List<Spells>();
    private int spellLength = 0;

    public TextMeshProUGUI name;
    public TextMeshProUGUI type;
    public TextMeshProUGUI power;
    public TextMeshProUGUI manacost;
    public TextMeshProUGUI targeting;
    public TextMeshProUGUI cost;

    private int shopIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopPop.SetActive(true);
            shopBool = true;
            getSpells();
            info();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopPop.SetActive(false);
            shopBool = false;
        }
    }

    private void getSpells()
    {
        string charIndexPath = "Assets/Resources/Spells/index.json";
        StreamReader ir = new StreamReader(charIndexPath);
        string itemp = ir.ReadToEnd();
        ir.Close();
        i = JsonUtility.FromJson<idex>(itemp);

        for (int j = 0; j < i.index.Length; j++)
        {
            Spells tempSpell = new Spells();
            bool isOnSpellList = false;

            string path = "Assets/Resources/Spells/" + i.index[j] + ".json";
            StreamReader r = new StreamReader(path);
            string temp = r.ReadToEnd();
            r.Close();
            tempSpell = JsonUtility.FromJson<Spells>(temp);

            Debug.Log("CurrSpell: " + tempSpell.name);
            for (int index = 0; index > currPlayer.spellList.Length; index++)
            {
                Debug.Log("player: " + currPlayer.spellList[index].name);
                if (tempSpell.name == currPlayer.spellList[index].name)
                {
                    isOnSpellList = true;
                }
               
            }
            if (!isOnSpellList) 
            {
                allSpells.Add(tempSpell);
            }
            isOnSpellList = false;
        }
        Debug.Log(allSpells.Count);
    }
    public void nextItem()
    {
        if (shopBool == true)
        {
            if (shopIndex <= spellLength - 1)
            {
                shopIndex++;
            }
            else
            {
                shopIndex = 0;
            }
            info();
        }
    }

    public void prevItem()
    {
        if (shopBool == true)
        {
            if (shopIndex > 0)
            {
                shopIndex--;
            }
            else
            {
                shopIndex = spellLength - 1;
            }
            info();
        }
    }

    private void info()
    {
        int spellcost = allSpells[shopIndex].level * 50;

        name.text = allSpells[shopIndex].name.ToString();
        type.text = "Type: " + allSpells[shopIndex].type.ToString();
        power.text = "Power: " + allSpells[shopIndex].power.ToString();
        manacost.text = "Mana Cost: " + allSpells[shopIndex].manacost.ToString();
        targeting.text = "Targeting: " + allSpells[shopIndex].target.ToString();
        cost.text = "Cost: " + spellcost.ToString() + "gp";
    }

}
