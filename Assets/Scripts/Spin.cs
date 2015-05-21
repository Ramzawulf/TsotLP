using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{

	public float SpinSpeed = 1;
	
	// Update is called once per frame
	void Update ()
	{
		Rotate ();
	}

	private void Rotate ()
	{
		transform.Rotate (new Vector3 (0, 0, 1) * SpinSpeed);
	}
}
