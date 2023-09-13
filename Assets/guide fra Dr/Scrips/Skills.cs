using System;
using System.Collections.Generic;

[Serializable]
public class Skills 
{
    public String name;
    public int power;
    public enum Tybe 
    {FIRE, POSION, PHYSICAL, ICE, LIFE };
    public Tybe type;   
    public enum Target 
    {SELF,OTHER,ENEMY, ALLENEMY, ALL };
    public Target target;
    public String description;
    

}

[Serializable]
public class Items 
{
    public String name;
    public enum Tybe 
    {WEAPON, OFFHAND, HEAD, CHEST, ARMS, LEGS};
    public Tybe tybe;
    public int power;
    public Skills skillSlot1;
   // public Skills skillSlot2;
    public String description;

}

[Serializable]
public class Role 
{
    public String name;
    public Skills[] skills = new Skills[2];
    public String description;
}


[Serializable]
public class Character
{
    public String name;
    public Role role;
    public int health;
    public int armor;
    public Items[] gear = new Items[6];
}

public class SkillIndex {

   public  List<string> index = new List<string>();

}

public class RoleIndex {
    public List<string> index = new List<string>();
}