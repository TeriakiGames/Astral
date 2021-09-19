using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TitleController : MonoBehaviour {

	//Bottom Menu Bar
	public GameObject imgButtom;
	public GameObject startButton;
	public Text textStart;
	private Color textActiveColor;
	public Color dimColor;

	//Top Side Menu
	public Image buttonCamera;
	public Image buttonGoogle;
	public Image buttonTwitter;
	public Image buttonFaceBook;

	public Image imageTitle;

	public GameObject topButtonGroup;

	void Awake () {
		Application.targetFrameRate = 60;

		PlayManager.Instance.InIt ();

		imgButtom.transform.DOLocalMoveY (-800, 0).SetRelative (true);
		startButton.transform.DOLocalMoveY (-700, 0).SetRelative (true);
		textActiveColor = textStart.color;
		textStart.color = dimColor;

		topButtonGroup.transform.DOLocalMoveY (800, 0).SetRelative (true);
		buttonCamera.DOFade (0f, 0f);
		buttonGoogle.DOFade (0f, 0f);
		buttonTwitter.DOFade (0f, 0f);
		buttonFaceBook.DOFade (0f, 0f);

		imageTitle.DOFade (0f, 0f);

		if (PlayManager.Instance._isFirstPlay)
			imageTitle.transform.DOLocalMoveY (0f, 0f);
	}

	void Start () {
		StartCoroutine (InAnimation ());
	}

	//In Animation
	IEnumerator InAnimation () {
		//Title Image Fade
		if (PlayManager.Instance._isFirstPlay)
			yield return new WaitForSeconds (1.5f);

		imageTitle.DOFade (1f, 2f).SetEase (Ease.Linear);

		if (PlayManager.Instance._isFirstPlay) {
			PlayManager.Instance._isFirstPlay = false;
			imageTitle.transform.DOLocalMoveY (90f, 1f).SetEase (Ease.InOutQuart).SetRelative (true).SetDelay (3f);
			yield return new WaitForSeconds (3.7f);
		}

		//Start Bottom Mennu Animation
		StartCoroutine (BottomMenuInAnimation ());

		//Start TopMenue Animation
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (TopMenueInAnimation ());
	}

	IEnumerator BottomMenuInAnimation () { 
		imgButtom.transform.DOLocalMoveY (800, 0.3f).SetEase (Ease.InOutCubic).SetRelative (true);
		yield return new WaitForSeconds (0.15f);
		startButton.transform.DOLocalMoveY (700, 0.25f).SetRelative (true);
		yield return new WaitForSeconds (0.35f);
		textStart.DOColor (new Color (textActiveColor.r, textActiveColor.g, textActiveColor.b, 1f), 0.5f).SetEase (Ease.OutCubic);
		startButton.transform.SetAsLastSibling ();
	}

	IEnumerator TopMenueInAnimation () {
		yield return null;
		topButtonGroup.transform.DOLocalMoveY (-800, 0f).SetRelative (true);
		buttonCamera.DOFade (1f, 1f).SetEase (Ease.OutExpo);//.SetDelay(Random.Range(0.1f, 0.2f));
		buttonGoogle.DOFade (1f, 1f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
		buttonTwitter.DOFade (1f, 1f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
		buttonFaceBook.DOFade (1f, 1f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
	}

	//OutAnimation
	IEnumerator OutAnimation (string name) {
		yield return null;
		//Title Image Fade
		imageTitle.DOKill ();
		imageTitle.DOFade (0f, 0.3f).SetEase (Ease.Linear);

		//Start TopMenue Animation
		StartCoroutine (TopMenuOutAnimation (name));
		
		//Start Bottom Mennu Animation
		StartCoroutine (BottomMenuOutAnimation ());
	}

	IEnumerator BottomMenuOutAnimation () {
		startButton.transform.SetAsFirstSibling ();
		startButton.transform.DOLocalMoveY (-500, 0.2f).SetEase(Ease.InOutCubic).SetRelative (true);
		yield return new WaitForSeconds (0.1f);
		imgButtom.transform.DOLocalMoveY (-800, 0.3f).SetEase (Ease.InOutCubic).SetRelative (true);
	}

	IEnumerator TopMenuOutAnimation (string name) {
		yield return null;
		buttonCamera.DOFade (1f, 0.3f).SetEase (Ease.OutExpo);//.SetDelay(Random.Range(0.1f, 0.2f));
		buttonGoogle.DOFade (1f, 0.3f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
		buttonTwitter.DOFade (1f, 0.3f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
		buttonFaceBook.DOFade (1f, 0.3f).SetEase (Ease.OutExpo);//.SetDelay (Random.Range (0.1f, 0.2f));
		yield return new WaitForSeconds (0.3f);
		topButtonGroup.transform.DOLocalMoveY (800, 0f).SetRelative (true);
		yield return new WaitForSeconds (0.5f);

		if (name == "element") {
			PlayManager.Instance.SceneLoad (GlobalDefines.SCENE_COMPONENT);
			
		} else if(name == "stage"){ 
			PlayManager.Instance.SceneLoad (GlobalDefines.SCENE_STAGE);
		}
	}



	#region - Panel Load!!!

	public GameObject panelMessage;
	public GameObject panleShop;
	public GameObject panleQuests;
	public GameObject panleSettings;

	public GameObject panelLogin;

	public Transform panelTransform;

	public void MenuMessage () {
		LoadPanel (panelMessage, panelMessage.name);
	}

	public void MenuShop () { 
		LoadPanel (panleShop, panleShop.name);
	}

	public void MenuQuests () { 
		LoadPanel (panleQuests, panelMessage.name);
	}

	public void MenuSettings () { 
		LoadPanel (panleSettings, panleSettings.name);
	}

	public void LoginFacebook () { 
		LoadPanel (panelLogin, panelLogin.name);
		
	}

	public void Elements () { 
		StartCoroutine (OutAnimation ("element"));
		
	}

	public void StartButton () {
		StartCoroutine (OutAnimation ("stage"));

	}

	private GameObject activePopup;
	void LoadPanel (GameObject panel, string name) { 
		GameObject panels = (GameObject) Instantiate (panel, new Vector3 (0f, 60f, 0f), Quaternion.identity);
		panels.transform.SetParent (panelTransform, false);
		activePopup = panels;
		panels.name = name;
	}

	#endregion


}
