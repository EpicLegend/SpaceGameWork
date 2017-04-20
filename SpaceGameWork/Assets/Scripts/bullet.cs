﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "meteorite")
        {
            Messenger.Broadcast(GameEvent.ROCKET_DESTROY_METEORITE);
            Messenger.Broadcast(GameEvent.ENEMY_HIT);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
