using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public Transform playerTransform;

	public float smooth = 0.5f;

	public float hFollowRange = 0.5f;
	public float vFollowRange = 0.5f;

	public bool shouldFollow {
		get {
			return Mathf.Abs (playerTransform.position.x - transform.position.x) > hFollowRange || Mathf.Abs (playerTransform.position.y - transform.position.y) > vFollowRange;
		}
	}

	void LateUpdate ()
	{
		FollowPlayer ();
	}

	private void FollowPlayer ()
	{
		//Horiozntal validation.
		if (shouldFollow) {
			Vector3 targetPosition = new Vector3 (playerTransform.position.x, playerTransform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, targetPosition, smooth * Time.deltaTime);
		}
	}
}
