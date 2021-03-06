﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Kugel : MonoBehaviour
{
    
    float damageperpellet;

    // Update is called once per frame

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Setup(UnityEngine.Vector3 shootdir, float bulletspeed, float damage)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootdir * bulletspeed, ForceMode.Impulse);

        damageperpellet = damage;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.transform.parent && other.transform.parent.CompareTag("Enemy"))
        {
            Target target1 = other.GetComponent<Target>();
            Target target2 = other.GetComponentInParent<Target>();

            if (target1 != null)
            {
                target1.TakeDamage(damageperpellet);
            }
            if (target2 != null)
            {
                target2.TakeDamage(damageperpellet);
            }
            Destroy(this.gameObject);
        }


        if (other.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
