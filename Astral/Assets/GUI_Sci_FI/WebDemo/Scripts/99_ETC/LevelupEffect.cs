using UnityEngine;
using System.Collections;

public class LevelupEffect : MonoBehaviour {

	public LevelupPopup _LevelupPopup;

	public void InAnimation () {
		_LevelupPopup.InAnimation ();
	}

	public void MedalActive () {
		_LevelupPopup.MedalActive ();
	}
}
