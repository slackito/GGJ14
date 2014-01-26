using UnityEngine;
using System.Collections.Generic;

public class WorldSwitcher : MonoBehaviour {

	public GameObject whitePlayer;
	public GameObject blackPlayer;
	public float fadeDuration = 1.0f;
	public CameraBehaviour camera;

	List<IFadeable> fadeableObjects;

	public enum WorldColor {
		BLACK,
		WHITE
	};

	public WorldColor worldColor = WorldColor.BLACK;
	public float fadeBegin=0.0f;
	public float fadeState=0.0f;

	void SwitchToWhite() {
		blackPlayer.GetComponent<MoveBehaviour> ().movementEnabled = false;
		whitePlayer.GetComponent<MoveBehaviour> ().movementEnabled = true;
		camera.target = whitePlayer;

		worldColor = WorldColor.WHITE;
		fadeBegin = Time.time;
	}

	void SwitchToBlack() {
		blackPlayer.GetComponent<MoveBehaviour> ().movementEnabled = true;
		whitePlayer.GetComponent<MoveBehaviour> ().movementEnabled = false;
		camera.target = blackPlayer;

		worldColor = WorldColor.BLACK;
		fadeBegin = Time.time;
	}

	// Use this for initialization
	void Start () {
		fadeableObjects = new List<IFadeable> ();
		foreach(var x in Object.FindObjectsOfType<MonoBehaviour> ())
		{
			if (x is IFadeable)
				fadeableObjects.Add((IFadeable)x);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("right shift")) {
				SwitchToWhite ();
		} else if (Input.GetKeyDown ("left shift")) {
				SwitchToBlack ();
		}

		if (worldColor == WorldColor.WHITE && fadeState > 0.99f) {
			fadeState = 1.0f;
		} else if (worldColor == WorldColor.BLACK && fadeState < 0.01f) {
			fadeState = 0.0f;
		} else {
			float t = (Time.time - fadeBegin) / fadeDuration;
			fadeState = 3.0f * t * t - 2.0f * t * t * t;
			if (worldColor == WorldColor.BLACK)
				fadeState = 1.0f - fadeState;
		}

		// broadcast current fade state
		foreach (IFadeable o in fadeableObjects) {
			o.SetFadeState(fadeState);
		}
	}

	void FixedUpdate() {
	}
}
