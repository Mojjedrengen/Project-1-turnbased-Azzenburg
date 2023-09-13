using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class JsonCreater : MonoBehaviour
{
    
    Skills skill = new Skills();
    Skills skill1 = new Skills();
    Role newRole = new Role();
    Items head = new Items();
    Character player = new Character();
    SkillIndex ind = new SkillIndex();
   

    // Start is called before the first frame update
    void Start()
    {


        skill.name = "Heal";
        skill.power = 40;
        skill.type = Skills.Tybe.LIFE;
        skill.target = Skills.Target.SELF;
        skill.description = "Blessing of life runs through your veins";

        skill1.name = "Fireball";
        skill1.power = 40;
        skill1.type = Skills.Tybe.FIRE;
        skill1.target = Skills.Target.ENEMY;
        skill1.description = "Burning hot ball of fire";

        newRole.name = "Warriorpriest";
        newRole.skills[0] = skill;
        newRole.skills[1] = skill1;
        newRole.description = "Kick ass for the lord";

        head.name = "Chainmail";
        head.tybe = Items.Tybe.HEAD;
        head.power = 15;
        head.skillSlot1 = skill;
        head.description = "Blessed mail of the maiden";

        player.name = "Sir Test";
        player.role = newRole;
        player.health = 50;
        player.armor = 0;
        player.gear[0] = head;

        List<string> temp = new List<string>();
        temp.Add("fireball");
        temp.Add("heal");
        temp.Add("Slap");
        temp.Add("Ice comet");
        ind.index = temp;



        string json = JsonUtility.ToJson(ind);
        Debug.Log(json);
        string path = "Assets/Resources/skillIndex.json";
        StreamWriter t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
