using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public bool isGameStarted = false;
    public bool isGameOver = false;

    [SerializeField] GameObject _gameStartText;
    [SerializeField] GameObject _gameOverText;

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
    }

    public void InitiateGameOver()
    {
        _gameOverText.SetActive(true);
        Time.timeScale = 0;
    }


}
