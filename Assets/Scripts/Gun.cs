using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

//	public Rigidbody2D bullet;
	public float speed;
	private Transform mTransform;
	private float mLastFireTime = 0f;
	public float delay = 0.5f;

	void Start () {
		mTransform = transform;
	}

	void UseItem (Vector2 direction) {
		if(Time.time - mLastFireTime < delay)
		{
			return;
		}
		GameObject bulletInstance = Instantiate(gameObject, mTransform.position, Quaternion.identity) as GameObject;
		Rigidbody2D bullectRigid = bulletInstance.AddComponent<Rigidbody2D>();
		bullectRigid.velocity = direction.normalized * speed;
		bullectRigid.gravityScale = 0;
		bullectRigid.fixedAngle = true;
		bullectRigid.isKinematic = true;
		bulletInstance.collider2D.enabled = true;
		bulletInstance.collider2D.isTrigger = false;
		bullectRigid.velocity = direction.normalized * speed;
		Destroy(bulletInstance, 2);
	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
