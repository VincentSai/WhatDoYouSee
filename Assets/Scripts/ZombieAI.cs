using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour 
{
	public Transform transform;
	public GameObject zombie;
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 dir;

		dir = player.transform.position - this.transform.position;
		dir.Normalized ();

		this.transform.position = new Vector2 (this.transform.position.x + dir.x * zombie.speed,
		                                      this.transform.position.y + dir.y * zombie.speed);
	}
}
