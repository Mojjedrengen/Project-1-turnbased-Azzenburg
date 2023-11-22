using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public CurrChar currPlayer;
    public GameObject popop;
    private bool popbool = false;

    public TextMeshProUGUI[] btn = new TextMeshProUGUI[3];
    //public TextMeshProUGUI btn2;
    //public TextMeshProUGUI btn3;

    private TempSaveChar tempChar;

    // Start is called before the first frame update
    void Start()
    {
        tempChar = new TempSaveChar(currPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            if (popbool)
            {
                popbool = false;
                popop.SetActive(false);
            } else if (!popbool)
            {
                popbool = true;
                popop.SetActive(true);
                checkSaves();
            }
            
        }   
    }

    public void savethegame(int i)
    {
        if (popbool)
        {
            tempChar = new TempSaveChar(currPlayer);

            string json = JsonUtility.ToJson(tempChar);
            Debug.Log(json);
            string path = Path.Combine(Application.streamingAssetsPath, "savegames/savefile"+i+".json");
            StreamWriter t = new StreamWriter(path, false);
            t.Write(json);
            t.Close();

            checkSaves();
        }
    }

    private void checkSaves()
    {
        for (int i = 0; i < 3; i++)
        {
            string path = Path.Combine(Application.streamingAssetsPath, "savegames/savefile" + i + ".json");
            if (File.Exists(path))
            {
                TempSaveChar newtempChar = new TempSaveChar();
                string savepath = Path.Combine(Application.streamingAssetsPath, "savegames/savefile" + i + ".json");
                StreamReader r = new StreamReader(path);
                string temp = r.ReadToEnd();
                r.Close();
                newtempChar = JsonUtility.FromJson<TempSaveChar>(temp);
                
                btn[i].text = newtempChar.lastUsed;

            } else if (!File.Exists(path))
            {
                btn[i].text = "not Used";
            }
        }
    }
}
