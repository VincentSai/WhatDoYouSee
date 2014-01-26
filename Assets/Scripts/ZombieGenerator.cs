using UnityEngine;
using System.Collections;


public class ZombieGenerator : MonoBehaviour 
{
	public int maxNumbersOfMonsters;
	private int maxLevel;
	public float maxSpeed;
	public float minSpeed;
	public int maxHP;
	public int minHP;
	public Vector2[] generatePos = new Vector2[4];
	public GameObject zombie;
	public float firstZombieAppearTime;
	public float zombieGenerateTimeInterval;
	public Texture2D arrowTexture;
	private ArrayList zombieList = new ArrayList();
	private ArrayList rectList = new ArrayList();

	private int recentNumbersOfMonsters;
	private int recentLevel;
	private int generatedMonsters;
	private bool generateMonster;
	private bool isStartGenerateMonster;
	private Vector2 mMinLimit;
	private Vector2 mMaxLimit;

	class PivotRect {
		public Rect rect;
		public Vector2 pivot;
		public float angle;

		public PivotRect (Rect rect, Vector2 pivot, float angle){
			this.rect = rect;
			this.pivot = pivot;
			this.angle = angle;
		}
	}

	// Use this for initialization
	void Start () 
	{
		maxLevel = Playing.maxLevel;
		recentLevel = 1;
		recentNumbersOfMonsters = 0;
		generateMonster = true;
		isStartGenerateMonster = false;
		mMinLimit = Vector2.zero;
		mMaxLimit = new Vector2(Screen.width - arrowTexture.width, Screen.height - arrowTexture.height);
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
			Playing.recentLevel = recentLevel;
			generateMonster = true;
			generatedMonsters = 0;

		}
		int inVisibleIndex = 0;
		foreach(Transform tempZombie in zombieList)
		{
			if(!tempZombie.renderer.isVisible)
			{
				inVisibleIndex++;
				if(rectList.Count < inVisibleIndex)
				{
					rectList.Add(GetPivotRect(tempZombie));
				}
				else
				{
					rectList[inVisibleIndex - 1] = GetPivotRect(tempZombie);
				}
			}
		}
	}

	PivotRect GetPivotRect (Transform target) {
		Vector2 size = new Vector2(arrowTexture.width, arrowTexture.height);
		Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
		Rect rect = new Rect(Mathf.Clamp(pos.x - size.x * 0.5f, mMinLimit.x, mMaxLimit.x), Mathf.Clamp(Screen.height - pos.y - size.y * 0.5f, mMinLimit.y, mMaxLimit.y), size.x, size.y);

		Vector2 pivot = new Vector2(rect.xMin + rect.width * 0.5f, rect.yMin + rect.height * 0.5f);
		return new PivotRect(rect, pivot, Vector2.Angle(target.position, Playing.player.transform.position));
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
		zombieList.Add(tempZombie.transform);
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
	void Die(Transform deadZombie)
	{
		zombieList.Remove(deadZombie);
		recentNumbersOfMonsters--;
	}

	void OnGUI() {
		if (Event.current.type.Equals(EventType.Repaint))
		{
			int index = 0;
			foreach(PivotRect pivotRect in rectList)
			{
//				Matrix4x4 matrixBackup = GUI.matrix;

//				GUIUtility.RotateAroundPivot(pivotRect.angle, pivotRect.pivot);
				GUI.DrawTexture(pivotRect.rect, arrowTexture);
//				GUI.matrix = matrixBackup;
				index++;
				if(index >= zombieList.Count)
				{
					break;
				}
			}
		}
	}
}
