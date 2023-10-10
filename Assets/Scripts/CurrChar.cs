using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]


[CreateAssetMenu(fileName = "CurrChar", menuName = "StatusObjects/player", order = 1)]
public class CurrChar : ScriptableObject
{
    /*
    public List<Spells> spellList = new List<Spells>()
    {
        charSheet.player.spell
    };*/
    public Spells[] spellList = new Spells[4];
    public int hp = 100;
    public int maxHp = 100;
    public int mp = 100;
    public int maxMp = 100;

    public string role = "FIRE";

    public string name = "mojje";

    public Vector2 pos = new Vector2(0.0f, 0.0f);


    /*public int hp = charSheet.player.hp;
    public int maxHp = charSheet.player.hp;
    public int mp = charSheet.player.mp;
    public int maxMp = charSheet.player.mp;

    public string role = charSheet.player.role.ToString();

    public string name = charSheet.charName;*/
}

public class CurrEnemy
{
    public int hp = 50;
    public int maxHp = 50;
    public int dmg = 5;
}
