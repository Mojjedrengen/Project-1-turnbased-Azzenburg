using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using System;

public class SkillCreator : MonoBehaviour
{

    Skills newSkill = new Skills();
    public TMP_InputField Iname;
    public TMP_InputField Ipower;
    public TMP_Dropdown Itybe;
    public TMP_Dropdown Itarget;
    public TMP_InputField Idescription;
    public TMP_Dropdown Iskill;
    SkillIndex tempindex = new SkillIndex();

    // Start is called before the first frame update

    private void Start()
    {
        
        string path = "Assets/Resources/skillIndex.json";
        StreamReader reader = new StreamReader(path);
        string f = reader.ReadToEnd();
        tempindex = JsonUtility.FromJson<SkillIndex>(f);
        Iskill.ClearOptions();
        Iskill.AddOptions(tempindex.index);
        reader.Close();
        




        List<string> temp = new List<string>();
        Debug.Log(Skills.Tybe.GetValues(typeof(Skills.Target)).Length);
        for (int i = 0; i < Skills.Tybe.GetValues(typeof(Skills.Tybe)).Length; i++) {
            temp.Add(((Skills.Tybe)i).ToString());
        }
        Itybe.ClearOptions();
        Itybe.AddOptions(temp);
        temp = new List<string>();
        for (int i = 0; i < Skills.Target.GetValues(typeof(Skills.Target)).Length; i++)
        {
            temp.Add(((Skills.Target)i).ToString());
        }
        Itarget.ClearOptions();
        Itarget.AddOptions(temp);

      
    }


    public void CreateSkill()
    {
        newSkill.name = Iname.text;
        int.TryParse(Ipower.text, out newSkill.power);
        newSkill.type = (Skills.Tybe)Itybe.value;
        newSkill.target = (Skills.Target)Itarget.value;
        newSkill.description = Idescription.text;

        string json = JsonUtility.ToJson(newSkill);
        Debug.Log(json);
        string path = "Assets/Resources/"+Iname.text+".json";
        StreamWriter t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();
        tempindex.index.Add(Iname.text);
        json = JsonUtility.ToJson(tempindex);
        path = "Assets/Resources/skillIndex.json";
        t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();
        Iskill.ClearOptions();
        Iskill.AddOptions(tempindex.index);
    }

   
}
