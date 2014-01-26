using UnityEngine;
using System.Collections;

public class CreditsList : MonoBehaviour {
	
	public Texture Credits;
	public Texture Exit;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), Credits);
		if (GUI.Button (new Rect (Screen.width * 9 / 10, Screen.height * 9 / 10, Screen.width, Screen.height), Exit))
			Application.LoadLevel ("MainMenu");
	}
}
