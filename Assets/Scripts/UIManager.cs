using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject GameOverUI;
    public GameObject GameCompleteUI;
    public TMP_Text RemainingEnemiesUI;

    private void OnEnable()
    {
        GameEvents.GameOver += ShowGameOverUI;
        GameEvents.GameComplete += ShowCompleteUI;
    }

    private void OnDisable()
    {
        GameEvents.GameOver -= ShowGameOverUI;
        GameEvents.GameComplete -= ShowCompleteUI;
    }

    private void Update()
    {
        RemainingEnemiesUI.SetText("Remaining Enemies: " + GameManager.Instance.TotalNoOfEnemies);
    }

    public void ShowGameOverUI()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }

    public void ShowCompleteUI()
    {
        Time.timeScale = 0;
        GameCompleteUI.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
