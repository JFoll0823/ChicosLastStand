using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	public static GameplayManager Instance;

	public int zCount;

	[SerializeField] bool roundsDisabled;

	bool _roundActive;
	public int currentRound;
	float _rCountdown;

	[SerializeField] GameObject zombie;
	[SerializeField] GameObject spawnArea;
	[SerializeField] int numSpawns;

	[SerializeField] Text hudRound;
	[SerializeField] Text hudEnemies;

	private void Awake()
	{
		Instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{
		_roundActive = false;
		currentRound = 0;
		zCount = 0;
	}

	// Update is called once per frame
	void Update()
	{
        if (!roundsDisabled)
        {
			if (zCount <= 0 && _roundActive)
			{
				_rCountdown = Time.time;
				_roundActive = false;
			}

			if (!_roundActive && Time.time - _rCountdown >= 3)
			{
				SpawnEnemies();
				currentRound++;

				if(currentRound == 6)
                {
					GameState.Instance.InitiateWin();
                }
                else
                {
					_roundActive = true;
                }
				
			}
		}
		updateHud();
	}

	void SpawnEnemies()
	{
		if (GameState.Instance.isGameStarted)
		{
			for(int i = 0; i < (currentRound + 1)*3; i++)
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

	private void updateHud()
    {
		hudRound.text = "Round: " + currentRound;
		hudEnemies.text = "Zombies: " + zCount;

	}
}
