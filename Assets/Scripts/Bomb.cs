using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float speed = 3;
	public float radius = 1.5f;
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
		gameObject.tag = "Weapons";
		bombDir.x = direction.x*2000;
		bombDir.y = direction.y*2000;
		bombDir.z = 0;
		bombDir.Normalize ();
		originalPos = transform.parent.position;
		transform.parent = null;
		//InvokeRepeating ("ThrowBomb", 0, 0.01f);
		StartCoroutine (ThrowBomb ());
	}

	void PlayGetItemSound () {
		int index = (Random.Range(0, 100) % 3) + 1;
		SoundManager.instance.PlayAudioWithName("bomb" + index.ToString());
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
				isBom = true;
				time = 0;
				Collider2D[] targets;
				targets = Physics2D.OverlapCircleAll((Vector2)mTransform.position, radius);
				foreach(Collider2D target in targets)
				{
					target.SendMessage("SubHealth", SendMessageOptions.DontRequireReceiver);
				}
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
