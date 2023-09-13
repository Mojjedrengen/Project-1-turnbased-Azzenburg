using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Rolecreator : MonoBehaviour
{
    Role newClass = new Role();
    public TMP_InputField Iname;
    public TMP_Dropdown IAbility1;
    public TMP_Dropdown IAbility2;
    public TMP_InputField Idescription;
    public TMP_Dropdown IClass;
    SkillIndex tempindex = new SkillIndex();
    RoleIndex rIndex = new RoleIndex();
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/skillIndex.json";
        StreamReader reader = new StreamReader(path);
        string f = reader.ReadToEnd();
        tempindex = JsonUtility.FromJson<SkillIndex>(f);
        IAbility1.ClearOptions();
        IAbility1.AddOptions(tempindex.index);
        IAbility2.ClearOptions();
        IAbility2.AddOptions(tempindex.index);
        reader.Close();
        path = "Assets/Resources/roleIndex.json";
        reader = new StreamReader(path);
        f = reader.ReadToEnd();
        rIndex = JsonUtility.FromJson<RoleIndex>(f);
        IClass.ClearOptions();
        IClass.AddOptions(rIndex.index);
    }

    // Update is called once per frame
    public void createClass()
    {
        newClass.name = Iname.text;
        string path = "Assets/Resources/"+tempindex.index[IAbility1.value]+".json";
        StreamReader reader = new StreamReader(path);
        string f = reader.ReadToEnd();
        Skills tempA = JsonUtility.FromJson<Skills>(f);

        path = "Assets/Resources/" + tempindex.index[IAbility2.value] + ".json";
        reader = new StreamReader(path);
        f = reader.ReadToEnd();
        Skills tempB = JsonUtility.FromJson<Skills>(f);

        newClass.skills[0] = tempA;
        newClass.skills[1] = tempB;
        newClass.description = Idescription.text;

        string json = JsonUtility.ToJson(newClass);
        Debug.Log(json);
        path = "Assets/Resources/" + Iname.text + ".json";
        StreamWriter t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();
        rIndex.index.Add(Iname.text);
        json = JsonUtility.ToJson(rIndex);
        path = "Assets/Resources/roleIndex.json";
        t = new StreamWriter(path, false);
        t.Write(json);
        t.Close();
        IClass.ClearOptions();
        IClass.AddOptions(rIndex.index);
    }
}
