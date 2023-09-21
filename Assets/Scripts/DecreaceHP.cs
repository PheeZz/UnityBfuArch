using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaceHP : MonoBehaviour
{
    // Start is called before the first frame update
    private int _hp = 100;
    private Player player;

    void Start() { }

    void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponentInParent<Player>();
        player.hp -= 10;
        if (player.hp <= 0)
        {
            Destroy(player.gameObject);
        }
    }
}
