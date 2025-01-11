using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScripts : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject mainGamePanel;
    // private float maxSensitivity = 0.0001f;
    // private float minSensitivity = 0.1f;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public Slider slider;
    private MainAudioInputController mainAudioInputController;
    bool isPaused = false;

    void Start()
    {
        mainAudioInputController = GameObject.FindObjectOfType<MainAudioInputController>();

        slider.minValue = 0.001f;
        slider.maxValue = 0.01f;
        slider.value /= 2;
    }
    void OnEnable()
    {
        Debug.Log("Onenable was called");
        StartCoroutine(WaitForMainAudioInputController());
    }

    void OnDisable()
    {
        Debug.Log("OnDisable was called");
        if (mainAudioInputController != null)
        {
            Debug.Log("Ondisable was called inside the null check");
            mainAudioInputController.OnNewMicrophoneConnected -= PauseGame;
        }
    }

    IEnumerator WaitForMainAudioInputController()
    {
        while (mainAudioInputController == null)
        {
            yield return null;
        }
        if (mainAudioInputController != null)
        {
            mainAudioInputController.OnNewMicrophoneConnected += PauseGame;
        }
    }
    void Update()
    {
        if (GameManager.instance.player.IsDead())
        {
            mainGamePanel.SetActive(false);
            gameOverPanel.SetActive(true);
            return;
        }
    }

    public void PauseWindowAppear()
    {
        isPaused = true;
        pausePanel.SetActive(true);
    }
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            pausePanel.SetActive(false);
            mainGamePanel.SetActive(true);
            return;
        }

        // Pause the game
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true);
        mainGamePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainGamePanel.SetActive(true);
        GameManager.instance.player.ResetDeath();
        GameManager.instance.player.ResetHealth();

    }

    public void OnSliderValueChanged()
    {
        // mainAudioInputController.threshold = Mathf.Pow(10f, slider.value);
        mainAudioInputController.threshold = slider.value;
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
