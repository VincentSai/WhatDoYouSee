using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour 
{
	public GameObject attribute;

	void Start()
	{

	}

	void OnPlayerTouch (GameObject player) {
		collider2D.enabled = false;
		player.SendMessage("GetItem", transform, SendMessageOptions.DontRequireReceiver);
		Destroy(this);
	}
}
