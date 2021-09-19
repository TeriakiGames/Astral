using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class LevelupPopup : MonoBehaviour {

	public GameObject [] medals;
	public Image backLight;

	public RectTransform decoLeft;
	public RectTransform decoRight;
	public RectTransform decoCenter;

	public Text textUnlocked;

	public GameObject[] unlockItems;

	private Vector2 sizeLeft;
	private Vector2 sizeRight;
	private Vector2 sizeCenter;

	public Image backFade;
	

	void Awake () {
		backLight.DOFade (0f, 0f);

		for (int i = 0; i < medals.Length; i++) {
			medals [i].SetActive (false);
		}

		backFade.DOFade (0f, 0f);
		
		decoCenter.gameObject.SetActive (false);
		sizeLeft = decoLeft.sizeDelta;
		decoLeft.sizeDelta = new Vector2 (0f, sizeLeft.y);

		sizeRight = decoRight.sizeDelta;
		decoRight.sizeDelta = new Vector2 (0f, sizeRight.y);

		sizeCenter = decoCenter.sizeDelta;
		decoCenter.sizeDelta = new Vector2 (0f, sizeCenter.y);

		textUnlocked.DOFade (0f, 0f);
		textUnlocked.transform.DOLocalMoveY (-50f, 0f).SetRelative(true);

		for (int i = 0; i < unlockItems.Length; i++) {
			unlockItems [i].transform.DOScaleY (0f, 0f);
		}
		                                 
	}

	public GameObject levelupEffectPanel;
	IEnumerator Start () {
		backFade.DOFade (1f, 0.5f).SetEase (Ease.Linear);
		yield return new WaitForSeconds (0.5f);
		levelupEffectPanel.SetActive (true);
	}

	public void InAnimation () {
		StartCoroutine (InAnimationCo ());
	}

	IEnumerator InAnimationCo () {
		decoCenter.gameObject.SetActive (true);
		decoCenter.DOSizeDelta (new Vector2 (sizeCenter.x, sizeCenter.y), 0.1f).SetEase (Ease.InOutCubic);
		yield return new WaitForSeconds (0.03f);
		decoRight.DOSizeDelta (new Vector2 (sizeRight.x, sizeRight.y), 0.1f).SetEase (Ease.InOutCubic);
		decoLeft.DOSizeDelta (new Vector2 (sizeLeft.x, sizeLeft.y), 0.1f).SetEase (Ease.InOutCubic);

		textUnlocked.DOFade (1f, 0.2f).SetEase(Ease.OutCubic);
		textUnlocked.transform.DOLocalMoveY (50f, 0.2f).SetRelative (true).SetEase(Ease.InOutCubic);
		yield return new WaitForSeconds (0.2f);
		for (int i = 0; i < unlockItems.Length; i++) {
			unlockItems [i].transform.DOScaleY (1f, 0.2f).SetEase(Ease.InOutCubic);
			yield return new WaitForSeconds (0.1f);
		}

		yield return new WaitForSeconds (2f);
		StartCoroutine (OutAnimationCo ());
	}

	public GameObject allGroup;
	IEnumerator OutAnimationCo () {
		allGroup.transform.DOScaleY (0f, 0.1f).SetEase (Ease.OutCubic);
		yield return new WaitForSeconds (0.1f);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.OutCubic).OnComplete (() => {
			Destroy (this.gameObject);
		});
		yield return null;
	}


	//void OnEnable () {
	//	backLight.DOFade (0f, 0f);

	//	for (int i = 0; i < medals.Length; i++) {
	//		medals [i].SetActive (false);
	//	}
	//}

	public void MedalActive () {
		backLight.DOFade (1f, 1f).SetEase (Ease.Linear);
		medals [PlayManager.Instance.medalCount].SetActive (true);
		PlayManager.Instance.medalCount++;
		
		if (PlayManager.Instance.medalCount > medals.Length-1) {
			Debug.Log (PlayManager.Instance.medalCount);
			
			PlayManager.Instance.medalCount = 0;
		}

	}

	void Update () {
		backLight.transform.DORotate (new Vector3(0f, 0f, -2f), 0.1f).SetRelative (true);
	}

}
