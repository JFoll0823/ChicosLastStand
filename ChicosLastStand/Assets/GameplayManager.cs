using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public int zCount;

    bool _roundActive;
    int _currentRound;
    float _rCountdown;

    [SerializeField] GameObject zombie;
    [SerializeField] GameObject spawnArea;
    [SerializeField] int numSpawns;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _roundActive = false;
        _currentRound = 0;
        zCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (zCount <= 0 && _roundActive)
        {
            _rCountdown = Time.time;
            _roundActive = false;
        }

        if (!_roundActive && Time.time - _rCountdown >= 5)
        {
            SpawnEnemies();
            _currentRound++;
            _roundActive = true;
        }

    }

    void SpawnEnemies()
    {
        if (GameState.Instance.isGameStarted)
        {
            for(int i = 0; i < _currentRound*3; i++)
            {
                string randSpawn = Random.Range(1, numSpawns + 1).ToString();
                Instantiate(zombie, spawnArea.transform.Find(randSpawn).transform.position, Quaternion.identity);
                zCount++;
            }
        }
    }

    public void GameStarted()
    {
        _rCountdown = Time.time;
    }
}
