using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

	public static bool isCol = false;
	public static bool isScore;
	private int isEnd = 0;

	private int leftPoint = 0;
	private int rightPoint = 0;

	[Header("プレイヤー1スコア用テキスト")]
	[SerializeField] private Text leftScore;

	[Header("プレイヤー2スコア用テキスト")]
	[SerializeField] private Text rightScore;

	[Header("ゲーム終了画面用モーダル")]
	[SerializeField] private GameObject endModal = null;

	void OnParticleCollision(GameObject col)
	{

		isCol = (col.gameObject.transform.tag == "leftcol" || col.gameObject.transform.tag == "rightcol") ? true : false;
		isScore = (col.gameObject.transform.tag == "leftcol") ? true : false;

		if (isCol == true) {

			if (!isScore) {
				leftPoint += 1;
				leftScore.text = leftPoint.ToString();

				isEnd = (leftPoint == 11) ? 1 : 0;

			} else {
				rightPoint += 1;
				rightScore.text = rightPoint.ToString();

				isEnd = (rightPoint == 11) ? 2 : 0;
			}

			if (isEnd > 0) {

				GameObject endObj = Instantiate (endModal) as GameObject;

				string endMsg = (isEnd == 1) ? "PLAYER1 WIN !!" : "PLAYER2 WIN !!";

				endObj.GetComponentInChildren<Text> ().text = endMsg;

				Time.timeScale = 0f;

			}

		}	

	}

}
