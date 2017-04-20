using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPortal : MonoBehaviour {

    [SerializeField]
    int level;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Messenger.Broadcast(GameEvent.SHIP_USED_PORTAL);
            SceneManager.LoadScene(level);
        }
    }
}
