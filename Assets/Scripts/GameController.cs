using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text ringsScoreText;
    [SerializeField]
    private Text livesScoreText;
    [SerializeField]
    private AudioSource getRingSound;
    [SerializeField]
    private AudioSource loseLifeSound;
    [SerializeField]
    private AudioSource levelMusic;
    [SerializeField]
    private AudioSource gameOverMusic;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject loseScreen;
    public int rings = 0;
    public int lives = 3;
    private int ringsOnLevel;
    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        levelMusic.loop = true;
        levelMusic.Play();
        ringsOnLevel = GameObject.FindGameObjectsWithTag("Ring").Length;
        ringsScoreText.text = $"{rings}";
        livesScoreText.text = $"{lives}";
    }

    public void AddRing()
    {
        rings++;
        ringsScoreText.text = $"{rings}";
        getRingSound.Play();
        WinCheck();
    }
    public void LoseLife()
    {
        lives--;
        livesScoreText.text = $"{lives}";
        loseLifeSound.Play();
        LoseCheck();
    }
    public bool WinCheck()
    {
        if (rings >= ringsOnLevel)
        {
            return true;
        }
        return false;
    }
    public void LoseCheck()
    {
        if (lives <= 0)
        {
            Lose();
        }

    }
    public void Win()
    {
        PauseOn();
        winScreen.SetActive(true);
    }
    public void Lose()
    {
        PauseOn();
        gameOverMusic.Play();
        loseScreen.SetActive(true);

    }

    public void PauseOn()
    {
        levelMusic.Pause();
        Time.timeScale = 0;
    }
    public void PauseOff()
    {
        levelMusic.Play();
        Time.timeScale = 1;
    }
}
