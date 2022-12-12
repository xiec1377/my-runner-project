using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator; 
    public float moveSpeed = 2;
    public float jumpSpeed = 1;
    public float shiftSpeed = 0.5f;
    public float gravity = -9.81f;
    CharacterController cc;
    bool canMove;
    bool isJump;
    bool isStart;
    bool isGrounded;
    bool canJump;
    bool isSlide;
    Vector3 move = Vector3.zero;
    Vector3 vertical;
    Vector3 forward;
    int lane = 1;
    int targetLane = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController> ();
        animator = gameObject.GetComponent<Animator>();
        canMove = true;
        isStart = true;
        isGrounded = cc.isGrounded;
        animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        bool isJumping = animator.GetBool("isJumping");
        bool isSliding = animator.GetBool("isSliding");
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);
        bool downPressed = Input.GetKeyDown(KeyCode.DownArrow);
        //animator.SetBool("isMoving", true);
        //animator.SetBool("isMoving", true);

        // keeps moving forward
        forward.z = 7;
        cc.Move(forward * Time.deltaTime);
        // gravity
       if (cc.isGrounded && vertical.y < 0) {
            //Debug.Log("going down");
            vertical.y = 0f;
            //Debug.Log(vertical.y);
            animator.SetBool("isJumping", false);
        }

        checkInputs();
        

        if (!isJumping && spacePressed) {
            animator.SetBool("isJumping", true);
        } else if (isJumping && !spacePressed) {
            animator.SetBool("isJumping", false);
        }

        if (!isSliding && downPressed) {
            animator.SetBool("isSliding", true);
        } else if (isSliding && !downPressed) {
            animator.SetBool("isSliding", false);
        }
        
        //animator.SetBool("isJumping", false);

        /*if (isJump) {
            isJump = false;
            animator.SetBool("isJumping", isJump);
        }*/

        if (isJump && cc.isGrounded) {
            vertical.y += Mathf.Sqrt(-2 * gravity);
            isJump = false;
            canMove = false;
        }
        vertical.y += gravity * Time.deltaTime;
        
        //Debug.Log("final vertical: ");
        //Debug.Log(vertical.y);

        cc.Move(vertical * Time.deltaTime);
        //GetComponent<Animation>().Play("Jump");
        canMove = true;


        // Left and right
        if (!lane.Equals(targetLane)) {
            // left boundary
            if (targetLane == 0 && pos.x < -2.5) {
                //Debug.Log("target lane 0 and pos.x < -2.5");
                gameObject.transform.position = new Vector3(-2.5f, pos.y, pos.z);
                lane = targetLane;
                canMove = true;
                move.x = 0;
            } else if (targetLane == 1 && (pos.x > 0 || pos.x < 0)) {
                if (lane == 0 && pos.x > 0) {
                    //Debug.Log("target lane 0 and pos.x > 0");
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    lane = targetLane;
                    canMove = true;
                    move.x = 0;
                } else if (lane == 2 && pos.x < 0) {
                    //Debug.Log("target lane 2 and pos.x < 0");
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    lane = targetLane;
                    canMove = true;
                    move.x = 0;
                }
            } // right boundary
                else if (targetLane == 2 && pos.x > 2.5) {
                //Debug.Log("target lane 2 and pos.x > 2.5");
                gameObject.transform.position = new Vector3(2.5f, pos.y, pos.z);
                lane = targetLane;
                canMove = true;
                move.x = 0;
            }
        }
        
        cc.Move (move * Time.deltaTime);
        

    }

    void checkInputs() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lane > 0) {
            //Debug.Log("left");
            animator.SetBool("isJumping", false);
            targetLane--;
            canMove = false;
            move.x = -6;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 2) {
           // Debug.Log("right");
            animator.SetBool("isJumping", false);
            targetLane++;
            canMove = false;
            move.x = 6;
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log("jump");
            //animator.SetBool("isJumping", false);
            isJump = true;
            canJump = false;
            canMove = false;
           // animator.SetBool("isJumping", isJump);
           //animator.SetBool("isMoving", false);
           isGrounded = false;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            //Debug.Log("slide");
            canMove = false;
            isSlide = true;
            animator.SetBool("isSliding", true);
        }
    }
}
