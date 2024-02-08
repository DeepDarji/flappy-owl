using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFader : MonoBehaviour
{

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvase;

    [SerializeField]
    private Animator fadeAnim;
    void Awake()
    {
        MakeSingelton();
                
    }

    void MakeSingelton()
    {
        if(instance != null) {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeIn(string levelName)
    {
        StartCoroutine (FadeInAnimation(levelName));
    }


    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }


    IEnumerator FadeInAnimation(string levelName) {
        fadeCanvase.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.5f);
        Application.LoadLevel(levelName);
        FadeOut();
    }

    IEnumerator FadeOutAnimation()
    {
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(.7f);
        fadeCanvase.SetActive(false);
    }


}
