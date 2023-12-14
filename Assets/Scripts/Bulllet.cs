using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulllet : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletTimeToLive = 3;
    public GameObject BloodDecay;
    public GameObject DirtEffect;
    public AudioClip HitSound;

    void Awake()
    {
        Destroy(gameObject, bulletTimeToLive);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        //if tag player then create blood decay particle
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(BloodDecay, collision.transform.position, collision.transform.rotation);
        }
        else
        {
            Instantiate(DirtEffect, collision.transform.position, collision.transform.rotation);
        }
        //play hit sound
        AudioSource.PlayClipAtPoint(HitSound, transform.position);
    }
}
