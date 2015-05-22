using UnityEngine;
using System.Collections;

public class IntroController : MonoBehaviour
{

	public GameObject nextObject;

	public void ActivateNext ()
	{
		nextObject.SetActive (true);
		gameObject.SetActive (false);
	}

	public void GoToNextScene ()
	{

		switch (Application.loadedLevelName) {
		case "Intro_1":
			Application.LoadLevel ("Intro_2");
			break;
		case "Intro_2":
			Application.LoadLevel ("Intro_3");
			break;
		case "Intro_3":
			Application.LoadLevel ("Intro_4");
			break;
		case "Intro_4":
			Application.LoadLevel ("Intro_5");
			break;
		}

	}
}
