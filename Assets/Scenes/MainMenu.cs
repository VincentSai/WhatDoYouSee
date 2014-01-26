using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture[] aTexture = new Texture[4];
	void OnGUI() 
	{
		//background
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), aTexture[0]);

		//Start
		if( GUI.Button( new Rect( (Screen.width * (1.0f / 10.0f)), Screen.height * 2.0f/ 4.0f + ( Screen.height * 2 / 21 ), Screen.width / 5, ( Screen.height * 2 / 21 )), aTexture[1]))
		{
			Application.LoadLevel("Tutorial");
		}
		//Team member
		else if(GUI.Button(new Rect(Screen.width * 2 / 3, Screen.height / 3 + (Screen.height * 11 / 21 ), Screen.width / 3, (Screen.height * 3 / 21 )), aTexture[2]))
	    {
		    Application.LoadLevel("CreditsList");
	    }
		//Exit
		else if(GUI.Button(new Rect(Screen.width *1.0f / 10.0f, Screen.height * 3.0f / 4.0f + (Screen.height * 2 / 21 ), Screen.width / 5, (Screen.height * 2 / 21 )), aTexture[3]))
		{
			Application.Quit();
		}
	}
}
