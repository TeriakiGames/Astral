using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClickFalse : MonoBehaviour, IPointerClickHandler {

	public bool _isParent = false;
	public bool _isComplete = false;

	public void OnPointerClick (PointerEventData data) {
		if (!_isComplete) {
			if (!_isParent) {
				this.gameObject.SetActive (false);
			} else {
				transform.parent.gameObject.SetActive (false);
			}
		} else {
			transform.parent.Find ("Complete").gameObject.SetActive (true);
			transform.gameObject.SetActive (false);
		}


	}

}
