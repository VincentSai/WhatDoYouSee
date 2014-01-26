using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

//	public Rigidbody2D bullet;
	public float speed = 3f;
	private Transform mTransform;
	private float mLastFireTime = 0f;
	public float delay = 0.5f;
	public int bulletAmount = 20;

	void Start () {
		mTransform = transform;
	}

	IEnumerator UseItem (Vector2 direction) {
		if(Time.time - mLastFireTime < delay)
		{
			yield break;
		}
		mLastFireTime = Time.time;

		GameObject bulletInstance = Instantiate(gameObject, mTransform.position, Quaternion.identity) as GameObject;
		bulletInstance.layer = 9;
		bulletInstance.renderer.enabled = true;
		Rigidbody2D bullectRigid = bulletInstance.AddComponent<Rigidbody2D>();
		bullectRigid.gravityScale = 0;
		bullectRigid.fixedAngle = true;
		bullectRigid.isKinematic = true;
		bulletInstance.collider2D.enabled = true;
		bulletInstance.collider2D.isTrigger = false;
		bullectRigid.velocity = (direction * 20000).normalized * speed;
		Destroy(bulletInstance, 2);

		bulletAmount -= 1;
		if(bulletAmount <= 0)
		{
			mTransform.root.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
		}
		renderer.enabled = false;
		yield return new WaitForSeconds(delay - (Time.time - mLastFireTime));
		renderer.enabled = true;
	}

	void PlayGetItemSound () {
		SoundManager.instance.PlayAudioWithName("biggun");
	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
