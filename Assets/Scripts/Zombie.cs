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
	
//	void Update () 
//	{
//		if (healthPoint <= 0)
//		{
//			//monsterGenerator.SendMessage("Die");
//			SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
//			SendMessage("GenerateItem", mTransform.position, SendMessageOptions.DontRequireReceiver);
//		}
//	}

	IEnumerator Dead () {
		yield return new WaitForSeconds(0.5f);
		Destroy(gameObject);
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
	//Detect Bullet
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Weapons")
		{
			healthPoint--;
		}
		if (healthPoint <= 0)
		{
			monsterGenerator.SendMessage("Die", transform, SendMessageOptions.DontRequireReceiver);
			SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
			SendMessage("GenerateItem", mTransform.position, SendMessageOptions.DontRequireReceiver);
		}
	}
//	//Detect Bomb
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.gameObject.tag == "Weapons")
//		{
//			healthPoint--;
//		}
//	}
	void SubHealth()
	{
		healthPoint--;
		if (healthPoint <= 0)
		{
			monsterGenerator.SendMessage("Die", transform, SendMessageOptions.DontRequireReceiver);
			SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
			SendMessage("GenerateItem", mTransform.position, SendMessageOptions.DontRequireReceiver);
		}
	}
}
