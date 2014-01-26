using UnityEngine;
using System.Collections;

public class CreditsList : MonoBehaviour {

	public Texture returns;

	
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width * 8 / 10, Screen.height * 9 / 10, Screen.width*2/10, Screen.height*1/10), returns))
			Application.LoadLevel ("MainMenu");
	}
}
