using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public CurrChar currPlayer;
    public GameObject popop;
    private bool popbool = false;

    public TextMeshProUGUI btn1;
    public TextMeshProUGUI btn2;
    public TextMeshProUGUI btn3;

    // Start is called before the first frame update
    void Start()
    {
        
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
            string json = JsonUtility.ToJson(currPlayer);
            Debug.Log(json);
            string path = Path.Combine(Application.streamingAssetsPath, "savegames/savefile"+i+".json");
            StreamWriter t = new StreamWriter(path, false);
            t.Write(json);
            t.Close();
        }
    }

    private void checkSaves()
    {
        for (int i = 0; i < 3; i++)
        {
            string path = Path.Combine(Application.streamingAssetsPath, "savegames/savefile" + i + ".json");
            if (File.Exists(path))
            {
                CurrChar tempChar = new CurrChar();
                string savepath = Path.Combine(Application.streamingAssetsPath, "savegames/savefile" + i + ".json");
                StreamReader r = new StreamReader(path);
                string temp = r.ReadToEnd();
                r.Close();
                tempChar = JsonUtility.FromJson<CurrChar>(temp);

                if (i == 0) btn1.text = tempChar.lastUsed;
                if (i == 1) btn2.text = tempChar.lastUsed;
                if (i == 2) btn3.text = tempChar.lastUsed;
            } else if (!File.Exists(path))
            {
                if (i == 0) btn1.text = "not used";
                if (i == 1) btn2.text = "not used";
                if (i == 2) btn3.text = "not used";
            }
        }
    }
}
