using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public GameObject bullet;
	void UseItem () {

	}

	void RemoveItem () {
		Destroy(gameObject);
	}
}
