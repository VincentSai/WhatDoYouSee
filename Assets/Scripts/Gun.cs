using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D bullet;
	public float speed;
	private Transform mTransform;

	void Start () {
		mTransform = transform;
	}

	void UseItem (Vector2 direction) {
		Rigidbody2D bulletInstance = Instantiate(bullet, mTransform.position, Quaternion.identity) as Rigidbody2D;
		bulletInstance.velocity = direction.normalized * speed;
	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
