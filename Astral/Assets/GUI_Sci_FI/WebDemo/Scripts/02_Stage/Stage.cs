using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stage : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler{

	public Sprite defultBg;
	public Sprite activeBg;
	public Text myText;
	public Image starImage;

	private Color myStarDefultColor;
	private Image myImage;
	private StageController _StageController;
	private bool _isOn = false;
	
	void Awake () {
		_StageController = GameObject.FindWithTag("StageController").GetComponent<StageController>();
		myImage = GetComponent<Image> ();

		if (starImage != null)
			myStarDefultColor = starImage.color;
	}


	public void OnPointerDown (PointerEventData data) {
		_isOn = true;
	}

	public void OnPointerUp (PointerEventData data) {
		if (_isOn) {
			ActiveSetting ();
		}
	}

	public void OnPointerExit (PointerEventData data) {
		_isOn = false;
	}

	public void ActiveSetting () {
		for (int i = 0; i < _StageController._Stage.Length; i++) {
			_StageController._Stage [i].DefultSetting ();
		}

		myImage.sprite = activeBg;
		myText.color = Color.black;

		if (starImage != null)
			starImage.color = Color.black;
	}

	public void DefultSetting () {
		myImage.sprite = defultBg;
		myText.color = Color.white;

		if (starImage != null)
			starImage.color = myStarDefultColor;
	}
}
