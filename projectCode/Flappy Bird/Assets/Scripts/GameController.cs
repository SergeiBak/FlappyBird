using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private GameObject scoreBoard;
    [SerializeField]
    private Text scoreBoardScore;
    [SerializeField]
    private Text scoreBoardHighScore;
    [SerializeField]
    private GameObject newScore;

    [SerializeField]
    private GameObject bronzeMedal;
    [SerializeField]
    private GameObject silverMedal;
    [SerializeField]
    private GameObject goldMedal;
    [SerializeField]
    private GameObject platinumMedal;


    [SerializeField]
    Image soundOnIcon;
    [SerializeField]
    Image soundOffIcon;

    bool muteMusic;

    private int score;

    private void Awake()
    {
        Pause();

        gameOver.SetActive(false);
        scoreBoard.SetActive(false);
        startScreen.SetActive(true);

        SetupStats();

        if (PlayerPrefs.GetInt("FlappyMute") == 1)
        {
            AudioListener.volume = 0;
            AudioListener.pause = true;
            muteMusic = true;
        }
        else
        {
            AudioListener.volume = 1;
            AudioListener.pause = false;
            muteMusic = false;
        }
        UpdateMuteIcon();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        scoreBoard.SetActive(false);
        startScreen.SetActive(false);

        Time.timeScale = 1;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    public void GameOver()
    {
        scoreBoardScore.text = score.ToString();

        if (score > PlayerPrefs.GetInt("FlappyHighScore"))
        {
            PlayerPrefs.SetInt("FlappyHighScore", score);
            newScore.SetActive(true);
        }
        else
        {
            newScore.SetActive(false);
        }

        scoreBoardHighScore.text = PlayerPrefs.GetInt("FlappyHighScore").ToString();

        gameOver.SetActive(true);
        playButton.SetActive(true);
        scoreBoard.SetActive(true);

        SetupMedals();

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void SetupMedals()
    {
        ClearMedals();

        if (score < 10)
        {
            return;
        }
        else if (score >= 10 && score < 20)
        {
            bronzeMedal.SetActive(true);
        }
        else if (score >= 20 && score < 30)
        {
            silverMedal.SetActive(true);
        }
        else if (score >= 30 && score < 40)
        {
            goldMedal.SetActive(true);
        }
        else if (score >= 40)
        {
            platinumMedal.SetActive(true);
        }
    }

    void ClearMedals()
    {
        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
        platinumMedal.SetActive(false);
    }

    void SetupStats()
    {
        if (!PlayerPrefs.HasKey("FlappyHighScore"))
        {
            PlayerPrefs.SetInt("FlappyHighScore", 0);
        }
        if (!PlayerPrefs.HasKey("FlappyMute"))
        {
            PlayerPrefs.SetInt("FlappyMute", 0);
        }
    }

    public void ToggleMute()
    {
        if (!muteMusic)
        {
            muteMusic = true;
            AudioListener.volume = 0;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("FlappyMute", 1);
        }
        else
        {
            muteMusic = false;
            AudioListener.volume = 1;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("FlappyMute", 0);
        }

        UpdateMuteIcon();
    }

    void UpdateMuteIcon()
    {
        if (!muteMusic)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }
}
