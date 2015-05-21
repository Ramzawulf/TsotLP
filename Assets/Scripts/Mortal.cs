using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour
{

	public bool dieOnHit = false;

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Princess.ctrl.Damage ();
		}
		if (dieOnHit) {
			Destroy (gameObject, 0.1f);
		}
	}
}
