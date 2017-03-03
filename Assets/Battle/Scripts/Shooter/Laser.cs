using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    Transform tr;
    Vector3 direction;
    int speed;
    

    ////explosion
    //GameObject exp_p;

    void Start()
    {
        //explosion
      //  exp_p = Resources.Load("part_blast") as GameObject;
        tr = GetComponent<Transform>();
    }
    public void fire(Vector3 dir_, int speed_)
    {
        direction = dir_;
        speed = speed_;
        transform.LookAt(direction+transform.position);
        transform.Rotate(0, 90, 0);

    }

    void Update()
    {
        tr.Translate(direction * speed * Time.deltaTime, Space.World);
    }



    
    //попадание
    // public void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.gameObject.layer == LayerMask.NameToLayer("TargetEnemy"))
    //    {
    //        //other.GetComponentInParent<Core>().hit();
    //        print("hit!");
    //        ////explosion
    //        //GameObject exp = Instantiate(exp_p, transform.position, Quaternion.identity);
    //        //Destroy(exp, 1f);
    //        //Destroy(this.gameObject);
    //    }

    //}
}
