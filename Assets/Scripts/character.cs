using System;
[Serializable]

public class character
{
    public int hp;
    public int mp;
    public enum Role {Fire, Arcane, Necromancer, Saber, Alchemist, Tera};
    public Role role;
    public String bio;
}
