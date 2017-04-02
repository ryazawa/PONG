using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	public void OnYes()
	{

		if (Time.timeScale == 0f)
			Time.timeScale = 1f;

		StartModalController.isStart = false;
		SceneManager.LoadScene ("GameMain");

	}

	public void OnNo()
	{

		Destroy (this.gameObject);

	}

}
