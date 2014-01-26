using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float speed = 3;
	public float radius = 1.5f;
	public int bombCount = 3;
	public float delay = 0.5f;
	private Transform mTransform;
	private float time;
	private Vector2 bombDir;
	private Vector2 originalPos;
	private bool isBom = false;
	private float mLastFireTime = 0f;

	void Start () 
	{
		mTransform = transform;
	}
	
	IEnumerator UseItem (Vector2 direction) 
	{
		if(Time.time - mLastFireTime < delay)
		{
			yield break;
		}
		mLastFireTime = Time.time;
		gameObject.tag = "Weapons";
		bombDir.x = direction.x*2000;
		bombDir.y = direction.y*2000;
		bombDir.Normalize ();
		//originalPos = transform.parent.position;
		GameObject bombInstance = Instantiate(gameObject, mTransform.position, Quaternion.identity) as GameObject;
		bombInstance.SendMessage("ThrowBomb", bombDir, SendMessageOptions.DontRequireReceiver);
		bombCount -= 1;
		if(bombCount <= 0)
		{
			transform.root.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
		}
		renderer.enabled = false;
		yield return new WaitForSeconds(delay - (Time.time - mLastFireTime));
		renderer.enabled = true;
		//InvokeRepeating ("ThrowBomb", 0, 0.01f);
//		StartCoroutine (ThrowBomb ());
	}

	void PlayGetItemSound () {
		int index = (Random.Range(0, 100) % 3) + 1;
		SoundManager.instance.PlayAudioWithName("bomb" + index.ToString());
	}

	IEnumerator ThrowBomb (Vector2 direction) {
		if(!mTransform)
		{
			mTransform = transform;
		}
		originalPos = (Vector2)mTransform.position;
		time = 0;
		while(true)
		{
			if(!isBom)
				mTransform.position = Vector2.Lerp (originalPos, 
				                                    originalPos+direction*speed, time);
			if (time >= 1f) 
			{
				SoundManager.instance.SendMessage("Bomb", mTransform.position, SendMessageOptions.DontRequireReceiver);
				collider2D.enabled = true;
				isBom = true;
				Collider2D[] targets;
				targets = Physics2D.OverlapCircleAll((Vector2)mTransform.position, radius);
				foreach(Collider2D target in targets)
				{
					target.SendMessage("SubHealth", SendMessageOptions.DontRequireReceiver);
				}
				break;
			}
			time += Time.deltaTime;
			yield return null;
		}
		transform.root.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
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
