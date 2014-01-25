using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {


	void UseItem (Vector2 direction) {
		GameManager.player.gameObject.SendMessage ("BecomeSuperMan");
		RemoveItem ();
	}

	void PlayGetItemSound () {
		SoundManager.instance.PlayAudioWithName("holylight");
	}
  
	void RemoveItem () {
		Destroy(gameObject);
	}
}
