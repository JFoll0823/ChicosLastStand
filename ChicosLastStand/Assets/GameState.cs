using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public bool isGameStarted = false;
    public bool isGameOver = false;

    [SerializeField] GameObject _gameStartText;
    [SerializeField] GameObject _gameOverText;
    [SerializeField] GameObject _winText;

    private void Awake()
    {
        Instance = this;
        _gameStartText.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.Instance.isGameStarted && Input.GetButtonDown("Submit"))
        {
            _gameStartText.SetActive(false);
            isGameStarted = true;
            Time.timeScale = 1;
            GameplayManager.Instance.GameStarted();
        }
        if(isGameOver && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }

    public void InitiateGameOver()
    {
        _gameOverText.SetActive(true);
        Time.timeScale = 0;
        isGameStarted = false;
        isGameOver = true;
    }

    public void InitiateWin()
    {
        _winText.SetActive(true);
        Time.timeScale = 0;
        isGameStarted = false;
        isGameOver = true;
    }


}
