
//public var player : GameObject;
//private var player : RaycastHit;
function FixedUpdate ()
{
//if(this.collider2D.tag == "platform"){
	if(Input.GetKey (KeyCode.RightArrow))
		this.rigidbody2D.velocity = new Vector2 (5.0, 0.0);	
	
	if(Input.GetKey (KeyCode.LeftArrow))
		this.rigidbody2D.velocity = new Vector2(-5.0, 0.0);	
	
	if(Input.GetKey (KeyCode.UpArrow))
		this.rigidbody2D.velocity = new Vector2(0.0, 5.0);	//add rotational speed to rear wheel
//	}
}