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

    bool willRight;

    bool willLeft;

    Vector3 move = Vector3.zero;

    Vector3 vertical;

    Vector3 forward;

    int lane = 1;

    int targetLane = 1;

    float startTime = 0;

    float waitFor = 0.5f;

    bool timerStartGame;

    bool timerStartJump;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        canMove = true;
        isStart = true;
        isGrounded = cc.isGrounded;
        timerStartGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStartGame && Time.time - startTime > waitFor)
        {
            //Do something
            Debug.Log("end timer");
            animator.SetBool("isMoving", true);
            timerStartGame = false;
        }

        if (!timerStartGame)
        {
            Vector3 pos = gameObject.transform.position;
            bool isJumping = animator.GetBool("isJumping");
            bool isSliding = animator.GetBool("isSliding");
            bool isRight = animator.GetBool("isRight");
            bool isLeft = animator.GetBool("isLeft");
            bool spacePressed = Input.GetKeyDown(KeyCode.Space);
            bool downPressed = Input.GetKeyDown(KeyCode.DownArrow);
            bool rightPressed = Input.GetKeyDown(KeyCode.RightArrow);
            bool leftPressed = Input.GetKeyDown(KeyCode.LeftArrow);

            //animator.SetBool("isMoving", true);
            //animator.SetBool("isMoving", true);
            // keeps moving forward
            forward.z = 7;
            cc.Move(forward * Time.deltaTime);

            // gravity
            if (cc.isGrounded && vertical.y < 0)
            {
                //Debug.Log("going down");
                vertical.y = 0f;

                //Debug.Log(vertical.y);
                animator.SetBool("isJumping", false);
            }

            // check inputs
            if (leftPressed && lane > 0)
            {
                //Debug.Log("left");
                targetLane--;
                canMove = true;

                //willLeft = true;
                move.x = -4;
            }
            else if (rightPressed && lane < 2)
            {
                //Debug.Log("right");
                targetLane++;
                canMove = true;

                //willRight = true;
                move.x = 4;
            }
            else if (spacePressed)
            {
                //Debug.Log("jump");
                isJump = true;

                //canJump = false;
                //canMove = true;
                isGrounded = false;
            }
            else if (downPressed)
            {
                //Debug.Log("slide");
                isSlide = true;
                //animator.SetBool("isSliding", true);
            }

            if (!isJumping && spacePressed)
            {
                animator.SetBool("isJumping", true);
            }
            else if (isJumping && !spacePressed)
            {
                animator.SetBool("isJumping", false);
            }

            if (!isSliding && downPressed && canMove)
            {
                
                //cc.height -= 0.5f;
                //cc.center.y -= 0.25f;
                animator.SetBool("isSliding", true);
            }
            else if (isSliding && !downPressed)
            {
               //cc.height += 0.5f;
               //cc.center.y += 0.25f;
                animator.SetBool("isSliding", false);
            }

            /*if (!isRight && rightPressed)
            {
                animator.SetBool("isRight", true);
            }
            else if (isRight && !rightPressed)
            {
                animator.SetBool("isRight", false);
                willRight = false;
            }

            if (!isLeft && leftPressed)
            {
                animator.SetBool("isLeft", true);
            }
            else if (isLeft && !leftPressed)
            {
                animator.SetBool("isLeft", false);
                willLeft = false;
            }*/

            // gravity
            if (isJump && cc.isGrounded)
            {
                vertical.y += Mathf.Sqrt(-2 * gravity);
                isJump = false;
                canMove = false;
            }
            vertical.y += gravity * Time.deltaTime;

            //Debug.Log("final vertical: ");
            //Debug.Log(vertical.y);
            cc.Move(vertical * Time.deltaTime);

            //GetComponent<Animation>().Play("Jump");
            //canMove = true;
            // Left and right
            if (!lane.Equals(targetLane))
            {
                // left boundary
                if (targetLane == 0 && pos.x < -2 && canMove)
                {
                    //Debug.Log("target lane 0 and pos.x < -2.5");
                    gameObject.transform.position =
                        new Vector3(-2f, pos.y, pos.z);
                    lane = targetLane;
                    canMove = false;
                    move.x = 0;
                }
                else if (targetLane == 1 && (pos.x > 0 || pos.x < 0) && canMove)
                {
                    if (lane == 0 && pos.x > 0)
                    {
                        //Debug.Log("target lane 0 and pos.x > 0");
                        gameObject.transform.position =
                            new Vector3(0, pos.y, pos.z);
                        lane = targetLane;
                        canMove = false;
                        move.x = 0;
                    }
                    else if (lane == 2 && pos.x < 0)
                    {
                        //Debug.Log("target lane 2 and pos.x < 0");
                        gameObject.transform.position =
                            new Vector3(0, pos.y, pos.z);
                        lane = targetLane;
                        canMove = true;
                        move.x = 0;
                    }
                } // right boundary
                else if (targetLane == 2 && pos.x > 2 && canMove)
                {
                    //Debug.Log("target lane 2 and pos.x > 2.5");
                    gameObject.transform.position =
                        new Vector3(2f, pos.y, pos.z);
                    lane = targetLane;
                    canMove = false;
                    move.x = 0;
                }
            }

            cc.Move(move * Time.deltaTime);
        }
    }
}
