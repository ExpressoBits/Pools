﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.PoolSimply;

public class Spawn : MonoBehaviour
{
    public float fireTime = 0.5f;
    public GameObject bulletPrefab;
    public float rangeRandomSize;

    private void Fire()
    {
        GameObject bullet = this.InstantiateInPool(bulletPrefab);
        bullet.transform.position = GetSpawnPosition(gameObject.transform.position);
    }

    private Vector3 GetSpawnPosition(Vector3 vector3)
    {
        return new Vector3(vector3.x + Random.Range(-rangeRandomSize, rangeRandomSize), vector3.y, vector3.z);
    }

    //Enable spawn fire balls
    private void OnEnable()
    {
        InvokeRepeating("Fire", fireTime, fireTime);
    }

    //Disable spawn fire balls
    private void OnDisable()
    {
        CancelInvoke("Fire");
    }
}
