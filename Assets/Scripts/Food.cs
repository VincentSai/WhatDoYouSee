using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {


	void UseItem (Vector2 direction) {
		transform.root.BroadcastMessage("BecomeSuperMan", SendMessageOptions.DontRequireReceiver);
		transform.root.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
	}

	void PlayGetItemSound () {
		SoundManager.instance.PlayAudioWithName("holylight");
	}
  
	void RemoveItem () {
		Destroy(gameObject);
	}
}
