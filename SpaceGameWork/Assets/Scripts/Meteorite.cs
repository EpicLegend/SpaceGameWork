using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteorite : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // сообщение в лог о прикосновение с кораблем
            // Messenger.Broadcast(GameEvent.SHIP_CONTACT_METEORITE);
            Messenger.ShipContactMeteorite();


        }
    }

    
}
