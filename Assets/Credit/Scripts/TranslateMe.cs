using UnityEngine;
using System.Collections;

public class TranslateMe : MonoBehaviour {

	Transform thisTransform;
	public Vector3 offset;
	
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (thisTransform.position.z > 20) {
			thisTransform.Translate(offset * Time.deltaTime);
		}
	}

	void OnGUI1() {
		GUILayout.Label(""+thisTransform.position.z);
	}
}
