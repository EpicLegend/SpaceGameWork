using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMeteorite : MonoBehaviour {

    [SerializeField]
    int x;
    [SerializeField]
    int y;
    [SerializeField]
    int z;
    [SerializeField]
    GameObject meteorite;
    [SerializeField]
    int max;

    // Use this for initialization
    void Start () {
        Messenger.RocketDesMet += Show;

        for (int i = 0; i < max; i++)
            Show();
	}

    void OnDestroy()
    {
        Messenger.RocketDesMet -= Show;
    }

    // создает метеорит
    void Show()
    {
        GameObject obj = Instantiate(meteorite);
        obj.transform.position = new Vector3(Random.Range(0 , x), Random.Range(0, y), Random.Range(0, z));
    }
}
