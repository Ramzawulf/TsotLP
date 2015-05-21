using UnityEngine;
using System.Collections;

public class PoisonLeakage : MonoBehaviour
{
	
	public GameObject drop;

	public float dropSpeed = 0.75f;
	public float lastDrop;

	void Start ()
	{
		lastDrop = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Drop ();
	}

	void Drop ()
	{
		if (Time.time > lastDrop + dropSpeed) {
			Instantiate (drop, transform.position, Quaternion.identity);
			lastDrop = Time.time;
		}
	}
}
