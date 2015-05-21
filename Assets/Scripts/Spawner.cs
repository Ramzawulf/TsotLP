using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject Spawn;
	
	public float spawnSpeed = 0.75f;
	public float lastSpawn;
	
	void Start ()
	{
		lastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Drop ();
	}
	
	void Drop ()
	{
		if (Time.time > lastSpawn + spawnSpeed) {
			Instantiate (Spawn, transform.position, Quaternion.identity);
			lastSpawn = Time.time;
		}
	}
}
