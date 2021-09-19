using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

	private Color defultColor;
	private Text text;

	public void Start () {
		text = transform.Find ("Item_Name").GetComponent<Text> ();
		defultColor = text.color;
	}

	public void OnPointerExit (PointerEventData data) {
		text.color = defultColor;
	}

	public void OnPointerUp (PointerEventData data) {
		text.color = defultColor;
	}

	public void OnPointerDown (PointerEventData data) {
		text.color = Color.white;
	}
}
