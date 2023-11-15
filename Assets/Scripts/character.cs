using System;
[Serializable]

public class character
{
    public int hp;
    public int mp;
    public int hpGrowth;
    public int mpGrowth;
    public enum Role {Fire, Arcane, Necromancer, Saber, Alchemist, Tera};
    public Role role;
    public String bio;

    public Spells spell = new Spells();
}

[Serializable]
public class Spells
{ 
    public Spells(string _name, int _power, int _manacost, int _level, Type _type, Target _target, string _desc) 
    {
        name = _name;
        power = _power;
        manacost = _manacost;
        level = _level;
        type = _type;
        target = _target;
        description = _desc;
    }
    public Spells()
    {
        
    }
    public String name;
    public int power;
    public int manacost;
    public int level;
    public enum Type { FIRE, ARCANE, NECROTIC, PLASMA, POISON, EARTH };
    public Type type;
    public enum Target { SELF, ALLY, ENEMY, ALLENEMY, ALL };
    public Target target;
    public String description;
}
[Serializable]
public class Enemy
{
    public String name;
    public int power;
    public int hp;
    public int xp;
    public int coins;
}
