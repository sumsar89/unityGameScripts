using UnityEngine;
using System.Collections;

public class perkSettings : MonoBehaviour {
	public int perkHealth;
	public GameObject arena;
	public GameObject[] backTargets;
	Arena2 arenaScript;
	GameObject[] gameObjects;
	public int destroyTime = 3;
	public int startTime=3;

	// Use this for initialization of all variables which need to have values at game start
	void Start () {
		//targetHealth = 3;

		//fetching the arena class
		arena = GameObject.FindGameObjectWithTag("arena");
		arenaScript = arena.GetComponent<Arena2> ();
		Invoke("perk", startTime);


	}

	// Update is called once per frame
	void Update () {
		
		Destroy (gameObject, destroyTime);
	}


		

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("ball")) {
			perkHealth--;
			if (perkHealth < 1) {
				Destroy (gameObject);

				/*
				//subtract 1 target from target counter 
				arenaScript.removeTarget ();
				Destroy(GameObject.Find("back_target_simple(Clone)"));
				//subtract 1 target from target counter 
				arenaScript.removeTarget ();
				*/

				// Destroys all the targetrs which I've given a tag of 'target'
				gameObjects = GameObject.FindGameObjectsWithTag ("target");

				for(var i = 0 ; i < gameObjects.Length ; i ++)
				{
					Destroy(gameObjects[i]);
					arenaScript.removeTarget ();
				}

				//This causes the exit to appear when hitting the perk.
			}


		}
	}
}
