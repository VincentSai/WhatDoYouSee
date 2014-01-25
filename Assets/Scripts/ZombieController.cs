using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{	
	// Update is called once per frame
	void FixedUpdate () 
	{
		SendMessage ("MoveToTarget", GameManager.player.transform, SendMessageOptions.DontRequireReceiver);
	}

	void Dead () {
		enabled = false;
	}
}
