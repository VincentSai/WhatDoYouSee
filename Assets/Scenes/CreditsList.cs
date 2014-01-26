using UnityEngine;
using System.Collections;

public class CreditsList : MonoBehaviour {

	public Texture Exit;

	void Start()
	{

	}
	
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width * 9 / 10, Screen.height * 9 / 10, Screen.width, Screen.height), Exit))
			Application.LoadLevel ("MainMenu");
	}
}
