using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

    
    List<string> nameShips;
     
     
    public int nowShip;

 	void Start () {
     
        nameShips = Out.Saver.save.nameShips;
      
        GameObject.Find("Slot1").transform.GetChild(0).GetComponent<Text>().text = nameShips[0];
        //GameObject.Find("Slot2").transform.GetChild(0).GetComponent<Text>().text = nameShips[1]  
    }
	
 


    public void setActiveSlot(int _n)
    {
        nowShip = _n;
        Out.Saver.NowShips = Out.Saver.save.ships[_n - 1];
        //nowshiptext.text = "Now ship: " + nameShips[_n-1];
    }

    public void goEditor() {
       
         if(nowShip!=0)
        Application.LoadLevel("Editor");
    }
    public void goBattle()
    {
        if (nowShip != 0)
            Application.LoadLevel("Battle");
    }
}
