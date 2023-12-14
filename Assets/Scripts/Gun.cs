using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public AudioClip shootSound;
    private Animator _animator;

    void Awake()
    {
        // get position of object
        this._animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) //LMB isn't working
        {
            // create bullet. shoot bullet on camera forward XYZ axis
            GameObject bullet = Instantiate(
                bulletPrefab,
                bulletSpawnPoint.position,
                Quaternion.identity
            );

            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            // play shoot sound
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            _animator.SetTrigger("shooting");
        }
    }
}
