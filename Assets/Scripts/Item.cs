using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public GameObject attribute;

	void OnPlayerTouch (GameObject player) {
		collider2D.enabled = false;
		SendMessage("PlayGetItemSound", SendMessageOptions.DontRequireReceiver);
		player.SendMessage("GetItem", transform, SendMessageOptions.DontRequireReceiver);
		Destroy(this);
	}
}
