using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler {

	private bool _isButtonDown = false;
	private bool _isDragOn = false;
	public bool _isSwitchOn = false;

	public Color onColor;
	public Color offColor;

	public Text textOn;
	public Text textOff;

	public GameObject imageHandle;


	public void OnPointerDown (PointerEventData data) {
		_isButtonDown = true;
	}

	public void OnPointerUp (PointerEventData data) {
		if (!_isDragOn) {
			SwitchChange ();
		} else {
			SwitchCheck ();
			_isDragOn = false;
		}
	}


	public Transform onPos;
	public Transform offPos;

	public void OnDrag (PointerEventData data) {
		_isDragOn = true;
		if (_isButtonDown) {
			Vector3 pos = Input.mousePosition;
			pos.x = Mathf.Clamp (pos.x, offPos.position.x, onPos.position.x);
			pos.y = imageHandle.transform.position.y;
			imageHandle.transform.position = pos;

			Debug.Log (imageHandle.transform.localPosition.x);
			if (imageHandle.transform.localPosition.x < 0) {
				_isSwitchOn = false;
				textOn.color = offColor;
				textOff.color = onColor;
			} else if (imageHandle.transform.localPosition.x > 0) {
				_isSwitchOn = true;
				textOn.color = onColor;
				textOff.color = offColor;
			}
		}
	}

	public void SwitchCheck () {
		if (_isSwitchOn) {
			textOn.color = onColor;
			textOff.color = offColor;
			imageHandle.transform.DOMoveX (onPos.position.x, 0.1f).SetEase (Ease.InOutCubic);
		} else {
			textOn.color = offColor;
			textOff.color = onColor;
			imageHandle.transform.DOMoveX (offPos.position.x, 0.1f).SetEase (Ease.InOutCubic);
		}
	}

	public void SwitchChange () {
		if (_isSwitchOn) {
			_isSwitchOn = false;
			textOn.color = offColor;
			textOff.color = onColor;
			imageHandle.transform.DOMoveX (offPos.position.x, 0.1f).SetEase (Ease.InOutCubic);
		} else {
			_isSwitchOn = true;
			textOn.color = onColor;
			textOff.color = offColor;
			imageHandle.transform.DOMoveX (onPos.position.x, 0.1f).SetEase (Ease.InOutCubic);
		}
	}
}
