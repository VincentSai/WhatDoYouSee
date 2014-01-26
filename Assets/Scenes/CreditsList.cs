using UnityEngine;
using System.Collections;

public class CreditsList : MonoBehaviour {
	
	public Texture Credits;
	public Texture Exit;
	public GUIStyle textStyle;
	public Rect programmer;
	public Rect voiceAndArtist;
	public Rect animator3D;

	
	void OnGUI()
	{
		GUI.TextArea ( programmer, "Programmer :\n\n Play\nVincent\nQiFen", textStyle);
		GUI.TextArea ( voiceAndArtist, "Voice&Artist :\n\nBob", textStyle);
		GUI.TextArea ( animator3D, "3D Animator :\n\nPlay", textStyle);
		
		if (GUI.Button (new Rect (Screen.width * 9 / 10, Screen.height * 9 / 10, Screen.width, Screen.height), Exit))
			Application.LoadLevel ("MainMenu");
	}
}
