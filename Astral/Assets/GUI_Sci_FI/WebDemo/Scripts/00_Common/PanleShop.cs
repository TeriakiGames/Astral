using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PanleShop : MonoBehaviour {

	public GameObject[] pages;
	public GameObject [] buttonFocus;
	public Image backFade;
	public GameObject popupPanel;

	public ScrollRect scrollCoin;
	public ScrollRect scrollGem;

	void Awake () {
		scrollCoin.enabled = false;
		scrollGem.enabled = false;
		
		popupPanel.transform.DOScale (new Vector3 (1f, 0f, 1f), 0f);
		backFade.DOFade (0f, 0f);
	}

	IEnumerator Start () {
		backFade.DOFade (1f, 0.3f).SetEase (Ease.Linear);
		yield return new WaitForSeconds (0.15f);
		popupPanel.transform.DOScaleY (1f, 0.2f).SetEase (Ease.OutBack);
		yield return new WaitForSeconds (0.2f);

		scrollCoin.enabled = true;
		scrollGem.enabled = true;
	}

	public void TapButtonCoin () {
		ButtonChange (0);
	}

	public void TapButtonGem () { 
		ButtonChange (1);
	}

	public void TabButtonLife () { 
		ButtonChange (2);
	}

	public void ButtonChange (int num) { 
		for (int i = 0; i < buttonFocus.Length; i++) {
			buttonFocus [i].SetActive (false);
			pages [i].SetActive (false);
		}

		buttonFocus[num].SetActive (true);
		pages[num].SetActive (true);
	}

	public void ClosePanel () {
		popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
		backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
			Destroy (this.gameObject);
		});
	}
}
