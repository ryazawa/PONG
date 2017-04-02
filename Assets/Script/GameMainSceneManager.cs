using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMainSceneManager : MonoBehaviour {

	private bool isTimeCheck = false;

	[Header("ポーズ画面用キャンバス")]
	[SerializeField] private GameObject pauseCanvas = null;

	private GameObject canvasObj = null;

	public void OnTop()
	{

		if (Time.timeScale == 0f)
			Time.timeScale = 1f;

		StartModalController.isStart = false;
		SceneManager.LoadScene ("StartScene");

	}

	public void OnStop()
	{
		if (!isTimeCheck) {
			canvasObj = Instantiate (pauseCanvas) as GameObject;
			Time.timeScale = 0f;
			isTimeCheck = true;
		} else {

			if (canvasObj != null)
				Destroy (canvasObj.gameObject);

			Time.timeScale = 1f;
			isTimeCheck = false;
		}

	}

}
