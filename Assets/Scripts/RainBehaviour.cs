using UnityEngine;
using System.Collections;

public class RainBehaviour : MonoBehaviour, IFadeable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetFadeState(float value) {
		var emitter = gameObject.transform.Find("RainEmitter").gameObject;
		emitter.GetComponent<ParticleSystem> ().maxParticles = (int)((1.0f - value) * 100);
	}
}
