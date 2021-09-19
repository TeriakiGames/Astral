using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WebDemoButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler{

	private WebDemoController _WebDemoController;
	private WebDemoTextBox _WebDemoTextBox;
	private bool _isOnPointer = false;
	public bool _isActive = false;
	private Text myText;

	void Start () {
		_WebDemoController = GameObject.FindWithTag ("WebDemoController").GetComponent<WebDemoController> ();
		_WebDemoTextBox = _WebDemoController.textBox.GetComponent<WebDemoTextBox>();
		myText = GetComponent<Text> ();
	}

	public void OnPointerEnter (PointerEventData data) {
		_isOnPointer = true;
		//ButtonReset ();
		myText.color = _WebDemoController.activeColor;
		_WebDemoTextBox.OnTextBox (transform, this.gameObject.name);
	}

	public void OnPointerDown (PointerEventData data) {
		ButtonReset ();
	}

	public void OnPointerExit (PointerEventData data) {
		_isOnPointer = false;
		
		if (_isActive) {
			SetActive ();
		} else {
			_WebDemoController.TextColorReset ();
			SetDefult ();
		}
		_WebDemoTextBox.OffTextBox ();
	}

	public void ButtonReset () {
		_WebDemoController.TextColorReset ();
		myText.color = _WebDemoController.pressColor;
	}

	public void OnPointerUp (PointerEventData data) {
		if (_isOnPointer) {
			PlayManager.Instance.SceneLoad (this.gameObject.name);
			SetActive ();
		} else {
			SetDefult ();
		}

		_isOnPointer = false;
	}

	//CheckAllReset
	public void CheckAllReset () {
		if (_isActive) {
			myText.color = _WebDemoController.activeColor;
		} else {
			myText.color = _WebDemoController.defultColor;
		}
	}

	//AllReset
	public void AllReset () { 
		_isOnPointer = false;
		_isActive = false;
		myText.color = _WebDemoController.defultColor;
	}


	//ButtonSettings;
	public void SetActive () {
		_WebDemoController.AllReset ();
		_isActive = true;
		myText.color = _WebDemoController.activeColor;
	}

	public void SetDefult () {
		_isActive = false;

		myText.color = _WebDemoController.defultColor;

	}


}
