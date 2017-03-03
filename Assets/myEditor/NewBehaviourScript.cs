using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    /*
     Кнопка открывающая меню
         
         
         
         
         
         */


    public GameObject curBlock;

    void Start () {
		
	}
    public void print(string _name)
    {
        switch (_name)
        {
            case "1":
                {
                     
                }
                break;

            case "2":
                break;
            case "3":
                break;


            default:
                break;
        }
    }

    
	
 	void Update () {

        if (curBlock)
        {
            curBlock.transform.position = Vector2.Lerp(curBlock.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.5f);
        }
        /*
         расчет size и сетка тут



        
         
         
         
         */

	}
}
