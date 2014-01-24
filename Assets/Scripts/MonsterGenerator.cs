using UnityEngine;
using System.Collections;


public class MonsterGenerator : MonoBehaviour 
{
	public int maxNumbersOfMonsters;
	public int maxLevel;
	public float maxSpeed;
	public float minSpeed;
	public int maxHP;
	public int minHP;
	public int numbersOfGeneratePoint;
	public Vector3[] generatePos = new Vector3[this.numbersOfGeneratePoint];
	public GameObject zombie;

	private int recentNumbersOfMonsters;
	private int recentLevel;
	private int generatedMonsters;
	private bool generateMonster;
	
	// Use this for initialization
	void Start () 
	{
		recentLevel = 0;
		recentNumbersOfMonsters = 0;
		generateMonster = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (recentNumbersOfMonsters == 0) 
		{
			recentLevel++;
			generateMonster = true;
			generatedMonsters = 0;
		}
		if (generateMonster) 
		{
			Vector3 recentGeneratePos = generatePos[Random.Range(0, numbersOfGeneratePoint - 1)];

			Instantiate(zombie, recentGeneratePos, Quaternion.identity);

			generatedMonsters++;
		}
		if (generatedMonsters == maxNumbersOfMonsters) 
		{
			generateMonster = false;
		}
	}

	int GetHP()
	{
		return minHP + ((maxHP - minHP) / maxLevel) * recentLevel;
	}

	float GetSpeed()
	{
		return minSpeed + ((maxSpeed - minSpeed) / (float)maxLevel) * recentLevel;
	}
	void Die()
	{
		recentNumbersOfMonsters--;
	}
}
