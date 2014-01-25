using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int life = 1;
	public Transform itemPosition;
	private Vector2 mDirection = -Vector2.up;

	{
		GameManager.SetStaticPlayer (gameObject);
	}

	void FixedUpdate () {
		Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if(direction.magnitude > 0)
		{
			mDirection = direction;
		}
		SendMessage("MoveToDirection", direction, SendMessageOptions.DontRequireReceiver);
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			BroadcastMessage("UseItem", mDirection, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		other.SendMessage("OnPlayerTouch", gameObject, SendMessageOptions.DontRequireReceiver);
	}

	void Damage (int damage) {
		life = life - damage;
		if(life <= 0)
		{
			SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
		}
	}

	void GetItem (Transform item) {
		itemPosition.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
		item.parent = itemPosition;
		item.localPosition = Vector3.zero;
	}

	void Dead () {
		//dead
	}
}
