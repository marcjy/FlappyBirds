using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public event EventHandler OnPlayAgain;

    public PlayerController Player;

    public TextMeshProUGUI ScoreText;
    public GameObject PauseWindow;
    public GameObject DefeatWindow;

    private void Awake()
    {
        Player.OnPause += HandlePause;
        Player.OnCrash += HandleDefeat;
        Player.OnScorePoints += HandleScorePoints;
    }

    private void HandleScorePoints(object sender, int e)
    {
        ScoreText.text = e.ToString();
    }

    private void HandlePause(object sender, System.EventArgs e)
    {
        Time.timeScale = 0;
        PauseWindow.SetActive(true);
    }
    private void HandleDefeat(object sender, System.EventArgs e)
    {

        Time.timeScale = 0;
        DefeatWindow.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseWindow.SetActive(false);
        DefeatWindow.SetActive(false);
    }

    public void Unpause()
    {
        PauseWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        OnPlayAgain?.Invoke(this, EventArgs.Empty);
    }
}
