using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour {

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform gun;

    Menu menu;
    
    void Start () {
        menu = GetComponent<Menu>();
    }
	
	void Update () {

        // Здесь можно еще поставить таймер и релоад пушки 
        if (!menu.isPaused)
            if (Input.GetMouseButton(0))
            {
                GameObject Bullet = Instantiate(bullet);
                Bullet.transform.position = gun.position;
                Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
                Debug.Log("Atack");
            }
	}
}
