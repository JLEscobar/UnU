using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pausa;

    private bool isPaused;

    public static GameManager Instance {get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UpdateGameState();
            ShowPausePanel();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Salir...");
            Application.Quit();
        }
    }

    private void UpdateGameState()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowPausePanel()
    {
        if(isPaused)
        {
            pausa.SetActive(true);
        }
        else
        {
            pausa.SetActive(false);
        }
    }
}
