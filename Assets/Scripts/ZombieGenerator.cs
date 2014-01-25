using UnityEngine;
using System.Collections;


public class ZombieGenerator : MonoBehaviour 
{
	public int maxNumbersOfMonsters;
	public int maxLevel;
	public float maxSpeed;
	public float minSpeed;
	public int maxHP;
	public int minHP;
	public Vector2[] generatePos = new Vector2[4];
	public GameObject zombie;
	public float firstZombieAppearTime;
	public float zombieGenerateTimeInterval;

	private int recentNumbersOfMonsters;
	private int recentLevel;
	private int generatedMonsters;
	private bool generateMonster;
	private bool isStartGenerateMonster;
	
	// Use this for initialization
	void Start () 
	{
		recentLevel = 1;
		recentNumbersOfMonsters = 0;
		generateMonster = true;
		isStartGenerateMonster = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//When Zombie all dead, Level Up.
		if (generateMonster) 
		{
			if (!isStartGenerateMonster)
			{
				// Generate one Zombie per two second 
				InvokeRepeating("GenerateZombie", firstZombieAppearTime, zombieGenerateTimeInterval);
				isStartGenerateMonster = true;

			} else if(generatedMonsters == maxNumbersOfMonsters)
			{
				CancelInvoke("GenerateZombie");
				isStartGenerateMonster = false;
				generateMonster = false;
			}
		} else if (recentNumbersOfMonsters == 0 && !generateMonster) 
		{
			recentLevel++;
			generateMonster = true;
			generatedMonsters = 0;

		}
	}
	void GenerateZombie()
	{
		//Random Select a Generate Pint
		Vector3 recentGeneratePos = generatePos[Random.Range(0, 3)];
		GameObject tempZombie;
		//make a new zombie and initialize
		tempZombie = (GameObject)Instantiate(zombie, recentGeneratePos, Quaternion.identity);
		tempZombie.SendMessage("SetHP",GetHP());
		tempZombie.SendMessage("SetZombieSpeed",GetSpeed());
		tempZombie.SendMessage ("SetZombieGenerator", gameObject);

		generatedMonsters++;
		recentNumbersOfMonsters++;

	}
	int GetHP()
	{
		//Linear Intorpolation for HP
		//return minHP + ((maxHP - minHP) / maxLevel) * recentLevel;

		//Fixed HP
		return 1;
	}

	float GetSpeed()
	{
		//Linear Intorpolation for Speed
		return minSpeed + ((maxSpeed - minSpeed) / (float)maxLevel) * (recentLevel-1);
	}
	void Die()
	{
		recentNumbersOfMonsters--;
	}
}
