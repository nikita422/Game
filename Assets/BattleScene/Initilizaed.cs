using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initilizaed : MonoBehaviour {

    /*
     класс работающий перед началом боля
     иницилизирует два корабля, собирает их
     Дает старт боя
     возможно играет типо влет из простарнства    
          
        
     будет фиксированный старт 
        
                
         */

    public GameObject WinLose;

    public GameObject PlayerCoreBlock;
    //public GameObject EnemyCoreBlock;
    bool already = false;
    public GameObject prefEnemyShip;

    public LayerMask playerLayer;
    public LayerMask enemyLayer;

	void Start () {

 
        PlayerCoreBlock = GameObject.FindGameObjectWithTag("Player");
        //EnemyCoreBlock = GameObject.FindGameObjectWithTag("Enemy");

        
        initShip(true, Out.playerProfile.ships[Out.playerProfile.numberAct].blocks);
        //  initShip(false, Out.Saver.gamesave.ships[2].blocks);
       GameObject enemyShip= Instantiate(prefEnemyShip, new Vector2(0, 20), Quaternion.identity);
       enemyShip.transform.rotation = new Quaternion(0, 0, 180,0);
        PlayerCoreBlock.transform.position = new Vector3(0, -100, 0);

    }
	
     public void GoMenu()
    {
        Application.LoadLevel("Menu");
    }


    private void Update()
    {
        if (!already) warp();
        
    }

    void warp()
    {
        if (PlayerCoreBlock.transform.position.y < -0.09)
        {
            PlayerCoreBlock.transform.position = Vector3.Lerp(PlayerCoreBlock.transform.position, Vector3.zero, 0.02f);
        }
        else
        {
            if (Camera.main.transform.position.y < 6.9)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(0, 7, -10), 0.02f);
            }
            else
            {
                already = true;
            }
        }
    }


    void initShip(bool _isPlayer, List<Ship.Block> _blocks)
    {
        Transform tr_parent;
       // if (_isPlayer)
       // {
            tr_parent = PlayerCoreBlock.transform.FindChild("Sprite").transform;//&&&&&&&&&7&&&&&&&&&&&&&&&&&&&&&777
       // }
        //else
        //{
          
        //  //  tr_parent = EnemyCoreBlock.transform.FindChild("Sprite").transform;
        //}
         for (int i = 0; i < _blocks.Count; i++)
        {
            GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlockEditor/" + _blocks[i].name, typeof(GameObject)),tr_parent);
            
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

            if (_blocks[i].name == "22")
            {
                block.AddComponent<LaserGun>();
                block.AddComponent<AudioSource>();
            }
            if (_blocks[i].name == "23")
            {
                block.AddComponent<Cannon>();
            }
            if (_blocks[i].name == "24")
            {
                block.AddComponent<Turret>();
            }
            if (_blocks[i].name == "18" || _blocks[i].name == "19")
            {
                block.AddComponent<Engine>();
            }
            if (_blocks[i].name == "17")
            {
                block.AddComponent<RockerLauncher>();
            }
            block.AddComponent<Damages>();

        }
        if (!_isPlayer)
        {
             //EnemyCoreBlock.transform.position = new Vector3(0, 22, 0);
        }
    }

    
    public void RoundEnd(string _tagLose)
    {
        if (_tagLose == "Player")
        {
            WinLose.GetComponent<WinLose>().lose();
        }
        if (_tagLose == "Enemy")
        {
            WinLose.GetComponent<WinLose>().win();
        }
    }


}
