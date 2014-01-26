using UnityEngine;
using System.Collections;

public class MoveBehaviour : MonoBehaviour {

	public float Speed;
	public float Jump;
	public bool movementEnabled = false;
	private Vector2 velocity = new Vector2(0.0f,0.0f);
	private bool CanJump = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(movementEnabled && Input.GetKey(KeyCode.LeftArrow)){
			velocity.x = -Speed;
		}
		else if(movementEnabled && Input.GetKey(KeyCode.RightArrow)){
			velocity.x = Speed; 
		}
		else velocity.x = this.rigidbody2D.velocity.x;

		if(movementEnabled && CanJump && Input.GetKeyDown(KeyCode.UpArrow)){
			velocity.y = Jump; 
			CanJump = false;
		}
		else {
			velocity.y = this.rigidbody2D.velocity.y;
		}

		Transform child = this.gameObject.transform.Find ("render_player_hack1");
		if (child != null)
		{
			if (Mathf.Abs (velocity.x) > 0.05f) {
				if (velocity.x < 0) {
					Vector3 s = child.localScale;
					s.x = -0.45f;
					child.localScale = s;
					Vector3 t = child.localPosition;
					t.x = -0.52f;
					child.localPosition = t;
				} else if (velocity.x > 0) {
					Vector3 s = child.localScale;
					s.x = 0.45f;
					child.localScale = s;
					Vector3 t = child.localPosition;
					t.x = 0.52f;
					child.localPosition = t;
				}
			}
		}
		child = this.gameObject.transform.Find ("render_player_hack2");
		if (child != null)
		{
			if (Mathf.Abs (velocity.x) > 0.05f) {
				if (velocity.x < 0) {
					Vector3 s = child.localScale;
					s.x = -0.45f;
					child.localScale = s;
					Vector3 t = child.localPosition;
					t.x = -0.75f;
					child.localPosition = t;
				} else if (velocity.x > 0) {
					Vector3 s = child.localScale;
					s.x = 0.45f;
					child.localScale = s;
					Vector3 t = child.localPosition;
					t.x = 0.75f;
					child.localPosition = t;
				}
			}
		}
	}
	void  OnCollisionEnter2D(Collision2D collision)
	{
		CanJump = true;
	}

	void FixedUpdate()
	{
			this.rigidbody2D.velocity = velocity;
	}
}
