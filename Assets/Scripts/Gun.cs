using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public float speed = 3;
	private Transform mTransform;
	private Vector3 dir;
	private float time;
	private Vector3 originalPos;

	void Start () {
		mTransform = transform;
	}

	void UseItem (Vector2 direction) {
		dir.x = direction.x;
		dir.y = direction.y;
		dir.z = 0;
		dir *= 20000;
		dir.Normalize ();
		originalPos = transform.parent.position;
		transform.parent = null;
		StartCoroutine (Shoot());
	}
	IEnumerator Shoot()
	{
		time = 0;
		while (true) 
		{
			time += Time.deltaTime;
			mTransform.position =originalPos + dir * speed * time;
			if(time >= 2.0f) 
			{
				RemoveItem();
				yield break;
			}
			yield return null;
		}
	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
