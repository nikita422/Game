using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Этот класс висит на геймобжекте корабля игрока и корабля противника
 Отвечает за изменение жизни, энергии, управляет отображением этой энергии на интерфейсе, обрабатывает пробития лазерами    
 */


public class Core : MonoBehaviour
{
   
    public StateBar stateBar; //Ссылка на скрипт stateBar состояния корабля, жизни и энергия.(пока пустая)
    GameObject prefHitExpl; //префаб взрыва, когда по твоему кораблю попадают.
    GameObject prefEndExpl;//префаб взрыва, когда у тебя заканчиваются жизни
    public bool isPlayer; // является ли корабль, к котому прикеплен это скрипт игроком?

    Transform enemyCameraTr;//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    public float curHealth, maxHealth, deltaHealth; //Сейчас жизни, макс жизни, сколько жизней прибавлять за секунду.
    public float curShield, maxShield, deltaShield;

    public AudioClip hitSound; // звуки
    AudioSource audio;

    //вызывается один раз при старте.
    void Start()
    {
        enemyCameraTr = GameObject.Find("CameraMinimap").transform;//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        prefEndExpl = Resources.Load("exp_big") as GameObject; //Загружаем префаб из ресурсов. Можно было бы и в редакторе драг энд дропо перенести.
        prefHitExpl = Resources.Load("Explosion") as GameObject;
         curHealth = maxHealth;
        curShield = maxShield;

        audio = GetComponent<AudioSource>();

        if (isPlayer)//получаем скрипт строки состояния корабля
        {
            stateBar = GameObject.Find("PlayerBar").GetComponent<StateBar>();
        }
        else
        {          
            stateBar = GameObject.Find("EnemyBar").GetComponent<StateBar>();
        }
    }

    void Update()
    {
        enemyCameraTr.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -7)  ;
       

    }

 
    public void changeHealthOn(float _value)//тоже самое что и сверху, только если жизни заканичаваютяс вызывается метод gameover();
    {
        curHealth += _value;
        if (curHealth < 0)
        {
            curHealth = 0;
            gameover();
        }      
        stateBar.changeHealth(maxHealth, curHealth);
    }

   

    public void gameover()
    {
         
        for (int i = 0; i < 4; i++)
        {//делаем 4 взрыва 
            GameObject exp = Instantiate(prefEndExpl, Random.insideUnitSphere+transform.position, Quaternion.identity);
            Destroy(exp, 1);
        }

        Destroy(this.gameObject);//уничтожаем геймобждект корабля игрока( тот, на котором висит this скрипт)
        Camera.main.GetComponent<Initilizaed>().RoundEnd(tag);
    }


    public void hit(Collider2D other, string _tagHit)//если по какой нибудь части корабля попали, то вызывается этот метод.
    {
            audio.PlayOneShot(hitSound, 1);
        GameObject expl;
        if (_tagHit == "Laser")
        {
            //spark
            expl = Instantiate(prefHitExpl, other.transform.position, Quaternion.identity);//спавним взрыв от попадания
            Destroy(expl, 0.8f);

            if (curShield < 10)
            {
                changeHealthOn(-10);
            }
            else
            {
                curShield -= 10;
            }

        }
        if (_tagHit == "Rocket")
        {
             //big boom
        }
        if (_tagHit == "Bullet")
        {
 
            //small boom
        }

        Destroy(other.gameObject);// уничтожаем лазер, который к нам прилетел
    }

}



//поиск ближайшего корабля
  //void findNearestTarget()
    //{
    //    List<GameObject> ships;
    //    if (isPlayer)
    //    {
    //        //ships = Camera.main.GetComponent<Strategy>().shipEnemy;
    //    }
    //    else
    //    {
    //       //  ships = Camera.main.GetComponent<Strategy>().shipPlayer;
    //    }

    //    float distCur,dist=999999;
    //    GameObject mabytarget=null;
    //    //for (int i = 0; i < ships.Count; i++)
    //    //{
    //    //    distCur = Vector2.Distance(transform.position, ships[i].transform.position);
    //    //    if (distCur < dist)
    //    //    {
    //    //        dist = distCur;
    //    //        mabytarget = ships[i];
    //    //    }
    //    //}

    //    target = mabytarget;
    //    if (target)
    //    {
    //      fireMangaer.addtarget(target);
    //    }
    //    if (target)
    //    {           
    //      //  move.set_target(target);
    //    }
    //}