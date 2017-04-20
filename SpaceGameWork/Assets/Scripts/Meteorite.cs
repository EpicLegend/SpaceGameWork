using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteorite : MonoBehaviour {


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("meteorite");
        if (collision.gameObject.tag == "Player")
        {
            // сообщение в лог о прикосновение с кораблем
            Messenger.Broadcast(GameEvent.SHIP_CONTACT_METEORITE);

             Vector3 forward = new Vector3(collision.transform.forward.x,
                                          collision.transform.forward.y,
                                          collision.transform.forward.z * -1);
             collision.gameObject.GetComponent<Rigidbody>().AddForce(forward * collision.rigidbody.mass, ForceMode.Force);
            

             Destroy(gameObject);
        }
    }

    
}
