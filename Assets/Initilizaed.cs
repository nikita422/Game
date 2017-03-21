using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initilizaed : MonoBehaviour {

    /*
     класс работающий перед началом боля
     иницилизирует два корабля, собирает их
     Дает старт боя
     возможно играет типо влет из простарнства    
                  
         */
    Ship playerShip;
    Ship enemyShip;
    
    GameObject PlayerCoreBlock;
    GameObject EnemyCoreBlock;
    

	void Start () {

 
        PlayerCoreBlock = GameObject.FindGameObjectWithTag("Player");
        EnemyCoreBlock = GameObject.FindGameObjectWithTag("Enemy");

        
       // initShip(true, Out.Saver.NowShips.blocks);
        //сделать редактор и инит второй шип
    }
	
   
     

    void initShip(bool _isPlayer, List<Ship.Block> _blocks)
    {
        Transform tr_parent;
        if (_isPlayer)
        {
            tr_parent = PlayerCoreBlock.transform.FindChild("Sprite").transform;
        }
        else
        {
            tr_parent = EnemyCoreBlock.transform.FindChild("Sprite").transform;
        }

        for (int i = 0; i < _blocks.Count; i++)
        {
            GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlock/" + _blocks[i].name, typeof(GameObject)),tr_parent );
            block.transform.position = _blocks[i].pos;
        }
        if (_isPlayer)
        {
            PlayerCoreBlock.SetActive(false);
        }
        else
        {
            EnemyCoreBlock.SetActive(false);
        }
    }

    public void go()
    {
        EnemyCoreBlock.SetActive(true);
        PlayerCoreBlock.SetActive(true);
    }



}
