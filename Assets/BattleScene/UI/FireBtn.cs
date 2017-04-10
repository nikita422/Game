using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBtn : MonoBehaviour {

    Button firebtn;
    GameObject ship;

    void Start () {
        firebtn = GetComponent<Button>();
        firebtn.onClick.AddListener(onClick);
        ship = GameObject.FindGameObjectWithTag("Player");
	}
	
    
    void onClick()
    {    
        if (ship)
        {         
            ship.GetComponent<Fire_manager>().fire();
        }
    }

	 
}
