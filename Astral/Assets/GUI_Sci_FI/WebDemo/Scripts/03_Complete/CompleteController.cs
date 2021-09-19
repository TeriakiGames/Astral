using UnityEngine;
using System.Collections;

public class CompleteController : MonoBehaviour {

	public GameObject completePopup;

	void Start () {
		GameObject panel = (GameObject) Instantiate (completePopup, new Vector3(0f, 60f, 0f), Quaternion.identity);
		panel.transform.SetParent (transform, false);
		panel.name = completePopup.name;
	}



}
