using UnityEngine;
using System.Collections;

public class AnimControll : MonoBehaviour {

	public AudioClip sndAttack_light = null;
	public AudioClip sndAttack_middle = null;
	public AudioClip sndAttack_big = null;
	public AudioClip sndAttack_super = null;
	public AudioClip sndAttack_extra = null;

	// Use this for initialization
	void Start () {
	
	}

	public void HitPoint(){

	}

	public void PlaySnd(string name){
		switch (name){
			//case "hit": TryPlaySnd(sndHit); break;
			case "lite": AudioManager.instance.PlaySfx(sndAttack_light.name); break;
			case "middle": AudioManager.instance.PlaySfx(sndAttack_middle.name); break;
			case "big": AudioManager.instance.PlaySfx(sndAttack_big.name); break;
			case "super": AudioManager.instance.PlaySfx(sndAttack_super.name); break;
			case "extra": AudioManager.instance.PlaySfx(sndAttack_extra.name); break;
			//case "die": TryPlaySnd(sndDie); break;
			//case "block": TryPlaySnd(sndBlock); break;
			//case "blade_out": TryPlaySnd (sndBladeOut); break;
			//case "voice": _AUDIO.APLayHeroVoice(sndVoice); break;
			default: Debug.Log("HERO ANIM CONTROL: NO SOUND WITH THIS NAME"); break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
