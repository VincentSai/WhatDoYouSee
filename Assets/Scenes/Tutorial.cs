using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public Texture[] tutorialPages = new Texture[4];
	public int totalPage = 4;
	private int nowPageNumber;
	public float timeToChangePages;
	public float time;
	private bool willChangeLevel;
	// Use this for initialization
	void Start () 
	{
		nowPageNumber = 0;
		willChangeLevel = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;

		if (time >= timeToChangePages) 
		{
			if(willChangeLevel)
			{
				Playing.life = 3;
				Application.LoadLevel("Playing");
			}
			else
				nowPageNumber++;

			time = 0;
			if(nowPageNumber == totalPage-1)
			{
				willChangeLevel = true;
			}
		}

	}
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tutorialPages[nowPageNumber]);
	}
}
