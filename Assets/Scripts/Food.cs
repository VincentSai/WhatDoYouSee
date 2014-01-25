using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {


	void UseItem (Vector2 direction) {
		GameManager.player.SendMessage ("BecomeSuperMan");
		RemoveItem ();
	}
	
	void RemoveItem () {
		Destroy(gameObject);
	}
}
