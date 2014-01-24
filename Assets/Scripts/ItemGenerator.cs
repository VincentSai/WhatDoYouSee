using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour 
{
	public int widthOfGround;
	public int heightOfGraund;
	public GameObject item;
	public float ZombieDropRate;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("GenerateItem", 5.0f, 60.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void GenerateItem()
	{
		Vector2 randomPos = new Vector2(Random.Range (0, widthOfGround-1), Random.Range (0, heightOfGraund-1));

		Instantiate (item, randomPos, Quaternion.identity);
	}

	/***********************
	 * 
	 * 
	 * 	generate object with probability when monster dead.
	 * 
	 * 
	 * *********************/
	void GenerateItem( Vector2 Pos )
	{
		float probability = Random.Range (0, 100) / 100.0f;

		if(probability >= ZombieDropRate)
			Instantiate (item, Pos, Quaternion.identity);
	}
}
