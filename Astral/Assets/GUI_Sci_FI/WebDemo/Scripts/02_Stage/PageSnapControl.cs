using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PageSnapControl : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

	public GameObject leftButton;
	public GameObject rightButton;
	public GameObject onNaviIcon;
	public GameObject pageNavis;

	private int pageCount;
	private int pageNum;
	private ScrollRect scrollRect;
	private GameObject content;
	private Vector3 firstPos;
	private Vector3 endPos;
	private Vector2 contentPos = Vector2.zero;
	private List<GameObject> naviIcons = new List<GameObject> ();
	//private StageController _StageController;

	void Start () {
		//_StageController = GameObject.FindWithTag ("StageController").GetComponent<StageController>();

		scrollRect = GetComponent<ScrollRect> ();
		content = scrollRect.content.gameObject;
		pageCount = content.gameObject.transform.childCount;

		foreach (Transform t in pageNavis.transform) {
			naviIcons.Add (t.gameObject);
		}

		if (rightButton)
			rightButton.GetComponent<Button> ().onClick.AddListener (() => { MoveRight (); });

		if (leftButton)
			leftButton.GetComponent<Button> ().onClick.AddListener (() => { MoveLeft (); });
	}

	public void OnBeginDrag (PointerEventData data) {
		scrollRect.DOKill ();
		firstPos = Input.mousePosition;
	}

	public void OnEndDrag (PointerEventData data) {
		endPos = Input.mousePosition;
		float dist = Vector3.Distance (firstPos, endPos);

		if (dist > 300f) {
			if (endPos.x > firstPos.x) {
				MoveLeft ();
			} else {
				MoveRight ();
			}
		} else {
			PosCheck ();
		}
	}


	//public void ValueChange () { 
	//	for (int i = 0; i < _StageController._Stage.Length; i++) {
	//		_StageController._Stage [i].DefultSetting ();
	//	}
	//}

	private void MoveRight () {
		if (pageNum < pageCount - 1) {
			scrollRect.DOKill ();
			pageNum++;
			contentPos.x += 0.3333f;
			scrollRect.DOHorizontalNormalizedPos (contentPos.x, 0.45f).SetEase (Ease.OutCubic);
			NaviCheck ();
		}
	}

	private void MoveLeft () {
		if (pageNum > 0) {
			scrollRect.DOKill ();
			pageNum--;
			contentPos.x -= 0.3333f;
			scrollRect.DOHorizontalNormalizedPos (contentPos.x, 0.45f).SetEase (Ease.OutCubic);
			NaviCheck ();
		}
	}

	private void PosCheck () {
		scrollRect.DOHorizontalNormalizedPos (contentPos.x, 0.45f).SetEase (Ease.OutCubic);
		NaviCheck ();
	}

	private void NaviCheck () { 
		switch (pageNum) {
			case 0: NaviIcon_ButtonSetting (pageNum, false, true); break;
			case 1: NaviIcon_ButtonSetting (pageNum, true, true);  break;
			case 2: NaviIcon_ButtonSetting (pageNum, true, true);  break;
			case 3: NaviIcon_ButtonSetting (pageNum, true, false); break;
		}
	}

	private void NaviIcon_ButtonSetting (int posNum,  bool left, bool right) { 
		onNaviIcon.transform.SetParent (naviIcons [posNum].transform, false);
		onNaviIcon.transform.localPosition = Vector3.zero;
		rightButton.SetActive (right);
		leftButton.SetActive (left);
	}


}
