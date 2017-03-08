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
    List<string> shipsName;
    
    GameObject PlayerCoreBlock;
    GameObject  EnemyCoreBlock;
    

	void Start () {
        shipsName = new List<string>();
        //shipsName= Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<List<string>>("C:/ds.xml");

        PlayerCoreBlock = Instantiate<GameObject>(Resources.Load("starter") as GameObject);
        PlayerCoreBlock.tag = "Player";

        EnemyCoreBlock = Instantiate<GameObject>(Resources.Load("starter") as GameObject);
        EnemyCoreBlock.tag = "Enemy";

        

        //initShipp(true,"ds");

    }
	
     

    void initShipp(bool _isPlayer, string _name)
    {
        Transform tr_parent;
        if (_isPlayer)
        {
            tr_parent = PlayerCoreBlock.transform;
        }
        else
        {
            tr_parent = EnemyCoreBlock.transform;
        }
        List<Ship.Block>  pBlocks = new List<Ship.Block>();
        Ship pShip = Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<Ship>("C:/" + _name + ".xml");
        pBlocks = pShip.blocks;
        for (int i = 0; i < pBlocks.Count; i++)
        {
            GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlock/" + pBlocks[i].name, typeof(GameObject)),tr_parent );
            block.transform.position = pBlocks[i].pos;
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
        PlayerCoreBlock.SetActive(false);
    }



}
