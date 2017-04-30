using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    public float speed; 
    void Start()
    {
        transform.position += new Vector3(0, 0, 1);
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
