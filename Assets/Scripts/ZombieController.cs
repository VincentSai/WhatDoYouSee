using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{	
	public bool randomWalk = false;
	public float timeToChangeDir;
	private Vector2 randomDir;
	private float time;

	void Start()
	{
		if(randomWalk) 
			StartCoroutine (RandomDir());
		timeToChangeDir = Random.Range (0.5f, timeToChangeDir);
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (randomWalk) 
		{
			SendMessage("MoveToDirection", randomDir.normalized/10.0f , SendMessageOptions.DontRequireReceiver);
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
				Debug.Log(3);
				randomDir = new Vector2(Random.Range(-10, 10)/10.0f, Random.Range(-10,10)/10.0f);
				time = 0;
			}
			yield return null;
		}
	}

	void Dead () {
		enabled = false;
	}
}
