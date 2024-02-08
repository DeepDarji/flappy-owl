using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public static GameController instance;
    private const string HIGH_SCORE = "Hight Score";
    private const string SELECTED_BIRD = "Selected Bird";

    void Awake ()
    {
        MakeSingleton();
        IsTheGameStartedForTheFirstTime();
    }

    void Start()
    {
        
    }

    void MakeSingleton() { 
        if(instance != null) {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void IsTheGameStartedForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_BIRD, 0);
            PlayerPrefs.SetInt("IsTheGameStartedForTheFirstTime", 0);
        }
    }

    public void SetHighScore (int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);

    }
    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

/*    public void setSelectedBird(int selectedBird)
    {
        PlayerPrefs.GetInt(SELECTED_BIRD, selectedBird);
    }
    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(SELECTED_BIRD);
    }
*/
















}
