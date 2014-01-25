private var colision : boolean;
private var x : int;
private var y : int;

function Start ()
{
	colision = false;
	x=0;
	y=0;
}

function OnCollisionEnter2D(coll: Collision2D) 
{
	colision = true;
}

function FixedUpdate (){
	Debug.Log(colision);
		if(Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.UpArrow) && colision){
			this.rigidbody2D.velocity = new Vector2 (7.0, 7.0);	
			colision = false;
		}
		
		if(Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.UpArrow) && colision){
			this.rigidbody2D.velocity = new Vector2 (-7.0, 7.0);	
			colision = false;
		}
			
		if(Input.GetKey (KeyCode.RightArrow) && colision)
			this.rigidbody2D.velocity = new Vector2 (7.0, y);	
	
		if(Input.GetKey (KeyCode.LeftArrow) && colision)
			this.rigidbody2D.velocity = new Vector2(-7.0, y);	
			
		if(Input.GetKey (KeyCode.UpArrow) && colision){
			this.rigidbody2D.velocity = new Vector2(x, 7.0);
			colision = false;
		}
	
	
}