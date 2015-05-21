using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour
{
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Destructible") {
			Destroy (other.gameObject);
		}
	}
}
