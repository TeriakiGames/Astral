using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {

	private Slider slider;
	private Text loadingCount;

	void Start () {
		loadingCount = transform.Find ("txt_loading").GetComponent<Text>();
		slider = GetComponent<Slider> ();
		StartCoroutine (TimeCheck ());
	}

	private bool _isMax = false;
	private bool _isStop = false;
	void Update () {
		if (!_isStop) {
			if (Time.timeScale == 1) {
				if (!_isMax) {
					if (slider.value >= 100) {
						_isMax = true;
						_isStop = true;
						slider.value = 100;
						loadingCount.text = "LOADING..." + slider.value.ToString () + "%";
					} else {
						slider.value += 1f;
						loadingCount.text = "LOADING..." + slider.value.ToString () + "%";
					}
				} else {
					if (slider.value <= 0) {
						_isMax = false;
						_isStop = true;
						slider.value = 0;
						loadingCount.text = "LOADING..." + slider.value.ToString () + "%";
					} else {
						slider.value -= 1f;
						loadingCount.text = "LOADING..." + slider.value.ToString () + "%";
					}
				}
			}
		}
	}

	IEnumerator TimeCheck () {
		while (true) {
			if (_isStop) {
				yield return new WaitForSeconds (0.5f);
				_isStop = false;
			}
			yield return null;
		}
	}
}
