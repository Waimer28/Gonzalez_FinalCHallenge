﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distory : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" )
        {
            Destroy(collision.collider.gameObject);
        }
    }
}