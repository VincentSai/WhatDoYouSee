using UnityEngine;
using System.Collections;

public class RotateMe : MonoBehaviour {

	Transform thisTransform;
	public Vector3 angles;

	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		thisTransform.Rotate(angles);
	}
}
