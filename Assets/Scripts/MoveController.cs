using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	private CharacterController mController;
	private Transform mTransform;
	private float mSpeed = 1f;

	void Start () {
		mController = GetComponent<CharacterController>();
		mTransform = transform;
	}

	void MoveToDirection (Vector3 direction) {
		//animation.CrossFade("walk");
		transform.rotation = Quaternion.Slerp (mTransform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * mSpeed);
		mController.SimpleMove(direction);
	}

	void MoveToTarget (Transform target) {
		Vector3 direction = target.position - mTransform.position;
		//animation.CrossFade("walk");
		// Rotate towards the target
		transform.rotation = Quaternion.Slerp (mTransform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * mSpeed);
		
		// Modify speed so we slow down when we are not facing the target
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float speedModifier = Vector3.Dot(forward, direction.normalized);
		speedModifier = Mathf.Clamp01(speedModifier);
		
		// Move the character
		direction = forward * mSpeed * speedModifier;
		mController.SimpleMove(direction);
	}
}
