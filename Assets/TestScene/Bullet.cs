using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Range(0,100)]
    public float accuracy;
    public float timeLife;
    public float speed;

    void Start () {
        Destroy(this.gameObject, timeLife);
        transform.position += new Vector3(0, 0, 1);
        transform.rotation*=Quaternion.Euler(0,0, Random.Range(-(100-accuracy), 100-accuracy));
	}
	
    
	 
	void Update () {
        transform.Translate(Vector2.up*Time.deltaTime* speed);
	}
}
