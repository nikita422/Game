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
     
    
   public GameObject PlayerCoreBlock;
    public GameObject EnemyCoreBlock;

    public LayerMask playerLayer;
    public LayerMask enemyLayer;

	void Start () {

 
        PlayerCoreBlock = GameObject.FindGameObjectWithTag("Player");
        EnemyCoreBlock = GameObject.FindGameObjectWithTag("Enemy");

        
        initShip(true, Out.Saver.gamesave.ships[Out.Saver.gamesave.numberAct].blocks);
        initShip(false, Out.Saver.gamesave.ships[2].blocks);
         

    }
	
     public void GoMenu()
    {
        Application.LoadLevel("Menu");
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
            GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlock/" + _blocks[i].name, typeof(GameObject)),tr_parent);
            
            block.transform.position = _blocks[i].pos+ (Vector2)tr_parent.position;
            block.transform.rotation = tr_parent.rotation;
            if (_isPlayer)
            {
                block.layer =LayerMask.NameToLayer("TargetPlayer");
            }
            else
            {
                block.layer = LayerMask.NameToLayer("TargetEnemy");
            }
        }
        if (!_isPlayer)
        {
             //EnemyCoreBlock.transform.position = new Vector3(0, 22, 0);
        }
    }

    



}
