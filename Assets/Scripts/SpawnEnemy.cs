using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public Transform [] points;
    public GameObject[] enemys;


    private void Start()
    {
        InvokeRepeating("InvokeEnemy",1,7);
    }

    public void InvokeEnemy() {

        if (FindObjectOfType<Player>().blood > 0|| FindObjectOfType<Player>().score<30)
            Instantiate(enemys[Random.Range(0, 3)], points[Random.Range(0, 3)].position, Quaternion.identity).SetActive(true);
        else
            CancelInvoke();
    }

}
