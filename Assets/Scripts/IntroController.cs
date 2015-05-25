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

    void Update()
    {
        if (Input.anyKey)
        {
            if (nextObject == null)
            {
                GoToNextScene();
            }
            else
            {
                ActivateNext();
            }
        }
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
                Application.LoadLevel ("Sewers");
			break;
		}

	}
}
