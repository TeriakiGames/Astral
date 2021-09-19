using UnityEngine;
using System.Collections;

public class DemoBackgrounLoad : MonoBehaviour {

	void Awake () {
		if (!PlayManager.Instance._isDemoBarOn && GameObject.Find("Canvas_WebDemo") == null) {
			PlayManager.Instance._isDemoBarOn = true;
			GameObject demobar = (GameObject) Instantiate (Resources.Load ("Canvas_WebDemo"), new Vector3 (0f, 60f, 0f), Quaternion.identity);
			demobar.name = "Canvas_WebDemo";
		}

		if (!PlayManager.Instance._isBackgroundOn && GameObject.Find ("Camera_Background") == null) {
			PlayManager.Instance._isBackgroundOn = true;
			GameObject backgrond = (GameObject) Instantiate (Resources.Load("Camera_Background"), new Vector3 (0f, 60f, 0f), Quaternion.identity);
			backgrond.name = "Camera_Background";
		}
	}
}
