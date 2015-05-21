using UnityEngine;
using System.Collections;

public class Rat : MonoBehaviour
{	
	public Transform StartPoint;
	public Transform EndPoint;
	private Transform Target;

	public float movementSpeed = 0.5f;
	public float movementWindow = 0.5f;
	public float lastMove;

	public bool direction;

	void Start ()
	{
		lastMove = Time.time;
		Target = StartPoint;	
	}

	void Update ()
	{
		Move ();
	}

	void Move ()
	{
		if (Time.time > movementWindow + lastMove)
			return;
		lastMove = Time.time;

		if (Vector2.Distance (transform.position, Target.position) < 0.5f) {
			if (Target.position == StartPoint.position) {
				Target = EndPoint;
			} else {
				Target = StartPoint;
			}
		} else {
			transform.position = Vector2.Lerp (transform.position, Target.position, movementSpeed);
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			Princess.ctrl.Damage ();
		}
	}
}
