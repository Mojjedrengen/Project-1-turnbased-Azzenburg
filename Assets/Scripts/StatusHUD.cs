using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Help from https://pavcreations.com/turn-based-battle-and-transition-from-a-game-world-unity/
public class StatusHUD : MonoBehaviour
{
    public GameObject hpValue;
    public GameObject mpValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStatusHUD(CurrChar status)
    {
        int currHealth = status.hp;
        int maxHealth = status.maxHp;
        int currMana = status.mp;
        int maxMana = status.maxMp;

       GameObject.Find("HP").GetComponent<TextMeshProUGUI>().text = currHealth + "/" + maxHealth;
       GameObject.Find("MP").GetComponent<TextMeshProUGUI>().text = currMana + "/" + maxMana;
    }

    public void SetHP(CurrChar status, int hp)
    {
        status.hp -= hp;
        SetStatusHUD(status);
    }
    public void SetStatusHUDEnemy(CurrEnemy enemy)
    {
        int currHealth = enemy.hp;
        int maxHealth = enemy.maxHp;

        hpValue.GetComponent<TextMeshProUGUI>().text = currHealth + "/" + maxHealth;
    }
    public void SetEnemyHP(CurrEnemy enemy, int hp)
    {
        enemy.hp -= hp;
        SetStatusHUDEnemy(enemy);
    }
}
