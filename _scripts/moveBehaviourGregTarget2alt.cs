//moveBehaviourGregTarget.cs
//@author: Greg Dunne
//Date 16.03.2017

//Lerp code sourced from https://docs.unity3d.com/410/Documentation/ScriptReference/Vector3.Lerp.html

using UnityEngine;
using System.Collections;

public class moveBehaviourGregTarget2alt : MonoBehaviour {

	public int targetHealth;
	private GameObject arena;
	Arena arenaScript;
	public GameObject explosion;
	public Vector3 position;
	public Vector3 localScale;
	public Vector3 rotate;

	public float speed;
	public bool reverseMove = false;

	private float startTime;
	private float journeyLength;

	//left and right boundaries for moving target.
	Vector3 leftBoundary;
	Vector3 rightBoundary;
	Vector3 topBoundary;
	Vector3 bottomBoundary;
	Vector3 backgroundBoundary;
	Vector3 foregroundBoundary;

	// Use this for initialization of all variables which need to have values at game start
	void Start () {
		targetHealth = 1;

		//fetching the arena GameObject and arena class
		arena = GameObject.FindGameObjectWithTag("arena");
		arenaScript = arena.GetComponent<Arena> ();

		//left and right boundary positions.
		leftBoundary = new Vector3 (-2.15f,transform.position.y,transform.position.z);
		rightBoundary = new Vector3 (2.15f,transform.position.y,transform.position.z);
		topBoundary = new Vector3 (transform.position.x,2.3f,transform.position.z);
		bottomBoundary = new Vector3 (transform.position.x,0.7f,transform.position.z);
		backgroundBoundary = new Vector3 (transform.position.x,transform.position.y,3f);
		foregroundBoundary = new Vector3 (transform.position.x,transform.position.y,11f);

		//Moving the target
		startTime = Time.time;
		journeyLength = Vector3.Distance (leftBoundary, rightBoundary);

	}

	// Update is called once per frame
	void Update () {

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;

		if (reverseMove) {
			transform.position = Vector3.Lerp (backgroundBoundary, foregroundBoundary, fracJourney);
		}else{
			transform.position = Vector3.Lerp (foregroundBoundary, backgroundBoundary, fracJourney);
	}
		//bounce
		if ((Vector3.Distance(transform.position, backgroundBoundary)==0.0f || Vector3.Distance(transform.position, foregroundBoundary)==0.0f)){
			if (reverseMove){
				reverseMove=false;
			}
			else{
				reverseMove = true;
			}
			startTime = Time.time;
		}
	}


	//on collision with the ball:
	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("ball")) {
			//subtract target health
			targetHealth--;

			//if target health is 0:
				if(targetHealth < 1){
				//subtract 1 target from target counter  
				arenaScript.removeTarget ();
				//finally destroy this target object to free up memory 
				Destroy (gameObject);
			}
		}
	}

}

