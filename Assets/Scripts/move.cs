using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 2.0f;
    private Vector3 _move_vector;

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set move vector
        this._move_vector = new Vector3(horizontal, 0.0f, vertical);

        // move object
        this._rb.MovePosition(this._rb.position + this._move_vector * this.speed * Time.deltaTime);
    }
}
