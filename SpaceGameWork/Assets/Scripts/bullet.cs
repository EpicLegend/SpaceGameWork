using System.Collections;
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
            // Вызов событий
            Messenger.RocketDestroyMeteorite();
            Messenger.EnemyHit();

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
