using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour 
{
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		SendMessage ("MoveToTarget", player.transform.position);
	}
}
