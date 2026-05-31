using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject clickButton;
    [SerializeField] private GameObject adsButton;
    [SerializeField] private GameObject goodJob;
    [SerializeField] private Text timeText;
    [SerializeField] private Text needToClickText;
    [SerializeField] private int needToClick;

    int myClick;
    int seconds;
    bool isGame;




    private void Start()
    {
        seconds = 0;
        needToClick = 30;
        clickButton.SetActive(true);
        adsButton.SetActive(false);
        goodJob.SetActive(false);
        UpdateUI();
    }

    public void ClickButton()
    {
        if (!isGame)
        {
            myClick++;
            StartGame();
            randomValue();
        }
        else
        {
            myClick++;
            randomValue();
            UpdateUI();
            if (myClick >= needToClick)
            {
                CancelInvoke();
                isGame = !isGame;
                clickButton.SetActive(false);
                adsButton.SetActive(false);
                goodJob.SetActive(true);
            }
        }
    }
    public void adsButtonClicked()
    {
        myClick -= 8;
        clickButton.SetActive(true);
        adsButton.SetActive(false);
        UpdateUI();
    }
    private void UpdateUI()
    {
        timeText.text = seconds.ToString();
        needToClickText.text = string.Format("{0}/{1}", myClick, needToClick);
    }

    public void restartButton()
    {
        clickButton.SetActive(true);
        adsButton.SetActive(false);
        goodJob.SetActive(false);
        seconds = 0;
        myClick = 0;
        StartGame();
    }
     

    public void closeAdButton()
    {
        clickButton.SetActive(true);
        adsButton.SetActive(false);
    }

    private void StartGame()
    {
        isGame = !isGame;
        InvokeRepeating("myTimer", 0f, 1f);
    }

    private void myTimer()
    {
        seconds++;
        UpdateUI();
    }
    private void randomValue()
    {
        if (Random.Range(0, 101) < 10)
        {
            clickButton.SetActive(false);
            adsButton.SetActive(true);
        }
        else
        {
            clickButton.SetActive(true);
            adsButton.SetActive(false);
        }
    }
    
}
