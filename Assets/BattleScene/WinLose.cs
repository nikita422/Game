using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinLose : MonoBehaviour {

    public Text moneyText;
 	void Start () {
		
	}
	
 	 
   public void win()
    {
        Out.playerProfile.playerMoney += 600;
        moneyText.text = "600";
        transform.position = new Vector3(0, 0, 0);
    }
    public void lose()
    {
        Out.playerProfile.playerMoney += 100;
        moneyText.text = "100";
        transform.position = new Vector3(0, 0, 0);
    }

    public void goMenu()
    {
        Application.LoadLevel("Menu");
    }
}
