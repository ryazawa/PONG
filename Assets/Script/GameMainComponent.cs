using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainComponent : MonoBehaviour {

	[Header("タイマー用テキストオブジェクト")]
	[SerializeField] private Text timer = null;

	[Header("ゲームリセット確認モーダル")]
	[SerializeField] private GameObject resetModal = null;

	[Header("プレイヤー1")]
	[SerializeField] private GameObject player1 = null;

	[Header("プレイヤー2")]
	[SerializeField] private GameObject player2 = null;

	[Header("ボール用パーティクルオブジェクト")]
	[SerializeField] private ParticleSystem particle;

	private Vector3 speed = new Vector3 (0f, 1.3f ,0f);

	private int min=0;
	private float sec=0;
	private int oldsec=0;

	void Start()
	{

	}

	void Update()
	{

		if (ScoreCount.isCol) {

			ScoreCount.isCol = false;
			particle.Simulate (0.0f, true, false);
			particle.gameObject.transform.Rotate (new Vector3 (Random.Range (-360f, 360f), 0f, 0f));
			particle.Clear ();
			particle.emission.SetBursts (
				new ParticleSystem.Burst[] {
					new ParticleSystem.Burst(0.0f,1)
				});
			particle.Play ();
		}

		if (StartModalController.isStart) {

			if (Time.timeScale > 0) {
				sec += Time.deltaTime;
				if (sec >= 60.0f) {
					min++;
					sec -= 60;
				}

				if ((int)sec != oldsec) {
					timer.text = min.ToString ("00") + ":" + sec.ToString ("00");
				}
				oldsec = (int)sec;
			}
		}

	}

	void FixedUpdate()
	{

		MoveOne ();
		MoveTwo ();

	}

	public void OnReset()
	{

		GameObject obj = Instantiate (resetModal) as GameObject;

	}

	private void MoveOne()
	{

		Vector3 position = player1.transform.position;

		if (Input.GetKey (KeyCode.W)) {
			if (position.y <= 23f) {
				position.y += speed.y;
			}
		} else if (Input.GetKey (KeyCode.S)) {
			if (position.y >= -26f) {
				position.y -= speed.y;
			}
		}

		player1.transform.position = position;

	}

	private void MoveTwo()
	{

		Vector3 position = player2.transform.position;

		if (Input.GetKey (KeyCode.UpArrow)) {
			if (position.y <= 23f) {
				position.y += speed.y;
			}
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			if (position.y >= -26f) {
				position.y -= speed.y;
			}
		}

		player2.transform.position = position;

	}

}
