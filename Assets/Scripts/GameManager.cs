using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static GameObject player;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetStaticPlayer(GameObject inPlayer)
	{
		player = inPlayer;
	}
}
