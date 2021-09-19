using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using DG.Tweening;

public class PlayManager : Singleton<PlayManager>
{
	public bool _isDemoBarOn = false;
	public bool _isBackgroundOn = false;
	public bool _isFirstPlay = true;
	public int medalCount = 0;

	public WebDemoController _WebDemoController;

	public void InIt () {}

	public bool _isButtonDown = false;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			if (mousepos.y > -4) {
				_isButtonDown = true;
			}
		} else if(Input.GetMouseButtonUp(0)){ 
				_isButtonDown = false;
		}
	}

	public void SceneLoad (string sceneName) {

		DOTween.KillAll();
		
		AsyncOperation async = SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Single);
		async.allowSceneActivation = false;

		if (async.progress < 0.9f) {
			async.allowSceneActivation = true;
		}
	}
}

