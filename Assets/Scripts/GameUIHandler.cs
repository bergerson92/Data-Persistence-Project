using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameUIHandler : MonoBehaviour
{
    public MainManager MainManager;
    public GameObject BackButton;

    public void Start()
    {
        MainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public void Update()
    {
        if (MainManager.m_GameOver)
        {
            BackButton.SetActive(true);
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void CallPlayerNameText()
    {
        DataPersistenceManager.Instance.GetPlayerName();
        Debug.Log("button works");
    }

    public void DestroyDataManager()
    {
        DataPersistenceManager.Instance.DestroyThis();
        Debug.Log("Destroy works");
    }
}


