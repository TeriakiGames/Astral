using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class WebDemoController : MonoBehaviour {
	
	[HideInInspector]
	public List<WebDemoButton> webDemoButtons = new List<WebDemoButton> ();
	public GameObject textBox;

	public Color activeColor;
	public Color pressColor;
	public Color defultColor;

	void Start () {
		PlayManager.Instance._WebDemoController = GetComponent<WebDemoController> ();
		DontDestroyOnLoad (this.gameObject);

		foreach (Transform t in transform) {
			webDemoButtons.Add (t.GetComponent<WebDemoButton> ());
			//PlayManager.Instance.demoButton.Add(t.GetComponent<WebDemoButton> ());
		}
	}

	public void TextColorReset () {
		for (int i = 0; i < webDemoButtons.Count; i++) {
			if (!webDemoButtons [i]._isActive){
				webDemoButtons [i].CheckAllReset ();
			}
		}
	}

	public void AllReset () {
		for (int i = 0; i < webDemoButtons.Count; i++) {
			webDemoButtons [i].AllReset ();
		}
	}
}
