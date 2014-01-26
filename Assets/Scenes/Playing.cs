using UnityEngine;
using System.Collections;

public class Playing : MonoBehaviour 
{
	
	public static GameObject player;
	public static float score;
	public static int maxLevel = 10;
	public static int recentLevel;
	public Texture[] lifeTex = new Texture[4];
	public static int life;
	public GUIStyle style;
	private float time;

	// Use this for initialization
	void Start () 
	{
		score = 0;
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		score++;
		if (recentLevel == maxLevel)
		Debug.Log (life);
		if (recentLevel > maxLevel) 
		{
			score = Time.time - time;
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
	public static void IncreaseScore(float inScore)
	{
		score += inScore;
	}
}
