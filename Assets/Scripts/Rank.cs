using UnityEngine;
using System.Collections;
using System;

public class Rank : MonoBehaviour {
	
	private float mCurrentScore;
	private int rank = -1;
	private float[] list;
	private Rect rect;
	private float firstY;
	public GUITexture texture;
	// Use this for initialization
	void Start () {
		mCurrentScore = Playing.score;
		Vector3 temp = Camera.main.ViewportToScreenPoint(new Vector3(0.1f, 0.25f, 0));
		firstY = temp.y;
		rect = new Rect(temp.x, firstY, 500, 100);
		texture.pixelInset = new Rect(-Screen.width * 0.5f, -Screen.height * 0.5f, Screen.width, Screen.height);
		Ranking();
	}
	
	void Ranking () {
		ArrayList tempList = new ArrayList {
			PlayerPrefs.GetFloat("ScoreNum1", 0f),
			PlayerPrefs.GetFloat("ScoreNum2", 0f),
			PlayerPrefs.GetFloat("ScoreNum3", 0f),
			PlayerPrefs.GetFloat("ScoreNum4", 0f),
			PlayerPrefs.GetFloat("ScoreNum5", 0f),
			PlayerPrefs.GetFloat("ScoreNum6", 0f),
			PlayerPrefs.GetFloat("ScoreNum7", 0f),
			PlayerPrefs.GetFloat("ScoreNum8", 0f),
			PlayerPrefs.GetFloat("ScoreNum9", 0f),
			PlayerPrefs.GetFloat("ScoreNum10", 0f)
		};

		tempList.Add(mCurrentScore);
		list = (float[])tempList.ToArray(typeof(float));
		Array.Sort(list);
		Array.Reverse(list);
		int index = 1;
		foreach(float score in list)
		{
			Debug.Log(score);
			if(score == 0 || index > 10)
			{
				break;
			}
			PlayerPrefs.SetFloat("ScoreNum" + index.ToString(), score);
			index++;
		}
		rank = Array.IndexOf(list, mCurrentScore);
	}

	void Update () {
		if(Input.anyKeyDown || Input.touchCount > 0)
		{
			Application.LoadLevel("MainMenu");
		}
	}

	void OnGUI () {
		int index = 1;
		rect.y = firstY;
		GUI.Label(rect, "Self rank is " + (rank + 1).ToString() + " : " + mCurrentScore.ToString());
		rect.y = 300;
		foreach(float score in list)
		{
			if(score == 0)
			{
				break;
			}
			GUI.Label(rect, index.ToString() + " : " + score.ToString());
			rect.y += 50;
			index++;
		}
	}

//	public int Compare(float x, float y)
//	{
//		return x.CompareTo(y);
//	}
}
