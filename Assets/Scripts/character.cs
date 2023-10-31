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

    public Spells spell;
}

public class Spells
{
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

public class Enemy
{
    public String name;
    public int power;
    public int hp;
    public int xp;
    public int coins;
}
