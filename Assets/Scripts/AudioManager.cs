using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioClip[] _sfx;
	public AudioClip[] _music;
	
	void Start () {
		if (instance){
			Destroy (gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
		
		DontDestroyOnLoad (transform.gameObject);
	}

	public void PlaySfx(string _name){
		foreach(AudioClip _ac in _sfx){
			if (_name == _ac.name){
				AudioSource.PlayClipAtPoint(_ac, Vector3.zero);
				return;
			}
		}

		Debug.Log("[Error_AUDIO] Sfx '" + _name + "' not found.");
	}

	void Update () {
	
	}

	void OnApplicationQuit(){
		instance = null;
	}

}
