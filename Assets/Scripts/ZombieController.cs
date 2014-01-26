using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{	
	public bool randomWalk = false;
	public float timeToChangeDir;
	private Vector2 randomDir;
	private float time;

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (randomWalk) 
		{
			StartCoroutine (RandomDir());
			SendMessage("MoveToDirection", randomDir , SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			SendMessage ("MoveToTarget", Playing.player.transform, SendMessageOptions.DontRequireReceiver);
		}
	}
	IEnumerator RandomDir()
	{
		time = 0;
		while (true) 
		{
			time += Time.deltaTime;

			if(time >= timeToChangeDir)
			{
				randomDir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
			}
		}
	}

	void Dead () {
		enabled = false;
	}
}
