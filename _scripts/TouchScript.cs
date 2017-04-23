//TouchScript.cs
//@author: Mario Tommadich
//Date 20.02.2017

using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {
	Vector3 mousePos;
	public GameObject paddle;
	GameObject ball;
	MoveBallnoPhysics ballMover;
	
	//added by greg as required for tutorial stage.
	public bool canMove = true;

	void Start(){
		ball = GameObject.FindGameObjectWithTag ("ball");
		ballMover = ball.GetComponent<MoveBallnoPhysics> ();
	}

	void Update(){

		//added by greg as required for tutorial stage.
		if (canMove) {


		
			if (ballMover.ballStopped && Input.GetMouseButtonUp (0)) {
				ballMover.ballStopped = false;
			}



			if (Input.GetMouseButton (0)) {
				mousePos = Input.mousePosition;
				mousePos.z = 3.63f;
				mousePos = Camera.main.ScreenToWorldPoint (mousePos);
				paddle.transform.position = mousePos;
			}

		}


	}

	//added by greg as required for tutorial stage.
	public void setMovable(){
		canMove = true;
	}

	//added by greg as required for tutorial stage.
	public void setNotMovable(){
		canMove = false;
	}
}