using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Gage : MonoBehaviour {

	private Slider slider;
	void Start () {
		slider = GetComponent<Slider> ();
	}

	bool _isMax = false;
	void Update () {
		if (Time.timeScale == 1) { 
				if (!_isMax) {
				if (slider.value >= 1) {
					_isMax = true;
					slider.value = 1;
				} else {
					slider.value += 0.01f;
				}
			} else {
				if (slider.value <= 0) {
					_isMax = false;
					slider.value = 0;
				} else {
					slider.value -= 0.01f;
				}
			}
		}
	
	}
}
