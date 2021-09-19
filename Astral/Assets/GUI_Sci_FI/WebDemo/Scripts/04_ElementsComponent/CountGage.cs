using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class CountGage : MonoBehaviour {

	private List<Image>gages = new List<Image>();

	void Start () {
		foreach (Transform t in transform) {
			gages.Add (t.gameObject.GetComponent<Image>());
		}

		foreach (Image g in gages) {
			g.DOFade (0f, 0f);
			
		}
		StartCoroutine (GageAnim ());
	}

	private bool _isMax = false;
	IEnumerator GageAnim () {
		yield return new WaitForSeconds (Random.Range (0f, 0.7f));
		while (true) {
			if (!_isMax) {
				for (int i = 0; i < gages.Count; i++) {
					yield return new WaitForSeconds (0.05f);
					gages [i].DOKill ();
					gages [i].DOFade (1f, 0f);
				}
				yield return new WaitForSeconds (Random.Range (0f, 0.5f));
				_isMax = true;
			} else {
				for (int i = gages.Count-1; i > 0-1; i--) {
					yield return new WaitForSeconds (0.05f);
					gages [i].DOKill ();
					gages [i].DOFade (0f, 0f).SetEase (Ease.InCubic);
				}
				yield return new WaitForSeconds (Random.Range (0f, 0.5f));
				_isMax = false;
			}
			yield return null;
		}
	}

}
