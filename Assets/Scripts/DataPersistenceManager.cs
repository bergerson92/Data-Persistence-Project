using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{

    public TextMeshProUGUI NameText;
    public Text BestScoreTextMenu;
    public int BestScore;

    public string PlayerName;
    public string BestScoreName;
    private string input;
    public TextMeshProUGUI PlayerNameText;
    public TextMeshProUGUI BestScoreTest;

    public static DataPersistenceManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        LoadData();
    }

    [System.Serializable]

    class SaveName
    {
        public string PlayerName;
        public string BestScoreName;
        public TextMeshProUGUI PlayerNameText;
        //public Text BestScoreTextMenu;
        public TextMeshProUGUI BestScoreTest;

        public int BestScore;
    }

    public void ReadStringToInput(string s)
    {
        PlayerName = s;
        //Debug.Log(PlayerName);
    }

    public void SaveData()
    {
        SaveName data = new SaveName();
        data.PlayerName = PlayerName;

        //if (BestScore > data.BestScore)
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;

        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        switch (buildIndex)
        {
            case 0:
                PlayerNameText.text = PlayerName;
                break;

            case 1:
                //BestScoreTextMenu.text = "Best Score: " + PlayerNameText.text + " " + BestScore;
                break;
        }


        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveName data = JsonUtility.FromJson<SaveName>(json);

            PlayerName = data.PlayerName;
            PlayerNameText.text = PlayerName;

            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;

            BestScoreTest.text = "Score: " + BestScoreName + " " + BestScore;

        }
    }

    public void GetPlayerName()
    {
        GameObject canvasObject = GameObject.Find("Canvas");
        Debug.Log(canvasObject.name);

        GameObject firstChildObject = canvasObject.transform.GetChild(0).gameObject;
        Debug.Log("found gameobject");


        GameObject nestedChildObject = firstChildObject.transform.GetChild(0).gameObject;

        //int lastChildIndex = nestedChildObject.transform.childCount - 1;
        //GameObject lastChildObject = nestedChildObject.transform.GetChild(0).gameObject;
        GameObject placeholderObject = nestedChildObject.transform.Find("Placeholder").gameObject;

        PlayerNameText = placeholderObject.GetComponent<TextMeshProUGUI>();
        Debug.Log("Playername");

        if (PlayerNameText.text != null)
        {
            Debug.Log("TextMeshProUGUI text: " + PlayerNameText.text);
        }
        else
        {
            Debug.Log("TextMeshProUGUI component not found on the last child object.");
        }

        //PlayerNameText = textMeshProUGUI;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
