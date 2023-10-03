using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]


public class CurrChar
{
    public List<Spells> spellList = new List<Spells>()
    {
        charSheet.player.spell
    };
    public int hp = charSheet.player.hp;
    public int maxHp = charSheet.player.hp;
    public int mp = charSheet.player.mp;
    public int maxMp = charSheet.player.mp;

    public string role = charSheet.player.role.ToString();

    public string name = charSheet.charName;
}

public class CurrEnemy
{
    public int hp = 50;
    public int maxHp = 50;
    public int dmg = 5;
}
