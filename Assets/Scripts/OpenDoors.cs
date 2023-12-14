using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    private Animator _animator;

    void Awake()
    {
        this._animator = this.GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("open");
        }
    }
}
