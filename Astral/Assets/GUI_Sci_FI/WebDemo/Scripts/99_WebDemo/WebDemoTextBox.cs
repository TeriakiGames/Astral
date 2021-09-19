using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class WebDemoTextBox : MonoBehaviour {

	public Text myText;
	public GameObject myTextBox;
	private float boxSize;
	public Image imageArrow;

	void OnEnable () {
		StartCoroutine (ArrowScale ());
	}

	public void OnTextBox (Transform transform, string buttonName) {
		this.gameObject.transform.SetParent (transform, false);
		myText.text = MyNums (buttonName);
		myTextBox.GetComponent<RectTransform> ().sizeDelta = new Vector2(boxSize, 83f);
		myTextBox.SetActive (true);
	}

	public void OffTextBox () {
		myTextBox.SetActive (false);
	}

	public string MyNums (string buttonName) {
		string sceneName = "";
		boxSize = 150f;

		switch (buttonName) {
			case "01_Title": sceneName = "Title"; 										break;
			case "02_Login": sceneName = "Login"; 										break;
			case "03_Stage": sceneName = "Stage"; 										break;
			case "04_StageStart": sceneName = "Stage Start"; boxSize = 190f; 			break;
			case "05_Complete": sceneName = "Complete"; boxSize = 180f;					break;
			case "06_Levelup": sceneName = "Level Up"; boxSize = 180f;					break;
			case "07_Achievements": sceneName = "Achievements"; boxSize = 230f; 		break;
			case "08_ShopCoin": sceneName = "Shop Coin"; boxSize = 190f; 				break;
			case "09_ShopGem": sceneName = "Shop Gem"; boxSize = 190f; 					break;
			case "10_ShopLife": sceneName = "Shop Life"; boxSize = 190f; 				break;
			case "11_Item": sceneName = "Item"; 										break;
			case "12_Message": sceneName = "Message"; boxSize = 180f;					break;
			case "13_Setting": sceneName = "Setting"; boxSize = 180f; 					break;
			case "14_Pause": sceneName = "Pause";										break;
			case "15_Icons": sceneName = "Icons";										break;
			case "16_Rank": sceneName = "Rank";											break;
			case "17_FunctionButton": sceneName = "Function Button"; boxSize = 230f;	break;
			case "18_ActionText": sceneName = "Action Text"; boxSize = 190f; 			break;
			case "19_Component": sceneName = "Component"; boxSize = 190f; 				break;
			case "20_Popup": sceneName = "Popup";										break;
		}
		return sceneName;
	}

	IEnumerator ArrowScale () {
		while (true) {
			imageArrow.transform.DOScaleX (0f, 0.25f).SetEase (Ease.InCubic);
			yield return new WaitForSeconds (0.25f);
			imageArrow.transform.DOScaleX (1f, 0.25f).SetEase (Ease.OutCubic);
			yield return new WaitForSeconds (0.25f);
		}
	}
}
