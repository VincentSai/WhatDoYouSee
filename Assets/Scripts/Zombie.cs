using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour 
{

	private Transform mTransform;
	private MonsterGenerator monsterGenerator;

	private short healthPoint;
	
	void Start () 
	{
		monsterGenerator = GetComponent<MonsterGenerator>();
		healthPoint = monsterGenerator.GetHP ();
		SendMessage("SetSpeed" ,monsterGenerator.GetSpeed ());

		mTransform = transform;
	}
	
	void Update () 
	{
		if (healthPoint <= 0)
		{
			monsterGenerator.Die ();
			SendMessage("GenerateObject", mTransform.position);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == weapons)
		{
			heartPoint--;
		}
	}
	
}
