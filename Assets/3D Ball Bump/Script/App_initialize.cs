using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class App_initialize : MonoBehaviour
{
    public GameObject InMenu;
    public GameObject InGameUI;
    public GameObject GameOverUI;
    public GameObject Player;
    public GameObject adButton;
    private bool hasgameplay = false;
    private bool hasRewardAds = false;

    void Awake()
    {
       // PlayerPrefs.DeleteAll();
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
        
       
    }
    void Start()
    {
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenu.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false); 
        GameOverUI.gameObject.SetActive(false);
      
    }

    public void PlayButton()
    {
        if (hasgameplay == true)
        {
            StartCoroutine(StartGame(1.0f));
        }
        else
        {
            StartCoroutine(StartGame(0.0f));
        }
        
    }
    public void PauseButton()
    {
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenu.gameObject.SetActive(true);
        InGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        hasgameplay = true;
    }
    public void GameOver()
    {
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        InMenu.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(false);
        GameOverUI.gameObject.SetActive(true);
        if (hasRewardAds == true)
        {
            adButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.GetComponent<Button>().enabled = false;
            adButton.GetComponent<Animator>().enabled = false;
        }
    }
   
    public void RestartLev2()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowRwAd()
    {
        hasRewardAds = true;//temp
        StartCoroutine(StartGame(1.0f)); 
    }

    IEnumerator StartGame(float waitTime)
    {
        InMenu.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(true);
        GameOverUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

    }
   public void MenuBtn()
    {
        Application.Quit();
    }
    

}
