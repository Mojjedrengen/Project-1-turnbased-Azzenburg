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

    public TextMeshProUGUI spell1;
    public TextMeshProUGUI spell2;
    public TextMeshProUGUI spell3;
    public TextMeshProUGUI spell4;

    public TextMeshProUGUI playerbalance;

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
        allSpells.Clear();
        string charIndexPath = Path.Combine(Application.streamingAssetsPath, "Spells/index.json");
        StreamReader ir = new StreamReader(charIndexPath);
        string itemp = ir.ReadToEnd();
        ir.Close();
        i = JsonUtility.FromJson<idex>(itemp);

        for (int j = 0; j < i.index.Length; j++)
        {
            Spells tempSpell = new Spells();
            bool isOnSpellList = false;

            string path = Path.Combine(Application.streamingAssetsPath, "Spells/" + i.index[j] + ".json");
            StreamReader r = new StreamReader(path);
            string temp = r.ReadToEnd();
            r.Close();
            tempSpell = JsonUtility.FromJson<Spells>(temp);

            Debug.Log("CurrSpell: " + tempSpell.name);
            Debug.Log(currPlayer.spellList.Count);
            Debug.Log("You have: " + currPlayer.spellList[0].name);

            for (int index = 0; index <= currPlayer.spellList.Count-1; index++)
            {
                Debug.Log("player: " + currPlayer.spellList[index].name);
                if (tempSpell.name == currPlayer.spellList[index].name)
                {
                    isOnSpellList = true;
                    Debug.Log(tempSpell.name);

                }
            }
            if (!isOnSpellList) 
            {
                allSpells.Add(tempSpell);
            }
            isOnSpellList = false;
        }
        Debug.Log(allSpells.Count);
        spellLength = allSpells.Count;
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
    public void btnSpell(int i)
    {
        if (shopBool == true)
        {
            if (currPlayer.coins >= allSpells[shopIndex].level * 50)
            {
                currPlayer.coins -= allSpells[shopIndex].level * 50;
                currPlayer.spellList[i] = allSpells[shopIndex];
                getSpells();
                info();
            }
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

        spell1.text = currPlayer.spellList[0].name;
        spell2.text = currPlayer.spellList[1].name;
        spell3.text = currPlayer.spellList[2].name;
        spell4.text = currPlayer.spellList[3].name;

        playerbalance.text = "Your balance: <br><size=+10>" + currPlayer.coins.ToString();
    }

}
