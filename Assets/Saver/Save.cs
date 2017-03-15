using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{
    public List<Ship> ships;
    public List<string> nameShips;

    public Save()
    {
        nameShips = new List<string>();
        ships = new List<Ship>();
 
    }


    public void saveActiveShip(Ship _ship)
    {   
        for (int i = 0; i < nameShips.Count; i++)
        {
            
            if (nameShips[i] == _ship.name)
            {
                ships[i] =Out.Saver.NowShips;//tut pizdec
                ships[i] = _ship;
                nameShips[i] = _ship.name;
            }
        }        
    }
}
