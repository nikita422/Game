using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{
    //0.2
    //динамичная часть

    public List<Ship> ships;
    public List<string> nameShips;    
    public int numberAct;
 


    public Save()
    {   

        nameShips = new List<string>();
        ships = new List<Ship>();
        
    }
    public void setActiveShip(int _n)
    {
        
        numberAct = _n;
         
    }
    public List<string> getNamesShip()
    {
        while (nameShips.Count != 3)
        {       
            nameShips.Add("EmptySlot");
        }
         
        return nameShips;
    }
    public void saveActiveShip(Ship _ship)
    {
         
        ships[numberAct] = _ship;
    }
    public Ship getActiveShip()
    {
        while (ships.Count != 3)
        {
            ships.Add(new Ship());
        }
        
        return ships[numberAct];
    }
}
