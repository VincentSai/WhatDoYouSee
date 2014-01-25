using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float speed;
	private Transform mTransform;
	private float time;
	private Vector3 bombDir;
	private Vector3 originalPos;
	
	void Start () 
	{
		mTransform = transform;
	}
	
	void UseItem (Vector2 direction) 
	{
		time = 0;
		
		bombDir.x = direction.x*2000;
		bombDir.y = direction.y*2000;
		bombDir.z = 0;
		bombDir.Normalize ();
		originalPos = transform.parent.position;
		InvokeRepeating ("ThrowBomb", 0, 0.01f);

	}

	void ThrowBomb()
	{
		time += 0.01f;
		mTransform.position = Vector2.Lerp (originalPos, 
		                                    originalPos+bombDir*speed, time);
		if (time >= 1.0f) 
		{
			CancelInvoke ("ThrowBomb");
			Bom();
			InvokeRepeating("RemoveItem", 0.3f, 0);
			//mTransform.position = GameManager.player.transform.position;
		}
	}
	void Bom()
	{
		collider2D.enabled = true;
		transform.parent = null;
	}
	void RemoveItem () 
	{
		Destroy(gameObject);
	}
}
