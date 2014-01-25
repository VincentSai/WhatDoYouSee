using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour 
{
	public int widthOfGround;
	public int heightOfGraund;
	public GameObject item;
	public float zombieDropRate;
	public float firstItemAppearTime;
	public float itemGenerateTimeInterval;

	private const int numbersOfAttribute = 3;

	private const int numbersOfTextures = 7;	
	public GameObject candy;
	public GameObject chair;
	public GameObject pillow;
	public GameObject stethoscope;
	public GameObject apple;
	public GameObject orange;
	public GameObject pizza;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("GenerateItem", firstItemAppearTime, itemGenerateTimeInterval);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void GenerateItem()
	{
		GameObject tempItem, tempTexture;
		string tempAttribute;
		Vector2 randomPos = new Vector2(Random.Range (0, widthOfGround-1), Random.Range (0, heightOfGraund-1));
		int randomAttribute = Random.Range (0, numbersOfAttribute);
		int randomTexture = Random.Range (0, numbersOfTextures);

		switch (randomAttribute) 
		{
		case 0:
			tempAttribute = "Gun";
			break;
		case 1:
			tempAttribute = "Bomb";
			break;
		case 2:
			tempAttribute = "Food";
			break;
		default:
			tempAttribute = "Gun";
			break;
		}
		switch (randomTexture) 
		{
		case 0:
			tempTexture = candy;
			break;
		case 1:
			tempTexture = chair;
			break;
		case 2:
			tempTexture = pillow;
			break;
		case 3:
			tempTexture = stethoscope;
			break;
		case 4:
			tempTexture = apple;
			break;
		case 5:
			tempTexture = orange;
			break;
		case 6:
			tempTexture = pizza;
			break;
		default:
			tempTexture = candy;
			break;
					
		}


		tempItem = (GameObject)Instantiate (tempTexture, randomPos, Quaternion.identity);
		tempItem.AddComponent(tempAttribute);


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

		if(probability >= zombieDropRate)
			Instantiate (item, Pos, Quaternion.identity);
	}
}
