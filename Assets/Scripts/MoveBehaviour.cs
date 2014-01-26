using UnityEngine;
using System.Collections;

public class MoveBehaviour : MonoBehaviour {

	public float Speed;
	public float Jump;
	private Vector2 velocity = new Vector2(0.0f,0.0f);
	private bool CanJump = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 vInput = new Vector2(0.0f,0.0f);

		if(Input.GetKey(KeyCode.LeftArrow)){
			velocity.x = -Speed;
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			velocity.x = Speed; 
		}
		else velocity.x = this.rigidbody2D.velocity.x;

		if(CanJump && Input.GetKeyDown(KeyCode.UpArrow)){
			velocity.y = Jump; 
			CanJump = false;
		}
		else {
			velocity.y = this.rigidbody2D.velocity.y;
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
