using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class ElementsComponentController : MonoBehaviour {

	public Transform panelTransform;
	public GameObject panelShop;
	public GameObject panelPause;


	public GameObject topBar;

	public GameObject groupA;
	public GameObject groupB;

	public GameObject battleYou;
	public GameObject battleOpponent;


	private List<GameObject> groupAlist = new List<GameObject> ();
	private List<GameObject> groupBlist = new List<GameObject> ();
	private bool isSceneLoad = false;

	[HideInInspector]
	public bool _isPopupOn = false;

	void Awake () {
		topBar.transform.DOLocalMoveY (500f, 0f).SetRelative (true);
		battleYou.transform.DOLocalMoveY (500f, 0f).SetRelative(true);
		battleOpponent.transform.DOLocalMoveY (500f, 0f).SetRelative (true);

		foreach (Transform go in groupA.transform) {
			groupAlist.Add (go.gameObject);
			go.gameObject.transform.DOLocalMoveX (-1300f, 0f).SetRelative (true);
		}

		foreach (Transform go in groupB.transform) {
			go.gameObject.transform.DOLocalMoveX (800f, 0f).SetRelative (true);
			groupBlist.Add (go.gameObject);
		}
	}

	void Start () {
		StartCoroutine (StwitchCheck ());
		StartCoroutine (InAnimation ());
	}

	//InAnimation
	IEnumerator InAnimation () { 
		topBar.transform.DOLocalMoveY (-500f, 0.25f).SetRelative (true).SetEase (Ease.InOutCubic);
		yield return new WaitForSeconds (0.15f);

		battleYou.transform.DOLocalMoveY (-500f, 0.25f).SetRelative (true).SetEase (Ease.OutBack);
		battleOpponent.transform.DOLocalMoveY (-500f, .25f).SetRelative (true).SetEase (Ease.OutBack).SetDelay (0.1f);
		yield return new WaitForSeconds (0.1f);

		StartCoroutine (InGroupA_Animation ());
		yield return new WaitForSeconds (0.2f);
		StartCoroutine (InGroupB_Animation ());
	}

	IEnumerator InGroupA_Animation () { 
		for (int i = 0; i < groupAlist.Count; i++) {
			groupAlist [i].gameObject.transform.DOLocalMoveX (1300f, 0.35f).SetRelative (true).SetEase (Ease.OutBack);
			yield return null;
		}
	}

	IEnumerator InGroupB_Animation () {
		for (int i = 0; i < groupBlist.Count; i++) {
			groupBlist [i].gameObject.transform.DOLocalMoveX (-800f, 0.35f).SetRelative (true).SetEase (Ease.OutBack);
			yield return new WaitForSeconds (0.1f);
		}
	}

	//OutAnimation
	IEnumerator OutAnimation () {
		battleYou.transform.DOLocalMoveY (500f, 0.2f).SetRelative (true).SetEase (Ease.InBack);
		battleOpponent.transform.DOLocalMoveY (500f, .2f).SetRelative (true).SetEase (Ease.InBack).SetDelay (0.1f);
		yield return new WaitForSeconds (0.1f);

		StartCoroutine (OutGroupA_Animation ());
		yield return new WaitForSeconds (0.2f);
		StartCoroutine (OutGroupB_Animation ());

		yield return new WaitForSeconds (0.5f);
		topBar.transform.DOLocalMoveY (500f, 0.2f).SetRelative (true).SetEase (Ease.InOutCubic).OnComplete (() => {
			PlayManager.Instance.SceneLoad (GlobalDefines.SCENE_TITLE);
		});
	}

	IEnumerator OutGroupA_Animation () {
		for (int i = 0; i < groupAlist.Count; i++) {
			groupAlist [i].gameObject.transform.DOLocalMoveX (-1300f, 0.15f).SetRelative (true).SetEase (Ease.InBack);
			yield return null;
		}
	}

	IEnumerator OutGroupB_Animation () {
		for (int i = 0; i < groupBlist.Count; i++) {
			groupBlist [i].gameObject.transform.DOLocalMoveX (800f, 0.15f).SetRelative (true).SetEase (Ease.InBack);
			yield return null;
		}
	}


	public void BuyLife () {
		if (!_isPopupOn) {
			_isPopupOn = true;
			GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
			panels.transform.SetParent (panelTransform, false);
			panels.GetComponent<PanleShop> ().TabButtonLife ();
			panels.name = panelShop.name;
		}
	
	}

	public void BuyCoin () {
		if (!_isPopupOn) {
			_isPopupOn = true;
			GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
			panels.transform.SetParent (panelTransform, false);
			panels.GetComponent<PanleShop> ().TapButtonCoin ();
			panels.name = panelShop.name;
		}

	}

	public void BuyGem () {
		if (!_isPopupOn) {
			_isPopupOn = true;
			GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
			panels.transform.SetParent (panelTransform, false);
			panels.GetComponent<PanleShop> ().TapButtonGem ();
			panels.name = panelShop.name;
		}
	}

	public void ClickPause () {
		if (!_isPopupOn) {
			_isPopupOn = true;
			GameObject panels = (GameObject) Instantiate (panelPause, new Vector3 (0f, 60f, 0f), Quaternion.identity);
			panels.transform.SetParent (panelTransform, false);
			panels.name = panelPause.name;
		}
	}

	IEnumerator StwitchCheck () {
		while (true) {
			if (_isPopupOn) {
				yield return new WaitForSeconds (1f);
				_isPopupOn = false;
			}
			yield return null;
		}
	}

	public void ClickBack () {
		if (!isSceneLoad) {
			isSceneLoad = true;
			StartCoroutine (OutAnimation ());
		}
			
	}



}
