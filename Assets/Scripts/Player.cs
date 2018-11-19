using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Rigidbody2D playerRigid;
	public bool canJump = true;
	public float jumpForce = 5;
	// Use this for initialization
	void Start () {
		playerRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay(transform.position,Vector3.down*1.1f ,Color.red);
		RaycastHit2D hitGround = Physics2D.Raycast(transform.position, Vector2.down, 1.1f,1 << 8);
		// Debug.

			if (hitGround.collider != null)
			{
				Debug.Log("hitGround is "+hitGround.collider.gameObject.name);
				canJump = true;
			}

		if(Input.GetKeyDown(KeyCode.Space) && canJump == true){
			playerRigid.velocity = new Vector2(playerRigid.velocity.x,jumpForce);
			Debug.Log("jumpForce is "+jumpForce);
			canJump = false;
		}
		playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),playerRigid.velocity.y);
	}
}
