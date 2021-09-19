using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeBarControl : MonoBehaviour {

	public Slider slider;
	public Scrollbar scrollbar;
	
	public void ScrollBarValueChange () {
		slider.value = scrollbar.value;
	}



}
