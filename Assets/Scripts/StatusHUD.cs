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

    public void SetStatusHUD(CharacterStatus status)
    {
        float currHealth = status.health;
        float maxHealth = status.maxHealth;
        float currMana = status.mana;
        float maxMana = status.maxMana;

       GameObject.Find("HP").GetComponent<TextMeshProUGUI>().text = currHealth + "/" + maxHealth;
       GameObject.Find("MP").GetComponent<TextMeshProUGUI>().text = currMana + "/" + maxMana;
    }

    public void SetHP(CharacterStatus status, float hp)
    {
        status.health -= hp;
        SetStatusHUD(status);
    }
}
