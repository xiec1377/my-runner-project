using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /*Animator animator; 
    public float moveSpeed = 2;
    public float jumpSpeed = 1;
    public float shiftSpeed = 0.5f;
    public float gravity = -9.81f;
    CharacterController cc;
    bool canMove;
    bool isJump;
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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        
        // keeps moving forward
        forward.z = 10;
        cc.Move(forward * Time.deltaTime);
        //cc.Move(Vector3.forward * Time.deltaTime * moveSpeed);
        //Vector3 mover = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //cc.Move(mover * Time.deltaTime * moveSpeed);
        checkInputs();
        
        // Jumping
        if (cc.isGrounded && vertical.y < 0) {
            Debug.Log("is grounded");
            vertical.y = 0f;
        }
        
        if (isJump && cc.isGrounded) {
            Debug.Log("is jumping");
            vertical.y += Mathf.Sqrt(2 * -2f * gravity);
            isJump = false;
            canMove = false;
        }
        vertical.y += gravity * 2 * Time.deltaTime;
        cc.Move(vertical * Time.deltaTime);
        //GetComponent<Animation>().Play("Jump");
        //animator.setBool("isJumping", true);
        canMove = true;

        // Left and right
       if (!lane.Equals(targetLane)) {
            // left boundary
            if (targetLane == 0 && pos.x < -2.5) {
                Debug.Log("target lane 0 and pos.x < -2");
                gameObject.transform.position = new Vector3(-2.5f, pos.y, pos.z);
                lane = targetLane;
                canMove = true;
                move.x = 0;
            } else if (targetLane == 1 && (pos.x > 0 || pos.x < 0)) {
                if (lane == 0 && pos.x > 0) {
                    Debug.Log("target lane 0 and pos.x > 0");
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    lane = targetLane;
                    canMove = true;
                    move.x = 0;
                } else if (lane == 2 && pos.x < 0) {
                    Debug.Log("target lane 2 and pos.x < 0");
                    gameObject.transform.position = new Vector3(0, pos.y, pos.z);
                    lane = targetLane;
                    canMove = true;
                    move.x = 0;
                }
            } // right boundary
                else if (targetLane == 2 && pos.x > 2.5) {
                Debug.Log("target lane 2 and pos.x < 2");
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
            Debug.Log("left");
            targetLane--;
            canMove = false;
            move.x = -6;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) && lane < 2) {
            Debug.Log("right");
            targetLane++;
            canMove = false;
            move.x = 6;
        } else if (Input.GetKeyDown(KeyCode.Space) && canMove) {
            Debug.Log("jump");
            isJump = true;
            canMove = false;
        }
    }*/
}