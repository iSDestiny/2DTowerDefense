

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	
	public Wave[] waves;
	
	public static int enemiesAlive;
	//public Transform enemyPrefab;

	public static ArrayList enemies;




	public float timeBetweenWaves = 1f;

	private float countdown = 2f;

	private int waveIndex = 0;

	public Transform spawnPoint;



	public float spawnSpeed = .15f;


	//public Transform startPoint;
	//public Transform endPoint;

	public GameObject enemyPrefab;

	

	public static Transform[] wayPoints; 

	// Use this for initialization
	void Start () {
		//Debug.Log("Not red");
		 
		 
		wayPoints = new Transform[transform.childCount];

		for (int i = 0; i < wayPoints.Length; i++)
		{

			wayPoints[i] = transform.GetChild(i);


		}
		
		enemies = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (enemies.Count > 0)

		{
			
			Debug.Log("ENEMIES ALIVE");
			return;
		}

		
		if (countdown <= 0f)
		{
			
			
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			
			//Debug.Log("Inside");
			return;

		}
		
		//Debug.Log(countdown);
		//Debug.Log("UPDATE");
		
		countdown -= Time.deltaTime;
		
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		
	}
	
	IEnumerator SpawnWave()
	{
		
		Debug.Log("START");
		
		Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);  
			
			Debug.Log(i);
            
			yield return new WaitForSeconds(1f/wave.rate);
		}

		waveIndex += 1;

		if (waveIndex == waves.Length)

		{
			
			Debug.Log("Level won");
			enabled = false;

		}
		
		Debug.Log("STOP");
		
		

		//EnemyMovement.speed += spawnSpeed;
	}

	private void SpawnEnemy(GameObject enemy)
	{
		GameObject tempEnemy=Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		enemies.Add(tempEnemy);
		enemiesAlive += 1;
	}

}
