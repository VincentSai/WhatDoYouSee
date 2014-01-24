using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour 
{
	public int widthOfGround;
	public int heightOfGraund;
	public GameObject aObject;
	public float monsterDropRate;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("GenerateObject", 5.0f, 60.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void GenerateObject()
	{
		Vector2 randomPos = new Vector2(Random.Range (0, widthOfGround-1), Random.Range (0, heightOfGraund-1));

		Instantiate (aObject, randomPos, Quaternion.identity);
	}

	/***********************
	 * 
	 * 
	 * 	generate object with probability when monster dead.
	 * 
	 * 
	 * *********************/
	void GenerateObject( Vector2 Pos )
	{
		float probability = Random.Range (0, 100) / 100.0f;

		if(probability >= monsterDropRate)
			Instantiate (aObject, randomPos, Quaternion.identity);
	}
}
