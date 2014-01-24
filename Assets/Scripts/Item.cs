using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	void OnPlayerTouch (GameObject player) {
		collider.enabled = false;
		player.SendMessage("GetItem", transform, SendMessageOptions.DontRequireReceiver);
		Destroy(this);
	}
}
