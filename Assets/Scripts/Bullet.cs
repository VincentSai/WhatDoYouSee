using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () 
	{
		Destroy(gameObject, 2);
	}
}
