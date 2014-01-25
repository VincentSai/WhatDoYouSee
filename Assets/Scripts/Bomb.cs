using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float speed = 3;
	private Transform mTransform;
	private float time;
	private Vector3 bombDir;
	private Vector3 originalPos;
	private bool isBom = false;
	
	void Start () 
	{
		mTransform = transform;
	}
	
	void UseItem (Vector2 direction) 
	{
		bombDir.x = direction.x*2000;
		bombDir.y = direction.y*2000;
		bombDir.z = 0;
		bombDir.Normalize ();
		originalPos = transform.parent.position;
		//InvokeRepeating ("ThrowBomb", 0, 0.01f);
		StartCoroutine (ThrowBomb ());
	}

	IEnumerator ThrowBomb () {
		time = 0;
		while(true)
		{
			if(!isBom)
				mTransform.position = Vector2.Lerp (originalPos, 
			                                    originalPos+bombDir*speed, time);
			if (time >= 1.0f && !isBom) 
			{
				collider2D.enabled = true;
				transform.parent = null;
				isBom = true;
				time = 0;
			}
			if(isBom && time >= 0.3)
			{
				RemoveItem();
			}
			time += Time.deltaTime;
			yield return null;
		}
	}
	/*
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
		}
	}*/
	void RemoveItem () 
	{
		Destroy(gameObject);
	}
}
