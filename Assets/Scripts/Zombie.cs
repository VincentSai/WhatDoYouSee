using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {
	
	public GameObject player;
	public GameObject monsterGenerator;

	private short healthPoint;
	public float speed;
	
	void Start () 
	{
		healthPoint = monsterGenerator.GetHP ();
		speed = monsterGenerator.GetSpeed ();
	}
	
	void Update () 
	{
		if (healthPoint <= 0)
			monsterGenerator.Die ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		AIscript isWeapons = other.gameObject.GetComponent<Weapons>();
		if (isWeapons)
		{
			heartPoint--;
		}
		Debug.Log("WeaponsZombies");
	}
	
}
