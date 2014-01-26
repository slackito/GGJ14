using UnityEngine;
using System.Collections;

public class BigWhiteBoxSwitcher : MonoBehaviour, IFadeable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetFadeState(float value) {

		if(value < 0.1)
		{
			this.transform.localScale = new Vector3(1,1,1);
			this.GetComponent<Rigidbody2D>().isKinematic = false;
			this.GetComponent<BoxCollider2D>().size = new Vector2(1.0f,1.0f);
			this.GetComponent<BoxCollider2D>().center = new Vector2(0.0f,0.0f);
		}


		if(value > 0.9)
		{
			this.transform.localScale = new Vector3(3,3,1);
			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<BoxCollider2D>().size = new Vector2(1.3f,2.2f);
			this.GetComponent<BoxCollider2D>().center = new Vector2(0.0f,-0.6f);
		}
		

	}
}
