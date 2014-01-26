using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private enum eControlState
	{
		WaitingForTouch,
		Holding
	}


	public int life = 1;
	public Transform itemPosition;
	private Vector2 mDirection = -Vector2.up;
	public GUITexture fireButton;
	private eControlState mMoveControlState;
	private eControlState mFireControlState;
	private Vector2 mMoveTouchStartPosition;
	private int mMoveTouchId = -1;
	private int mFireTouchId = -1;

	void Awake () {
		Playing.SetStaticPlayer (gameObject);
		Playing.life = life;
	}

	void Start () {
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
		{
			fireButton.enabled = false;
		}
		else
		{
			fireButton.enabled = true;
		}
	}

	void FixedUpdate () {
		Vector2 direction = Vector2.zero;

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8)
		int maxTouchCount = 2;
		int touchCount = 0;
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase == TouchPhase.Began)
			{
				if(fireButton.HitTest(touch.position))
				{
					mFireControlState = eControlState.Holding;
					mFireTouchId = touch.fingerId;
				}
				else
				{
					mMoveControlState = eControlState.Holding;
					mMoveTouchStartPosition = touch.position;
					mMoveTouchId = touch.fingerId;
				}
			}
			if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				if(touch.fingerId == mMoveTouchId)
				{
					mMoveControlState = eControlState.WaitingForTouch;
					mMoveTouchId = -1;
				}
				if(touch.fingerId == mFireTouchId)
				{
					mFireControlState = eControlState.WaitingForTouch;
					mFireTouchId = -1;
				}
			}
			if(mMoveTouchId == touch.fingerId && mMoveControlState == eControlState.Holding)
			{
				if((touch.position - mMoveTouchStartPosition).magnitude > 30f)
				{
					direction = touch.position - mMoveTouchStartPosition;
				}
				else
				{
					direction = Vector2.zero;
				}
			}
			if(mFireTouchId == touch.fingerId && mFireControlState == eControlState.Holding)
			{
				BroadcastMessage("UseItem", mDirection, SendMessageOptions.DontRequireReceiver);
			}
			touchCount++;
			if(touchCount > maxTouchCount)
			{
				break;
			}
		}
#elif UNITY_EDITOR
		direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif
		if(direction.magnitude > 0)
		{
			mDirection = direction;
		}
		SendMessage("MoveToDirection", direction, SendMessageOptions.DontRequireReceiver);
	}

#if UNITY_EDITOR
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			BroadcastMessage("UseItem", mDirection, SendMessageOptions.DontRequireReceiver);
		}
	}
#endif

	void OnTriggerEnter2D(Collider2D other) {
		other.SendMessage("OnPlayerTouch", gameObject, SendMessageOptions.DontRequireReceiver);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(enabled && other.transform.tag == "Zombie")
		{
			Damage(1);
		}
	}

	void Damage (int damage) {
		life = life - damage;
		Playing.life = life;
		if(life <= 0)
		{
			SendMessage("Dead", SendMessageOptions.DontRequireReceiver);
		}
	}

	void GetItem (Transform item) {
		itemPosition.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
		item.parent = itemPosition;
		item.localPosition = Vector3.zero;
	}

	IEnumerator Dead () {
		enabled = false;
		itemPosition.BroadcastMessage("RemoveItem", SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(3);
		Application.LoadLevel("End");
	}

	IEnumerator BecomeSuperMan()
	{
		SendMessage("SetSpeed", 6f, SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(3);
		SendMessage("SetSpeed", 3f, SendMessageOptions.DontRequireReceiver);
	}
}
