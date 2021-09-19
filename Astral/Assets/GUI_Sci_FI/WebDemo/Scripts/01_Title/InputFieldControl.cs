using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldControl : MonoBehaviour {

	public Image iconEmail;
	public Image iconPassword;

	public Color defultColor;
	public Color activeColor;

	public void ClickEmail () {
		if (passwordText.text == "") { 
			iconPassword.color = defultColor;
		}
		iconEmail.color = activeColor;
	}

	public void ClickPassword () {
		if (emailText.text == "") { 
			iconEmail.color = defultColor;
		}
		iconPassword.color = activeColor;
	}

	public InputField emailText;
	public InputField passwordText;

	public void InputCheck () {
		if (emailText.text == "") {
			iconEmail.color = defultColor;
		} 

		if (passwordText.text == "") {
			iconPassword.color = defultColor;
		}
	}


}
