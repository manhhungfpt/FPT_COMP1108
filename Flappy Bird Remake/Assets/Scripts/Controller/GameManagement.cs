using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{

    public static GameManagement instance;

    private const string HIGH_SCORE = "High Score";

     void Awake()
    {
        _MakeSingleInstance();
        IsGameStartForTheFirstTime();
    }

    void IsGameStartForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartForTheFirstTime")){
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFirstTime",0);
        }
    }

    void _MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void _SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
