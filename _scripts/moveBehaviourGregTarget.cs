﻿//moveBehaviourGregTarget.cs
//@author: Greg Dunne
//Date 06.03.2017

using UnityEngine;
using System.Collections;

public class moveBehaviourGregTarget : MonoBehaviour {
	public int targetHealth;
	private GameObject arena;
	Arena arenaScript;
	public GameObject explosion;
	public Vector3 position;
	public Vector3 localScale;
	public Vector3 rotate;



	// Use this for initialization of all variables which need to have values at game start
	void Start () {
		targetHealth = 4;

		//fetching the arena GameObject and arena class
		arena = GameObject.FindGameObjectWithTag("arena");
		arenaScript = arena.GetComponent<Arena> ();

	}

	// Update is called once per frame
	void Update () {
		
		transform.Rotate(0,0,0.5f);// rotates slowly
		transform.localScale = new Vector3(1f, 1f, 0);//decreases size so it's not rotating outside position

	
	}

	//on collision with the ball:
	void OnTriggerEnter(Collider other) {
		//transform.position = new Vector3 (0, 1.5f,0.1f);
		//transform.localScale += new Vector3(0.2f, 0.2f, 0);

		if (other.CompareTag ("ball")) {
			//subtract target health
			targetHealth--;

			//if target health is 0:
			if (targetHealth == 4) {
				transform.position = new Vector3 (0, 0.7f, 11.9f);
			}
			if (targetHealth ==3){
				transform.position = new Vector3 (2.15f, 0.7f, 11.9f);
			}
			if (targetHealth ==2){
				transform.position = new Vector3 (-2.15f, 2.3f, 11.9f);
			}
			if (targetHealth ==1){
				transform.position = new Vector3 (2.15f, 2.3f, 11.9f);
			}
			else if(targetHealth < 1){

				//Sends message to fungus to bring up exit script
				Fungus.Flowchart.BroadcastFungusMessage ("EndTutorial");
				//subtract 1 target from target counter  
				arenaScript.removeTarget ();
				//finally destroy this target object to free up memory 
				Destroy (gameObject);


			}
		}
	}
		
}

