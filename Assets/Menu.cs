using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

   
    List<string> nameShips;
    Text nowshiptext;
     
    public int nowShip;

 	void Start () {
        nowshiptext = GameObject.Find("NowShipText").GetComponent<Text>();
        nameShips = Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<List<string>>("C:/ships.xml");
        GameObject.Find("Slot1").transform.GetChild(0).GetComponent<Text>().text = nameShips[0];
        GameObject.Find("Slot2").transform.GetChild(0).GetComponent<Text>().text = nameShips[1];
 
    }
	
 
	void Update () {
		
	}

    public void setActiveSlot(int _n)
    {
        nowShip = _n;
        nowshiptext.text = "Now ship:" + nowShip;
    }

    public void goEditor() {


    }


}
