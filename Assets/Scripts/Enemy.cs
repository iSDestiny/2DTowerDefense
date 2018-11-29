using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	private Transform target;
	
	private int wavepointIndex = 0;
	

	// Use this for initialization
	void Start () {
		
		target = Waypoints.waypoints[0];
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = target.position - transform.position;
        
		transform.Translate(dir.normalized*10*Time.deltaTime,Space.World);

		if (Vector3.Distance(transform.position, target.position) < .5f)

		{


			GetNextWayPoint();
			//Debug.Log("TESTING");


		}

		//enemy.speed = enemy.startSpeed;
		
	}
	
	
	private void GetNextWayPoint()
	{

		if (wavepointIndex == Waypoints.waypoints.Length-1)

		{  
			


			EndPath();
			return;
		}

		wavepointIndex += 1;
		target = Waypoints.waypoints[wavepointIndex];

	}
	
	void EndPath()

	{
		WaveSpawner.enemies.Remove(gameObject);
		Destroy(gameObject);
	}

}
