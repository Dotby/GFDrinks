using UnityEngine;
using System.Collections;

public class ColliderControl : MonoBehaviour {

	public LevelControl eng;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		eng.Attack();
	}
}
