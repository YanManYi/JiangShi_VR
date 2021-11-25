using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class Ak : MonoBehaviour {

    public Transform Bullet;

    private void Update()
    {
        if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.TRIGGER) || Input.GetMouseButtonDown(1))
        {
            Transform  gg = Instantiate(Bullet);
            gg.position = transform.Find("pos").position;
            gg.rotation= transform.Find("pos").rotation ;

            GetComponent<AudioSource>().Play();

        }
    }
}
