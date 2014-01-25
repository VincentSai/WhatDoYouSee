using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	private Rigidbody2D mRigidbody2D;
	private Transform mTransform;
	public float maxSpeed = 5f;
	private bool mFacingRight = false;
	private Animator mAnimator;

	void Awake () {
		mRigidbody2D = rigidbody2D;
		mTransform = transform;
		mAnimator = GetComponent<Animator>();
	}

	void MoveToDirection (Vector2 direction) {
		mRigidbody2D.velocity = Vector2.ClampMagnitude(direction * maxSpeed, maxSpeed);
		if(mAnimator)
		{
			mAnimator.SetFloat("speed", mRigidbody2D.velocity.magnitude);
		}
		if(mRigidbody2D.velocity.x > 0 && !mFacingRight)
		{
			Flip();
		}
		else if(mRigidbody2D.velocity.x < 0 && mFacingRight)
		{
			Flip();
		}
		if(Mathf.Max(Mathf.Abs(mRigidbody2D.velocity.x), Mathf.Abs(mRigidbody2D.velocity.y)) == Mathf.Abs(mRigidbody2D.velocity.y))
		{
			mAnimator.SetInteger("upDown", (mRigidbody2D.velocity.y > 0) ? 1 : -1);
		}
		else
		{
			mAnimator.SetInteger("upDown", 0);
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

	void Dead () {
		if(Mathf.Max(Mathf.Abs(mRigidbody2D.velocity.x), Mathf.Abs(mRigidbody2D.velocity.y)) == Mathf.Abs(mRigidbody2D.velocity.y))
		{
			mAnimator.SetInteger("upDown", (mRigidbody2D.velocity.y > 0) ? 1 : -1);
		}
		else
		{
			mAnimator.SetInteger("upDown", 0);
		}
		if(mRigidbody2D.velocity.x > 0 && !mFacingRight)
		{
			Flip();
		}
		else if(mRigidbody2D.velocity.x < 0 && mFacingRight)
		{
			Flip();
		}
		mAnimator.SetBool("dead", true);
	}

	void GetItem () {
		mAnimator.SetBool("weapon", true);
	}

	void UseItem () {
		mAnimator.SetTrigger("fire");
	}

	void RemoveItem () {
		mAnimator.SetBool("weapon", false);
	}
}
