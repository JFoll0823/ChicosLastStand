using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (GameState.Instance.isGameStarted)
        {
            string randSpawn = Random.Range(1, numSpawns).ToString();
            Instantiate(zombie, spawnArea.transform.Find(randSpawn).transform.position,Quaternion.identity);
        }
    }
}
