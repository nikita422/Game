using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public GameObject gun;
    public float maxFireDist = 20;

    void Start () {
         gun.AddComponent<LaserGun>();
	}
	
    public void fire()
    {
        target = transform.GetComponentInParent<Fire_manager>().target;
        if (Vector2.Distance(transform.position, target.transform.position) < maxFireDist)   
        gun.GetComponent<LaserGun>().fire();
    }

 	void Update () {
        if (target)
        {
            var dir = target.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
