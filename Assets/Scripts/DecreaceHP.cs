using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaceHP : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player;

    private Animator _animator;

    void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponentInParent<Player>();
        _animator = other.gameObject.GetComponentInParent<Animator>();
        player.hp -= 10;
        if (player.hp <= 0)
        {
            Destroy(player.gameObject);
        }
        _animator.SetTrigger("damaged");
    }
}
