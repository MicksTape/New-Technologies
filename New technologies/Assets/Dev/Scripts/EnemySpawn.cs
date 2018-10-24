using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject Enemy;
    public float spawnTime = 3f;
    public Transform[] spawnpoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnpoints.Length);

        Instantiate(Enemy, spawnpoints[spawnPointIndex].position, spawnpoints[spawnPointIndex].rotation);
    }
}
