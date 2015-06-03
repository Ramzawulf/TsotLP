using UnityEngine;
using System.Collections;

public class GoToIntro : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
            Application.LoadLevel("Intro_1");
	}
}
