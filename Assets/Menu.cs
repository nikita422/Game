using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

    
    List<string> nameShips;
    public Image img0,img1,img2;

    public Color aClr,Naclr;
    
    

 	void Start () {

        Naclr = img1.color;
        nameShips = Out.Saver.gamesave.getNamesShip();

       
         GameObject.Find("Slot0Text").GetComponent<Text>().text = nameShips[0];
         GameObject.Find("Slot1Text").GetComponent<Text>().text = nameShips[1];
         GameObject.Find("Slot2Text").GetComponent<Text>().text = nameShips[2];
    }
	
 


    public void setActiveSlot(int _n)
    {
        set_image(_n);

        
        Out.Saver.gamesave.setActiveShip(_n);
    }
    public void DEBUG_save()
    {
        Out.Saver.Save();
    }
    void set_image(int _n)
    {
        img0.color = Naclr;
        img1.color = Naclr;
        img2.color = Naclr;
         
        if (_n == 0)
        {
            img0.color = aClr;
        }
        if (_n == 1)
        {
            img1.color = aClr;
        }
        if (_n == 2)
        {
            img2.color = aClr;
        }

    }

    public void goEditor() {
       
       
        Application.LoadLevel("Editor");
    }
    public void goBattle()
    {
         
            Application.LoadLevel("Battle");
    }
}
