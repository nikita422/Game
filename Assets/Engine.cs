using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    
 	void Start () {
        transform.root.GetComponent<Move>().engineList.Add(this);
    }
	
    public void EngineOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void EngineOff()
    {
       transform.GetChild(0).gameObject.SetActive(false);
    }

 
}
