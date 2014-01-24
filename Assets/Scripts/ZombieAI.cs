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
		Vector3 dir;

		dir = player.transform.position - this.transform.position;
		dir.Normalized ();

		this.transform.position = new Vector3 (this.transform.position.x + dir.x * zombie.speed,
		                                      0,
		                                      this.transform.position.z + dir.z * zombie.speed);
	}
}
