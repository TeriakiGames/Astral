using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class StageController : MonoBehaviour {

	public GameObject panelShop;
	public GameObject stagePopup_First;
	public GameObject stagePopup_Replay;
	public GameObject stagePopup_Complete;
	public Stage[] _Stage;
	public Transform panelTransform;

	public GameObject [] allStages;
	public GameObject topBar;

	public Image leftArrow;
	public Image rightArrow;
	public Image[] naviIcons;

	void Awake () {
		for (int i = 0; i < allStages.Length; i++) {
			allStages [i].gameObject.transform.DOScaleY (0f, 0f);
		}

		for (int i = 0; i < naviIcons.Length; i++) {
			naviIcons [i].gameObject.transform.DOScale (Vector3.zero, 0f);
		}

		leftArrow.transform.DOLocalMoveX (-200f, 0f).SetRelative(true);
		rightArrow.transform.DOLocalMoveX (200f, 0f).SetRelative(true);

		topBar.transform.DOLocalMoveY (300f, 0f).SetRelative(true);
	}

	void Start () {
		StartCoroutine (InAnimation ());
	}

	IEnumerator InAnimation () { 
		topBar.transform.DOLocalMoveY (-300f, 0.25f).SetEase (Ease.InOutCubic).SetRelative (true);

		for (int i = 0; i < allStages.Length; i++) {
			allStages [i].gameObject.transform.DOScaleY (1f, 0.2f);
			yield return null;
		}

		yield return new WaitForSeconds (0.2f);

		for (int i = 0; i < naviIcons.Length; i++) {
			naviIcons [i].gameObject.transform.DOScale (Vector3.one, 0.2f);
		}

		leftArrow.transform.DOLocalMoveX (200f, 0.3f).SetRelative (true);
		rightArrow.transform.DOLocalMoveX (-200f, 0.3f).SetRelative (true);
	}

	IEnumerator OutAniamtion () {
		yield return null;

		leftArrow.transform.DOLocalMoveX (-200f, 0.2f).SetRelative (true);
		rightArrow.transform.DOLocalMoveX (200f, 0.2f).SetRelative (true);

		OutIconStageImage ();

		topBar.transform.DOLocalMoveY (300f, 0.2f).SetEase (Ease.InOutCubic).SetRelative (true).OnComplete (() => { 
			PlayManager.Instance.SceneLoad (GlobalDefines.SCENE_TITLE);
		});
	}

	public void OutAnimations (string sceneName) {
		StartCoroutine (OutAniamtion (sceneName));
	}

	IEnumerator OutAniamtion (string sceneName) {
		yield return null;

		leftArrow.transform.DOLocalMoveX (-200f, 0.2f).SetRelative (true);
		rightArrow.transform.DOLocalMoveX (200f, 0.2f).SetRelative (true);

		OutIconStageImage ();

		topBar.transform.DOLocalMoveY (300f, 0.2f).SetEase (Ease.InOutCubic).SetRelative (true).OnComplete (() => {
			PlayManager.Instance.SceneLoad (sceneName);
		});
	}


	void OutIconStageImage () {
		for (int i = 0; i < allStages.Length; i++) {
			allStages [i].gameObject.transform.DOScaleY (0f, 0.1f);
		}

		for (int i = 0; i < naviIcons.Length; i++) {
			naviIcons [i].gameObject.transform.DOScale (Vector3.zero, 0.15f);
		}
	}

	public void BuyLife () { 
		GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.GetComponent<PanleShop> ().TabButtonLife ();
		panels.name = panelShop.name;
	}

	public void BuyCoin () { 
		GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.GetComponent<PanleShop> ().TapButtonCoin ();
		panels.name = panelShop.name;
	}

	public void BuyGem () { 
		GameObject panels = (GameObject) Instantiate (panelShop, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.GetComponent<PanleShop> ().TapButtonGem ();
		panels.name = panelShop.name;
	}

	public void StageFirst () { 
		GameObject panels = (GameObject) Instantiate (stagePopup_First, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.name = stagePopup_First.name;
	}

	public void StageReplay () {
		GameObject panels = (GameObject) Instantiate (stagePopup_Replay, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.name = stagePopup_Replay.name;
	}

	public void StageComplete () {
		GameObject panels = (GameObject) Instantiate (stagePopup_Complete, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		panels.name = stagePopup_Complete.name;
	}


	public void BackTtitle () {
		StartCoroutine (OutAniamtion ());
	}
}
