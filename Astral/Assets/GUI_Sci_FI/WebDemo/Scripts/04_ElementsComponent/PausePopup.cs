using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour {

	public Image imagePause;
	public Image fadeImage;

	public GameObject buttonRestart;
	public GameObject buttonResum;
	public GameObject buttonExit;
	public Image buttonSettings;

	public Image titleDeco;
	private ElementsComponentController _ElementsComponentController;

	void Awake () {
		//FadeImage
		fadeImage.DOFade (0f, 0f);

		//TextPause &
		imagePause.DOFade (0f, 0f);
		imagePause.transform.DOLocalMoveY (-50f, 0f).SetRelative (true);

		//Middle Line
		titleDeco.DOFade (0f, 0f);
		titleDeco.GetComponent<RectTransform> ().DOSizeDelta (new Vector2 (0f, 79f), 0f);

		//Buttons
		buttonRestart.transform.DOScaleY (0f, 0f);
		buttonResum.transform.DOScaleY (0f, 0f);
		buttonExit.transform.DOScaleY (0f, 0f);
		buttonSettings.DOFade (0f, 0f);

		//Time.timeScale = 0;
	}

	void Start () {
		_ElementsComponentController = GameObject.FindWithTag ("ElementsComponentController").GetComponent<ElementsComponentController> ();
		OpenAnimation ();
	}

	void OpenAnimation () {

		//FadeImage
		fadeImage.DOFade (1f, 0.5f).SetEase (Ease.OutCubic).SetUpdate(true);

		transform.DOMoveX (0f, 0.3f).SetRelative (true).SetUpdate (true).OnComplete (() => {
			//Middle Line
			titleDeco.DOFade (1f, 0.2f).SetUpdate (UpdateType.Normal, false).SetUpdate (true);
			titleDeco.GetComponent<RectTransform> ().DOSizeDelta (new Vector2 (920f, 79f), 0.15f).SetUpdate (true);

			//TextPause
			imagePause.transform.DOLocalMoveY (50f, 0.15f).SetRelative (true).SetDelay (0.1f).SetUpdate (true);
			imagePause.DOFade (1f, 0.3f).SetDelay (0.1f).SetUpdate (true);

			transform.DOMoveX (0f, 0.15f).SetRelative (true).SetUpdate (true).OnComplete (() => {
				//Buttons
				buttonRestart.transform.DOScaleY (1f, 0.15f).SetEase (Ease.OutCubic).SetUpdate (true);
				buttonResum.transform.DOScaleY (1f, 0.15f).SetEase (Ease.OutCubic).SetDelay (0.05f).SetUpdate (true);
				buttonExit.transform.DOScaleY (1f, 0.15f).SetEase (Ease.OutCubic).SetDelay (0.1f).SetUpdate (true);

			});
		});
	}

	void CloseAnimation (bool _goTitle) {
		//Buttons
		buttonRestart.transform.DOScaleY (0f, 0.15f).SetEase (Ease.OutCubic).SetDelay(0.1f).SetUpdate (true);
		buttonResum.transform.DOScaleY (0f, 0.15f).SetEase (Ease.OutCubic).SetDelay(0.05f).SetUpdate (true);
		buttonExit.transform.DOScaleY (0f, 0.15f).SetEase (Ease.OutCubic).SetUpdate (true);

		//TextPause
		imagePause.DOFade (0f, 0.2f).SetUpdate (true);
		imagePause.transform.DOLocalMoveY (-50f, 0.15f).SetRelative (true).SetDelay (0.1f).SetUpdate (true);

		transform.DOMoveX (0f, 0.1f).SetRelative (true).SetUpdate (true).OnComplete (() => {
			//Middle Line
			titleDeco.DOFade (0f, 0.1f).SetUpdate (true);
			titleDeco.GetComponent<RectTransform> ().DOSizeDelta (new Vector2 (0f, 79f), 0.1f).SetUpdate (true);

			//FadeImage
			Time.timeScale = 1;
			fadeImage.DOFade (0f, 0.3f).SetEase (Ease.OutCubic).OnComplete (() => {
				if (!_goTitle)
					Destroy (this.gameObject);
				else
					_ElementsComponentController.ClickBack ();

			}).SetDelay (0.1f).SetUpdate (true);
		});
	}

	public void ClickRestart_Resume () {
		CloseAnimation (false);
	}

	public void ClickExit () {
		CloseAnimation (true);
	}
}
