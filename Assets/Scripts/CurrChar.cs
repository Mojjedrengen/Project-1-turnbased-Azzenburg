using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using JetBrains.Annotations;

[Serializable]


[CreateAssetMenu(fileName = "CurrChar", menuName = "StatusObjects/player", order = 1)]
public class CurrChar : ScriptableObject
{
    /*
    public List<Spells> spellList = new List<Spells>()
    {
        charSheet.player.spell
    };*/
    public List<Spells> spellList = new List<Spells>();
    public int hp = 100;
    public int maxHp = 100;
    public int mp = 100;
    public int maxMp = 100;
    public int xp = 0;
    public int lvl = 1;

    public string role = "FIRE";

    public string name = "mojje";

    public Vector2 pos = new Vector2(0.0f, 0.0f);

    public int coins = 10;

    public string lastUsed = DateTime.Now.ToString("yyyy/MM/dd");


    /*public int hp = charSheet.player.hp;
    public int maxHp = charSheet.player.hp;
    public int mp = charSheet.player.mp;
    public int maxMp = charSheet.player.mp;

    public string role = charSheet.player.role.ToString();

    public string name = charSheet.charName;*/
}
[Serializable]
public class TempSaveChar
{
    public List<Spells> spellList;
    public int hp;
    public int maxHp;
    public int mp;
    public int maxMp;
    public int xp;
    public int lvl;

    public string role;
    public string name;
    public Vector2 pos;
    public int coins;
    public string lastUsed;

    public TempSaveChar(CurrChar _char)
    {
        spellList = _char.spellList;
        hp = _char.hp;
        maxHp = _char.maxHp;
        mp = _char.mp;
        maxMp = _char.maxMp;
        xp = _char.xp;
        lvl = _char.lvl;
        role = _char.role;
        name = _char.name;
        pos = _char.pos;
        coins = _char.coins;
        lastUsed = DateTime.Now.ToString("yyyy/MM/dd");
    }
    public TempSaveChar()
    {

    }
}

public class CurrEnemy
{
    public Enemy enemy;
    public String name;
    public int dmg;
    public int hp;
    public int maxHp;
    public int xp;
    public int coins;
    public CurrEnemy(String _name) 
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Enemies/" + _name + ".json");
        StreamReader r = new StreamReader(path);
        string temp = r.ReadToEnd();
        r.Close();
        enemy = JsonUtility.FromJson<Enemy>(temp);

        name = enemy.name;
        dmg = enemy.power;
        hp = enemy.hp;
        maxHp = enemy.hp;
        xp = enemy.xp;
        coins = enemy.coins;
    }
}
