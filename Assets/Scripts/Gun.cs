using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D bullet;
	public float speed = 2;
	public float delay = 0.5f;
	private Transform mTransform;
	private float mLastFireTime = 0f;

	void Start () {
		mTransform = transform;
	}

	void UseItem (Vector2 direction) {
		if(Time.time - mLastFireTime < delay)
		{
			return;
		}
		mLastFireTime = Time.time;
		Rigidbody2D bulletInstance = Instantiate(bullet, mTransform.position, Quaternion.identity) as Rigidbody2D;
		bulletInstance.velocity = direction.normalized * speed;
	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
