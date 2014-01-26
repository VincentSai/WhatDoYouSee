using UnityEngine;
using System.Collections;

public class Playing : MonoBehaviour 
{
	
	public static GameObject player;
	public static int score;
	public static int maxLevel = 10;
	public static int recentLevel;
	public Texture[] lifeTex = new Texture[4];
	public static int life;
	public GUIStyle style;
	// Use this for initialization
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		score++;
		if (recentLevel == maxLevel) 
		{
			Application.LoadLevel("End");	
		}

	}
	void OnGUI()
	{
		GUI.DrawTexture (new Rect(0, 0, 100, 10), lifeTex[life]);
		GUI.TextArea (new Rect(Screen.width * 9/10, 0, Screen.width, Screen.height*1/10), score.ToString(), style);
	}
	public static void SetStaticPlayer(GameObject inPlayer)
	{
		player = inPlayer;
	}
	public static void IncreaseScore(int inScore)
	{
		score += inScore;
	}
}
