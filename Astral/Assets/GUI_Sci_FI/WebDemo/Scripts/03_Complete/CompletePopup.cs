using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class CompletePopup : MonoBehaviour {
	
	public Image backFade;
	public GameObject popupPanel;

	public Text gameScore;
	public Text textKillScore;
	public Text textTimeScore;
	public Text textCoinScore;

	public GameObject [] stars;

	void Awake () {
		gameScore.text = "0";
		textKillScore.text = "0";
		textTimeScore.text = "0";
		textCoinScore.text = "0";

		popupPanel.transform.DOScale (new Vector3 (1f, 0f, 1f), 0f);
		backFade.DOFade (0f, 0f);
	}


	IEnumerator Start () {
		backFade.DOFade (1f, 0.5f).SetEase (Ease.Linear);
		yield return new WaitForSeconds (0.3f);
		popupPanel.transform.DOScaleY (1f, 0.2f).SetEase (Ease.OutBack);

		yield return new WaitForSeconds (0.5f);
		StartCoroutine (CreateStar ());

		yield return new WaitForSeconds (0.5f);
	}

	IEnumerator CreateStar () {
		for (int i = 0; i < stars.Length; i++) {
			stars [i].SetActive (true);
			yield return new WaitForSeconds (0.25f);
		}

		yield return new WaitForSeconds (0.2f);
		StartCoroutine (Score ());
	}

	IEnumerator Score () { 
		int count = 0;

		for (int i = 0; i < 20; i++) {
			count += 1357;
			gameScore.text = string.Format ("{0:n0}", count);
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);
		StartCoroutine (KillScore ());
		StartCoroutine (TimeScore (Random.Range (80, 150)));
		StartCoroutine (CoinScore ());

		yield return new WaitForSeconds (0.5f);
		LevelUp ();
	}

	void LevelUp () { 
		GameObject panels = (GameObject) Instantiate (Resources.Load("5_Panel_07_Levelup"), new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (transform, false);
		panels.name = "5_Panel_07_Levelup";
	}

	IEnumerator KillScore () {
		int count = 0;

		for (int i = 0; i < 20; i++) {
			count += Random.Range (1, 11);
			textKillScore.text = count.ToString ();
			yield return null;
		}
	}


	IEnumerator TimeScore (float num) {
		float timer = 0;

		for (int i = 0; i < num/11; i++) {
			timer += num / 11;
			int time = (int) timer;
			int seconds = time % 60;

			int minutes = (time / 60) % 60;
			textTimeScore.text = string.Format ("{0:D2}:{1:D2}", minutes, seconds);
			yield return null;
		}
	}

	IEnumerator CoinScore () {
		int count = 0;

		for (int i = 0; i < 10; i++) {
			count += Random.Range(1, 11);
			textCoinScore.text = count.ToString ();
			yield return null;
		}
	}


	public void ClosePanel () {
		popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
			Destroy (this.gameObject);
		});
	}

	public void ClosePanel (string sceneName) {
		popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
			PlayManager.Instance.SceneLoad (sceneName);
			Destroy (this.gameObject);
		});
	}


	public void GoStage () {
		ClosePanel (GlobalDefines.SCENE_STAGE);
	}

	public void RePlay () {
		ClosePanel (GlobalDefines.SCENE_COMPLETE);
	}


}
