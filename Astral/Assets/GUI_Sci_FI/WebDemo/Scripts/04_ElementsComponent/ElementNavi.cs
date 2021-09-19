using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElementNavi : MonoBehaviour {

	public Button naviButton_01;
	public Button naviButton_02;
	public Button naviButton_03;
	public Button naviButton_04;


	public void Start () {
		if (naviButton_01 != null)
			naviButton_01.onClick.AddListener (() => { Navi_01 (); });

		if (naviButton_02 != null)
			naviButton_02.onClick.AddListener (() => { Navi_02 (); });

		if (naviButton_03 != null)
			naviButton_03.onClick.AddListener (() => { Navi_03 (); });

		if (naviButton_04 != null)
			naviButton_04.onClick.AddListener (() => { Navi_04 (); });
	}

	public GameObject onIcon;

	public void Navi_01 () {
		onIcon.transform.SetParent (naviButton_01.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}

	public void Navi_02 () {
		onIcon.transform.SetParent (naviButton_02.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}

	public void Navi_03 () {
		onIcon.transform.SetParent (naviButton_03.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}

	public void Navi_04 () {
		onIcon.transform.SetParent (naviButton_04.transform, false);
		onIcon.transform.localPosition = Vector3.zero;
	}
}
