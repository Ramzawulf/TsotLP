using UnityEngine;
using System.Collections;

public class DemoCamera : MonoBehaviour
{
	
	public Transform[] points;
	public float speed = 0.5f;
	public float closenessThreshold = 0.5f;

	public Transform finalPoint;
	public float finalSize = 10;

	public int currentPoint = 0;

	
	void LateUpdate ()
	{
		FollowPoints ();
	}
	
	private void FollowPoints ()
	{
		if (points.Length < 1)
			return;
		if (currentPoint >= points.Length) {
			GoToFinalPoint ();
		} else {
			Vector3 targetPosition = new Vector3 (points [currentPoint].position.x, points [currentPoint].position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime);
			if (Vector3.Distance (transform.position, targetPosition) < closenessThreshold) {
				currentPoint++;
			}
		}
	}

	private void GoToFinalPoint ()
	{
		Vector3 targetPosition = new Vector3 (finalPoint.position.x, finalPoint.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPosition, speed * Time.deltaTime);

		Camera cam = GetComponent<Camera> ();
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, finalSize, Time.deltaTime * speed);
	}
}
