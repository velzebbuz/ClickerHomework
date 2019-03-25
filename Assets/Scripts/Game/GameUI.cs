﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }
    [SerializeField] private Text textScore;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _missPoint;

    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject backButton;

    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite unpauseSprite;

    [SerializeField] private Text scorePauseText;
    [SerializeField] private Text winUIText;
    

    public Text textLife;
    public Text textCombo;
    public Text hitRate;
    private Image pauseImage;
   
    public bool gameOnPause;

    private bool pauseMusic;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        textLife.text = "Lifes: " + GameManager.Instance.lifeCount;
        gameOnPause = false;
        pauseImage = pauseButton.gameObject.GetComponent<Image>();        
    }

    private void Update ()
    {
        LoseGameUI();
        WinGameUI();
	}

    private void LoseGameUI()
    {
        if (GameManager.Instance._loseGame)
        {
            pausePanel.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            winUIText.text = "You lose!";
            scorePauseText.text = "Score : " + GameManager.Instance.score.ToString();
        }
    }
    private void WinGameUI()
    {
        if(GameManager.Instance._winGame)
        {
            pausePanel.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            winUIText.text = "You win!";
            scorePauseText.text ="Score : " + GameManager.Instance.score.ToString();
        }
    }
    public void Restart()
    {
       SceneManager.LoadScene("Game");       
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Pause_Game()
    {
        if (gameOnPause == false)
        {
            pauseImage.sprite = unpauseSprite;
            gameOnPause = true;
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
            scorePauseText.text = "Score : " + GameManager.Instance.score.ToString();
            GameManager.Instance.gameModAudio.Pause();
        }
        else
        {
            GameManager.Instance.gameModAudio.Play();
            pauseImage.sprite = pauseSprite;
            gameOnPause = false;
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
        }
    }

}
