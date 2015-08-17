using UnityEngine;
using System.Collections;
using Vuforia;

public class LevelControl : MonoBehaviour {

	public GameObject[] cans;
	float dist = 0f;
	int animNum = 0;

	public DefaultTrackableEventHandler mark;
	public AudioSource lightingAudio;

	public GameObject[] roots;

	GameObject activeRoot = null;

	public int attackerID = 0;

	public GameObject startScreen;
	public GameObject gameScreen;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < roots.Length; i++){
			roots[i].SetActive(false);
		}

		//roots[0].SetActive(true);
		//activeRoot = roots[0];
		//mark.OnTrackingFound();


	}


	public void PlayAnim(){

		if (activeRoot == null) {return;}
		Animator anim = activeRoot.GetComponentInChildren<Animator>();

		switch(animNum){
			case 0: anim.Play("attack_lite"); break;
			case 1: anim.Play("attack_middle"); break;
			case 2: anim.Play("attack_big"); break;
			case 3: anim.Play("attack_super"); break;
			case 4: anim.Play("attack_extra"); break;

			default: break;
		}

		animNum++;
		if (animNum >= 5){
			animNum = 0;
		}
	}
	
	public void ActiveteOnly(string markerName){

		animNum = 0;

		mark.OnTrackingFound();

		foreach(GameObject root in roots){
			if (root.name == markerName){
				if (root == activeRoot) {return;}
				root.SetActive(true);
				activeRoot = root;
			}else{
				root.SetActive(false);
			}
		}

		//WARNING!
		CancelInvoke();

		switch(markerName){
			case "Active": ActiveOn(); break;
			case "Ice": IceOn(); break;
			case "Storm": StormOn(); break;
			case "Coffee": CoffeOn(); break;

			default: break;
		}
		
	}

	public void GoToGameScene(){
		startScreen.SetActive(false);
		gameScreen.SetActive(true);

		ActiveteOnly("Active");
	}

	void CoffeOn(){
		AudioManager.instance.PlaySfx("Jinx");
	}

	void StormOn(){
		AudioManager.instance.PlaySfx("Alistar");
		AudioManager.instance.PlaySfx("storm_on");
		InvokeRepeating("Tunder", 0f, 2f);
	}

	void IceOn(){
		AudioManager.instance.PlaySfx("frozen");
		AudioManager.instance.PlaySfx("Rengar");
	}

	void ActiveOn(){
		AudioManager.instance.PlaySfx("Brand");
		AudioManager.instance.PlaySfx("fireball_lite");
		InvokeRepeating("LavaBoom", 1f, 4.5f);
	}

	void LavaBoom(){
		int ran = Random.Range(0, 2);
		if (ran == 0){
			AudioManager.instance.PlaySfx("fire_small");
		}
		else{
			AudioManager.instance.PlaySfx("fireball_lite");
		}
	}

	void Tunder(){
		float ran = Random.Range(0.8f, 1.6f);
		lightingAudio.pitch = ran;
		lightingAudio.Play();
	}

	public void Attack(){

//		cans[attackerID].GetComponentInChildren<Animator>().Play("attack_lite");
//		cans [1 - attackerID].GetComponentInChildren<Animator>().Play("hit");
//
//		if (attackerID + 1 < cans.Length){
//			attackerID++;
//		}else{
//			attackerID = 0;
//		}
	}
	
	// Update is called once per frame
	void Update () {

		//dist = Vector3.Distance(cans[0].transform.position, cans[1].transform.position);

//		if (cans.Length > 1){
//			if (dist < 26f) Debug.Log("NOW");
//		}
	}
}
