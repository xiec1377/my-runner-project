using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;

        // keeps moving forward
        //forward.z = -1;
        cc.Move(forward * Time.deltaTime);
    }
}
