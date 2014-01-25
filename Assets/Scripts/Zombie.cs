using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour 
{

	private Transform mTransform;
	private GameObject monsterGenerator;

	private int healthPoint;

	void Start () 
	{
		mTransform = transform;
	}
	
	void Update () 
	{
		if (healthPoint <= 0)
		{
			monsterGenerator.SendMessage("Die");
			SendMessage("GenerateItem", mTransform.position, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
	public void SetHP( int HP )
	{
		healthPoint = HP;
	}
	public void SetZombieSpeed( float speed )
	{
		SendMessage("SetSpeed" ,speed);
	}
	public void SetZombieGenerator(GameObject inMonsterGenerator)
	{
		monsterGenerator = inMonsterGenerator;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Weapons")
		{
			healthPoint--;
		}
	}
	
}
