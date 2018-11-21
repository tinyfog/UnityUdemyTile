using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerryzhao : MonoBehaviour
{
    Rigidbody2D playerRigid;
    public Vector3 offset;
    public bool canJump = true;
    public float jumpForce = 5;
    Animator _anim;
    // Use this for initialization
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position + offset, Vector3.down * 1.1f, Color.red);
		Move();
		Jump();
    }

    void Jump()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position + offset, Vector2.down, 1.1f, 1 << 8);
   
        if (hitGround.collider != null)
        {
            Debug.Log("hitGround is " + hitGround.collider.gameObject.name);
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpForce);
            Debug.Log("jumpForce is " + jumpForce);
            canJump = false;
        }
    }
	void Move(){
		float move = Input.GetAxisRaw("Horizontal");
		_anim.SetFloat("move",move);
		playerRigid.velocity = new Vector2(move, playerRigid.velocity.y);
	}
}
