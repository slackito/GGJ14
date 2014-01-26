using UnityEngine;
using System.Collections;

// 0: Dark, 1: Light . That is the law

/*
public class XFade : MonoBehaviour {
	public AudioSource[] audiosources = new AudioSource[2];
	public AudioSource[] lightaudiosources = new AudioSource[2];
	public AudioSource[] darkaudiosources = new AudioSource[2];
	public AudioSource[] neutralaudiosources = new AudioSource[2];
	public float inc = 0.005f;
	bool xfading = false;
	int master = 0;
	int slave = 1;

	// Use this for initialization
	void Start () {
		audiosources = this.GetComponents<AudioSource>();
		audiosources [1].volume = 0.0f;
		foreach (AudioSource a in audiosources) {
			a.Play();
		}
		DoXFade ();
	}
	
	// Update is called once per frame
	void Update () {
		if (xfading == false) {
			DoXFade (slave);
			return;
		}
		if (xfading) {
			if (audiosources [slave].volume > 0.0f) audiosources [slave].volume -= inc;
			if (audiosources [master].volume < 1.0f) audiosources [master].volume += inc;
			else {
				xfading = false;
				Debug.Log("XFading done");
			}
			Debug.Log ("Source 0: " + audiosources [0].volume);
			Debug.Log ("Source 1: " + audiosources [1].volume);
		}
	}

	void DoXFade(int tosource = 1) {
		master = tosource;
		slave = (tosource + 1) % 2;
		xfading = true;
	}

	public void XFadeSources(AudioSource as0, AudioSource as1) {
		audiosources [0] = as0;
		audiosources [1] = as1;
	}
}
*/

[RequireComponent(typeof(AudioSource))]
public class XFade : MonoBehaviour, IFadeable {
	AudioSource[] darkAudioSources; //= new AudioSource[2];
	AudioSource[] lightAudioSources; //= new AudioSource[2];
	AudioSource[] neutralAudioSources; //= new AudioSource[2];
	public AudioClip[] darkAudioClips; //= new AudioClip[2];
	public AudioClip[] lightAudioClips; //= new AudioClip[2];
	public AudioClip[] neutralAudioClips; //= new AudioClip[2];
	
	// Use this for initialization
	void Start () {
		darkAudioSources = new AudioSource[darkAudioClips.Length];
		lightAudioSources = new AudioSource[lightAudioClips.Length];
		neutralAudioSources = new AudioSource[neutralAudioClips.Length];
		// Dark sources (muahahahaha!)
		for (int i = 0; i < darkAudioClips.Length; i++) {
			//Debug.Log (i + " " + darkAudioClips[i]);
			AudioSource asource = gameObject.AddComponent("AudioSource") as AudioSource;
			darkAudioSources[i] = asource;
			darkAudioSources[i].clip = darkAudioClips[i];
			darkAudioSources[i].Play();
		}
		// Light sources
		for (int i = 0; i < lightAudioClips.Length; i++) {
			//Debug.Log (i + " " + lightAudioClips[i]);
			AudioSource asource = gameObject.AddComponent("AudioSource") as AudioSource;
			lightAudioSources[i] = asource;
			lightAudioSources[i].clip = lightAudioClips[i];
			lightAudioSources[i].volume = 0.0f;
			lightAudioSources[i].Play();
		}
		// Neutral sources
		for (int i = 0; i < neutralAudioClips.Length; i++) {
			//Debug.Log (i + " " + neutralAudioClips[i]);
			AudioSource asource = gameObject.AddComponent("AudioSource") as AudioSource;
			neutralAudioSources[i] = asource;
			neutralAudioSources[i].clip = neutralAudioClips[i];
			neutralAudioSources[i].Play();
		}
		/*audiosources = this.GetComponents<AudioSource>();
		audiosources [1].volume = 0.0f;
		foreach (AudioSource a in audiosources) {
			a.Play();
		}*/
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetFadeState(float balance) {
		foreach (AudioSource das in darkAudioSources) {
			das.volume = 1.0f - balance;
		}
		foreach (AudioSource las in lightAudioSources) {
			las.volume = balance;
		}
	}

	public void Play() {
		foreach (AudioSource das in darkAudioSources) {
			das.Play();
		}
		foreach (AudioSource las in lightAudioSources) {
			las.Play();
		}
		foreach (AudioSource nas in neutralAudioSources) {
			nas.Play();
		}
	}

	public void Stop() {
		foreach (AudioSource das in darkAudioSources) {
			das.Stop();
		}
		foreach (AudioSource las in lightAudioSources) {
			las.Stop();
		}
		foreach (AudioSource nas in neutralAudioSources) {
			nas.Stop();
		}
	}
}
