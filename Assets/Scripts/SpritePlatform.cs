using UnityEngine;
using System.Collections;

public class SpritePlatform : MonoBehaviour
{

	public float maxHeight = 1f;
	public float MovementSpeed = 0.5f;
	private Vector3 initialPosition;

	void Awake ()
	{
		initialPosition = transform.position;
	}

	void Update ()
	{
		Move ();
	}

	void Move ()
	{
		transform.position = new Vector3 (initialPosition.x, initialPosition.y + Mathf.PingPong (Time.time * MovementSpeed, maxHeight), initialPosition.z);
	}
}
