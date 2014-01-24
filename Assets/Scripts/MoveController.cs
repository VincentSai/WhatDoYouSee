using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	private Rigidbody2D mRigidbody2D;
	private Transform mTransform;
	public float maxSpeed = 5f;
	private bool mFacingRight = true;

	void Start () {
		mRigidbody2D = rigidbody2D;
		mTransform = transform;
	}

	void MoveToDirection (Vector2 direction) {
		mRigidbody2D.velocity = Vector2.ClampMagnitude(direction * maxSpeed, maxSpeed);

		if(mRigidbody2D.velocity.x > 0 && !mFacingRight)
		{
			Flip();
		}
		else if(mRigidbody2D.velocity.x < 0 && mFacingRight)
		{
			Flip();
		}
	}

	void MoveToTarget (Transform target) {
		Vector2 direction = target.position - mTransform.position;
		MoveToDirection(direction);
	}

	void Flip ()
	{
		mFacingRight = !mFacingRight;

		Vector3 theScale = mTransform.localScale;
		theScale.x *= -1;
		mTransform.localScale = theScale;
	}

	void SetSpeed (float speed) {
		maxSpeed = speed;
	}
}
