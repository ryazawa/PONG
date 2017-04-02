using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartModalController : MonoBehaviour {

	[Header("カウントダウン用テキストオブジェクト")]
	[SerializeField] private Text countDownTxt = null;

	[Header("STARTボタン")]
	[SerializeField] private GameObject startBtn = null;

	[Header("弾用パーティクルオブジェクト")]
	[SerializeField] private ParticleSystem ball = null;

	private int maxTime = 4;
	private float timeCounter = 0;

	private bool isPushBtn = false;
	static public bool isStart = false;

	void Start()
	{

		timeCounter = maxTime;
		countDownTxt.text = maxTime.ToString ();

	}

	void Update()
	{
		if (isPushBtn) {

			timeCounter -= Time.deltaTime;

			timeCounter = Mathf.Max (timeCounter, 0.0f);
			countDownTxt.text = ((int)timeCounter).ToString ();
		}

		if (countDownTxt.text == "0") {

			isPushBtn = false;

			ball.transform.Rotate (new Vector3 (Random.Range (-360f, 360f), 0f, 0f));

			ball.Play ();

			isStart = true;
			Destroy (this.gameObject);
		}

	}

	public void OnStart()
	{

		this.startBtn.SetActive (false);
		isPushBtn = true;

	}

}
