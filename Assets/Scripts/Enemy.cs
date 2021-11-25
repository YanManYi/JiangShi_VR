using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public enum EnemyType { A, B, C }
public class Data { public int blood;public int kill; }
public class Enemy : MonoBehaviour {


    public EnemyType enemyType;
    Data data = new Data();
    int blood;

    Animator anim;
    NavMeshAgent nav;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        switch (enemyType)
        {
            case EnemyType.A:
                data.blood = 100;
                data.kill = 2;

                break;
            case EnemyType.B:
                data.blood = 120;
                data.kill = 3;
                break;
            case EnemyType.C:
                data.blood = 150;
                data.kill = 4;

                break;
            default:
                break;
        }
        blood = data.blood;

      pos = FindObjectOfType<Pvr_UnitySDKManager>().transform.position;
        nav.SetDestination(new Vector3 (pos.x,transform.position.y,pos.z));


    }
    Vector3 pos;

    float time_;
    private void Update()
    {
        //攻击
        time_ += Time.deltaTime;
        if (Vector3.Distance(transform.position, new Vector3(pos.x, transform.position.y, pos.z)) <=3f)
        {

            nav.isStopped = true;
         
            if (time_ >= 4)
            {
                time_ = 0;
                anim.SetTrigger("Attack");
                
             }
        }


        //颜色
        Image image = transform.GetComponentInChildren<Image>();
        image.fillAmount= (float)data.blood / blood;
        if (image.fillAmount<0.8f) {

            image.color = new Color(1,0.7f,0);

            if(image.fillAmount < 0.4f) image.color = new Color(1, 0f, 0);

        }


        if (FindObjectOfType<Player >().blood<=0|| FindObjectOfType<Player>().score>=30)
        {
            Destroy(gameObject);
        }
    }

   


    public void Damage() {

        data.blood -= 20;
        if (data.blood<=0)
        {
            //死亡
            anim.SetTrigger("Die");
            FindObjectOfType<Player>().score += data.kill;
            nav.enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject,1f);
        }


    }


    //Event
    public void ChangePlayerBlood() {

        FindObjectOfType<Player>().blood -= 5;
    }

}
