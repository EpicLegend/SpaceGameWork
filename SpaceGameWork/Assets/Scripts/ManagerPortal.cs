using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPortal : MonoBehaviour {

    [SerializeField]
    int level;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(level);
    }
}
