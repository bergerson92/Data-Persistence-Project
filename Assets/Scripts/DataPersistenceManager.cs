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

        data.BestScore = BestScore;

        // IF MainManager m_Points > BestScore
        // BestScoreName = PlayerName
        // save

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
            BestScoreTest.text = "Best Score: " + PlayerNameText.text + " " + BestScore;

        }
    }
}
