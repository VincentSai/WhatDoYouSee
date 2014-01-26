using UnityEngine;
using System.Collections;

public class BombEffect : MonoBehaviour {

	public GameObject bomb;

	void Bomb (Vector3 position) {
		Destroy(Instantiate(bomb, position, Quaternion.identity), 0.5f);
	}
}
