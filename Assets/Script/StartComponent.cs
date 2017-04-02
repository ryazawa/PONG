using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartComponent : MonoBehaviour{

	public void OnClick()
	{

		SceneManager.LoadScene ("GameMain");

	}

}