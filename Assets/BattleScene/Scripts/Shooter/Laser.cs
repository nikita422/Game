using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour {
    
    [Range(0, 100)]
    public float accuracy;
    public int speed;
    public float timeLife;

    void Start()
    {
        transform.position += new Vector3(0, 0, 1);
        transform.rotation *= Quaternion.Euler(0, 0, Random.Range(-(100 - accuracy), 100 - accuracy));
        Destroy(this.gameObject, timeLife); 
    }
    
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    
}
