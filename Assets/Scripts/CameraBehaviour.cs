using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public GameObject target;
	public float deltax;
	public float deltay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		Vector3 targetpos = target.transform.position;

		if(Mathf.Abs(pos.x - targetpos.x) > deltax)
			//Mover la x hacia la posicion del target
			pos.x = 0.90f * pos.x + 0.10f * targetpos.x;

		if(Mathf.Abs(pos.y - targetpos.y) > deltay)
			//Mover la x hacia la posicion del target
			pos.y = 0.90f * pos.y + 0.10f * targetpos.y;
				
		this.transform.position = pos;

	}
}
