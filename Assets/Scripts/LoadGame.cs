using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public GameObject loadgamePanel;
    public GameObject mainPanel;
    private bool loadgamePanelOn = false;

    public TextMeshProUGUI[] name = new TextMeshProUGUI[3];

    public TextMeshProUGUI[] hp = new TextMeshProUGUI[3];

    public TextMeshProUGUI[] mp = new TextMeshProUGUI[3];

    public TextMeshProUGUI[] lastUsed = new TextMeshProUGUI[3];

    public Image[] img = new Image[3];   

    public CurrChar currChar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openLoad()
    {
        if (!loadgamePanelOn)
        {
            mainPanel.SetActive(false);
            loadgamePanel.SetActive(true);
            loadgamePanelOn = true;
            checkSaves();
        } else if (loadgamePanelOn)
        {
            mainPanel.SetActive(true);
            loadgamePanel.SetActive(false);
            loadgamePanelOn = false;
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
                StreamReader r = new StreamReader(path);
                string temp = r.ReadToEnd();
                r.Close();
                newtempChar = JsonUtility.FromJson<TempSaveChar>(temp);

                name[i].text = newtempChar.name;
                hp[i].text = newtempChar.hp+"/"+newtempChar.maxHp;
                mp[i].text = newtempChar.mp+"/"+newtempChar.maxMp;
                lastUsed[i].text = newtempChar.lastUsed;

                img[i].sprite = (Sprite)Resources.Load(newtempChar.name, typeof(Sprite));
                img[i].color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void loadthegame(int i)
    {
        if (loadgamePanelOn)
        {
            TempSaveChar tempChar = new TempSaveChar();
            string savepath = Path.Combine(Application.streamingAssetsPath, "savegames/savefile" + i + ".json");
            StreamReader r = new StreamReader(savepath);
            string temp = r.ReadToEnd();
            r.Close();
            tempChar = JsonUtility.FromJson<TempSaveChar>(temp);

            currChar.spellList = tempChar.spellList;
            currChar.hp = tempChar.hp;
            currChar.maxHp = tempChar.maxHp;
            currChar.mp = tempChar.mp;
            currChar.maxMp = tempChar.maxMp;
            currChar.xp = tempChar.xp;
            currChar.lvl = tempChar.lvl;
            currChar.role = tempChar.role;
            currChar.name = tempChar.name;
            currChar.pos = tempChar.pos;
            currChar.coins = tempChar.coins;
            currChar.lastUsed = tempChar.lastUsed;

            SceneManager.LoadScene(2);
        }
    }
}
