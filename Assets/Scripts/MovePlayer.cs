using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 2.0f;
    private Vector3 _move_vector;
    public Transform orientation;

    void Awake()
    {
        // get position of object
        this._rb = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void FixedUpdate()
    {
        // get input from user
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // set move vector
        this._move_vector = (orientation.forward * vertical + orientation.right * horizontal).normalized;

        // move object
        this._rb.MovePosition(this._rb.position + this._move_vector * this.speed * Time.deltaTime);
    }
}
