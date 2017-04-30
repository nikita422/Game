using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damages : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            transform.parent.parent.GetComponent<Core>().hit(collision,collision.tag);
        }
    }
}
