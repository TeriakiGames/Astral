using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StagePopup : MonoBehaviour {

	public Button itemButton_01;
	public Button itemButton_02;
	public Button itemButton_03;

	private bool _itemActive_01 = false;
	private bool _itemActive_02 = false;
	private bool _itemActive_03 = false;

	public Sprite buttonActiveBg;
	public Sprite buttonDefultBg;

	void Start () {
		if (itemButton_01 != null) 
			itemButton_01.GetComponent<Button> ().onClick.AddListener (() => { ButtonItem_01 (); });


		if (itemButton_02 != null)
			itemButton_02.GetComponent<Button> ().onClick.AddListener (() => { ButtonItem_02 (); });

		if (itemButton_03 != null)
			itemButton_03.GetComponent<Button> ().onClick.AddListener (() => { ButtonItem_03 (); });


	}

	public void ButtonItem_01 () {
		if (!_itemActive_01) {
			_itemActive_01 = true;
			itemButton_01.GetComponent<Image> ().sprite = buttonActiveBg;
		} else {
			_itemActive_01 = false;
			itemButton_01.GetComponent<Image> ().sprite = buttonDefultBg;
		}
	}

	public void ButtonItem_02 () {
		GameObject itemPopup = (GameObject) Instantiate (Resources.Load ("11_Panel_03_Item"), new Vector3 (0f, 0f, 0f), Quaternion.identity);
		itemPopup.transform.SetParent (transform.parent, false);
		itemPopup.name = "11_Panel_03_Item";
		                                                 
		                                                 

		//if (!_itemActive_02) {
		//	_itemActive_02 = true;
		//	itemButton_02.GetComponent<Image> ().sprite = buttonActiveBg;
		//} else {
		//	_itemActive_02 = false;
		//	itemButton_02.GetComponent<Image> ().sprite = buttonDefultBg;
		//}
	}

	public void ButtonItem_03 () {
		GameObject itemPopup = (GameObject) Instantiate (Resources.Load ("11_Panel_03_Item"), new Vector3 (0f, 0f, 0f), Quaternion.identity);
		itemPopup.transform.SetParent (transform.parent, false);
		itemPopup.name = "11_Panel_03_Item";

		//if (!_itemActive_03) {
		//	_itemActive_03 = true;
		//	itemButton_03.GetComponent<Image> ().sprite = buttonActiveBg;
			

		//} else {
		//	_itemActive_03 = false;
		//	itemButton_03.GetComponent<Image> ().sprite = buttonDefultBg;
		//}
	}


}
