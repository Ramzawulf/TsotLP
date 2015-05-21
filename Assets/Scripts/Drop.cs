using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Princess.ctrl.Damage ();
		}
		Destroy (gameObject, 0.1f);
	}
}
