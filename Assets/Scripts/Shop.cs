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

    public idex i;
    public Spells[] allSpells;

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

        allSpells = new Spells[i.index.Length];

        for (int j = 0; j < allSpells.Length-1; j++)
        {
            string path = "Assets/Resources/Spells/" + i.index[j] + ".json";
            StreamReader r = new StreamReader(path);
            string temp = r.ReadToEnd();
            r.Close();
            allSpells[j] = JsonUtility.FromJson<Spells>(temp);


        }
    }
    public void nextItem()
    {
        if (shopBool == true)
        {
            if (shopIndex <= allSpells.Length - 1)
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
                shopIndex = allSpells.Length - 1;
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
