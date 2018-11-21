using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jerryzhao : MonoBehaviour
{
    Rigidbody2D playerRigid;
    public Vector3 offset;
    public float speed;
    public bool canJump = true;
    public float jumpForce = 5;
    Animator _anim;

    bool readyJump = false;
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
        JumpAnim();
    }

    void JumpAnim()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position + offset, Vector2.down, 1.1f, 1 << 8);

        if (hitGround.collider != null)
        {
            Debug.Log("hitGround is " + hitGround.collider.gameObject.name);
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            _anim.Play("animJump");

        }
    }

    void JumpAction()
    {
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpForce);
        Debug.Log("jumpForce is " + jumpForce);
        canJump = false;
    }
    void ReadyJumpBegin(){
        readyJump = true;
    }
    void ReadyJumpEnd(){
        readyJump = false;
    }
    void Move()
    {
        if(!readyJump){
        float move = Input.GetAxisRaw("Horizontal") * speed;
        _anim.SetFloat("move", move);
        playerRigid.velocity = new Vector2(move, playerRigid.velocity.y);
        }

    }
}
