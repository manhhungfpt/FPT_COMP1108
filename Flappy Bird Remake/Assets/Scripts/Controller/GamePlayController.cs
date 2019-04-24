using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

     void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }
    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void _BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if (score > GameManagement.instance.GetHighScore())
        {
            GameManagement.instance._SetHighScore(score);
        }
        bestScoreText.text = "" + GameManagement.instance.GetHighScore();
    }

    public void _MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void _RestartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void _RestartButtonGamePlay2()
    {
        SceneManager.LoadScene("GamePlay2");
    }

    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
