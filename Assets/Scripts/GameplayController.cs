using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameplayController : MonoBehaviour
{
    [SerializeField]
    public static GameplayController instanse;

    [SerializeField]
    private Text endScore, bestScore;

    [SerializeField]
    private Button restartGameButton;

    [SerializeField]
    private GameObject pausePanel;

    void Start()
    {
        MakeInstance();
        Time.timeScale = 0f;
    }

    void MakeInstance()
    {
        if (instanse == null) {
            instanse = this;
        }
    }


    public void PauseGame()
    {
        if (BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {
                pausePanel.SetActive(false);
                endScore.text = "" + BirdScript.instance.score;
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener (() => ResumeGame());
            
            }
        }
    } 


    public void GoToMenuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneFader.instance.FadeIn(Application.loadedLevelName);
    }

    public void PlayGame()
    {
        endScore.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void SetScore(int score)
    {
        endScore.text = "" + score;
    }

    public void PlayerDiedShowScore(int score)
    {
        pausePanel.SetActive(true);
        endScore.gameObject.SetActive(false);

        endScore.text = "" + score;

        if (score > GameController.instance.GetHighscore())
        {
            
        }
    }



}
