using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
    [Range(1,30)]
 public    int force;

	void Start () {

        GetComponent<Rigidbody>().velocity = transform.forward * force;
        Destroy(gameObject,4);
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Btn") { other.GetComponent<Button>().onClick.Invoke(); }

        if (other.tag=="Enemy")
        {
            //扣血
            
            other.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
            
        }



    }

   
}
