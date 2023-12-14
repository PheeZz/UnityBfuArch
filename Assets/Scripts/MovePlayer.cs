using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 2.0f;
    private Vector3 _move_vector;
    public Transform orientation;
    private Animator _animator;

    void Awake()
    {
        // get position of object
        this._rb = this.GetComponent<Rigidbody>();
        this._animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = _animator.GetBool("isWalking");
        bool isRunning = _animator.GetBool("isRunning");
        //if any WASD key is pressed, set isWalking to true for walking animation
        if (
            Input.GetAxisRaw("Horizontal") != 0
            || Input.GetAxisRaw("Vertical") != 0 && !isWalking && !isRunning
        )
        {
            _animator.SetBool("isWalking", true);
            speed = 2.0f;
        } //set isRunning to true for running animation
        if (Input.GetKey(KeyCode.LeftShift) && !isRunning)
        {
            _animator.SetBool("isRunning", true);
            _animator.SetBool("isWalking", false);
            speed = 8.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning)
        {
            _animator.SetBool("isRunning", false);
            _animator.SetBool("isWalking", true);
            speed = 2.0f;
        }
        //if no input, set isWalking to false for idle animation
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _animator.SetBool("isWalking", false);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("jumping");
        }
    }

    void FixedUpdate()
    {
        // get input from user
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // set move vector
        this._move_vector = (
            orientation.forward * vertical + orientation.right * horizontal
        ).normalized;

        // move object
        this._rb.MovePosition(this._rb.position + this._move_vector * this.speed * Time.deltaTime);
    }
}
