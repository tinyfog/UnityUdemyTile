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
    SpriteRenderer playerSprite;
    bool faceRight = true;

    bool runningLimit = false;
    // Use this for initialization
    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position + offset, Vector3.down * 1.1f, Color.red);
        FaceDirection();
        Move();
        JumpAnim();
        Attack();
    }

    void JumpAnim()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position + offset, Vector2.down, 1.1f, 1 << 8);

        if (hitGround.collider != null)
        {
            // Debug.Log("hitGround is " + hitGround.collider.gameObject.name);
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            _anim.Play("animJump");

        }
    }

    void FaceDirection(){
        if(Input.GetAxisRaw("Horizontal")>0){faceRight = true;Debug.Log("I'm facing right");}
        else if(Input.GetAxisRaw("Horizontal")<0) { faceRight =false;}
    }
    void JumpAction()
    {
        if(faceRight == false){playerSprite.flipX = true;}
        else{playerSprite.flipX = false;}
        playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpForce);
        // Debug.Log("jumpForce is " + jumpForce);
        canJump = false;
    }
    void RunningLimitBegin(){
        runningLimit = true;
    }
    void RunningLimitEnd(){
        runningLimit = false;
    }
    void Move()
    {
        if(!runningLimit){
        float move = Input.GetAxisRaw("Horizontal") * speed;
        Debug.Log("my move value is " + move);
        if(faceRight == false){playerSprite.flipX = true;}
        else{playerSprite.flipX = false;}
        _anim.SetFloat("move", Mathf.Abs(move));
        playerRigid.velocity = new Vector2(move, playerRigid.velocity.y);
        }

    }
    void AttackSpecial(){
        if(Input.GetKeyDown(KeyCode.J) && canJump == true){
        _anim.Play("animAttack2");
        }
    }

        void Attack(){
        if(Input.GetKeyDown(KeyCode.J) && canJump == true){
        _anim.Play("animAttack2");
        }
        if(Input.GetKeyDown(KeyCode.K) && canJump == true){
        _anim.Play("animAttack");
        }
    }
}
