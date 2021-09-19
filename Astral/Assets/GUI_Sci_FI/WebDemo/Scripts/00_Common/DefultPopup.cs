using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class DefultPopup : MonoBehaviour {

	public Image backFade;
	public GameObject popupPanel;
	public ScrollRect scroll;
	public bool _inScrollPanel = false;
	public bool _DropAimation = false;

	void Awake () {
		if (_inScrollPanel) { 
			scroll.enabled = false;
		}

		if (!_DropAimation) {
			popupPanel.transform.DOScale (new Vector3 (1f, 0f, 1f), 0f);
			backFade.DOFade (0f, 0f);
		} else { 
			backFade.DOFade (0f, 0f);
			popupPanel.transform.DOLocalMoveY (1000f, 0f).SetRelative (true);
		}
	}

	IEnumerator Start () {
		if (!_DropAimation) {
			backFade.DOFade (1f, 0.5f).SetEase (Ease.Linear);
			yield return new WaitForSeconds (0.3f);
			popupPanel.transform.DOScaleY (1f, 0.2f).SetEase (Ease.OutBack);
		} else { 
			backFade.DOFade (1f, 0.5f).SetEase (Ease.Linear);
			yield return new WaitForSeconds (0.3f);
			popupPanel.transform.DOLocalMoveY (-1000f, 0.3f).SetRelative (true).SetEase(Ease.OutBack);
		}

		if (_inScrollPanel) { 
			yield return new WaitForSeconds (0.2f);
			scroll.enabled = true;
		}
	}

	public void ClosePanel () {
		if (!_DropAimation) {
			popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
			backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
				if (_goComplete) {
					GameObject.FindWithTag ("StageController").GetComponent<StageController> ().OutAnimations (GlobalDefines.SCENE_COMPLETE);
				}
				Destroy (this.gameObject);
			});
		} else { 
			popupPanel.transform.DOLocalMoveY (1000f, 0.2f).SetEase (Ease.InBack).SetRelative(true);
			backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
				Destroy (this.gameObject);
			});
		}
	}

	private bool _isClose = false;
	public void SinglePopup () {
		if (!_isClose) {
			_isClose = true;

			popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
			backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
				GameObject popup = (GameObject) Instantiate (Resources.Load ("20_Panel_99_Popup_MultiButton"), new Vector3 (0f, 0f, 0f), Quaternion.identity);
				popup.transform.SetParent (transform.parent, false);
				popup.name = "20_Panel_99_Popup_MultiButton";

				Destroy (this.gameObject);
			});
		}
	}

	public void RankPopup () { 
		if (!_isClose) {
			_isClose = true;
			popupPanel.transform.DOScaleY (0f, 0.2f).SetEase (Ease.InBack);
			backFade.DOFade (0f, 0.2f).SetEase (Ease.Linear).OnComplete (() => {
				GameObject popup = (GameObject) Instantiate (Resources.Load ("16_Panel_08_Rank"), new Vector3 (0f, 0f, 0f), Quaternion.identity);
				popup.transform.SetParent (transform.parent, false);
				popup.name = "16_Panel_08_Rank";

				Destroy (this.gameObject);
			});
		}
	}

	public bool _goComplete = false;

	public void ButtonStart () {
		_goComplete = true;
		ClosePanel ();
	}

}
