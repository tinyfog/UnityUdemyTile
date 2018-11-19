using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Rigidbody2D playerRigid;
	bool canJump = true;
	float jumpVel = 0;
	// Use this for initialization
	void Start () {
		playerRigid = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		// float speed = Input.GetAxisRaw("Horizontal")*Time.deltaTime;
		// playerRigid.transform.Translate(speed,0,0);
		RaycastHit2D hitGround;
		// hitGround;
		if(Input.GetKey(KeyCode.Space) && canJump == true){
			jumpVel = Input.GetAxis("Vertical");
			Debug.Log("JumpVel is "+jumpVel);
		}
		playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),playerRigid.velocity.y + jumpVel);
	}
}
