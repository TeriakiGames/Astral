using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour {
	public Button buttonOn;
	public Button buttonOff;
	public GameObject onIcon;
	
	public void Start () {
		if (buttonOn != null)
			buttonOn.onClick.AddListener (() => { OnClick (); });

		if (buttonOff != null)
			buttonOff.onClick.AddListener (() => { OffClick (); });
	}


	public void OnClick () {
		onIcon.transform.SetParent (buttonOn.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}

	public void OffClick () { 
		onIcon.transform.SetParent (buttonOff.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}

}
