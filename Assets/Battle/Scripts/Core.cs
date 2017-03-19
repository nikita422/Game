using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    /*/***1
   nez instan
         
         */



    public StateBar stateBar;
    GameObject hit_explosion;
    public bool isPlayer;
 

    public float curHealth, maxHealth, deltaHealth;
    public float curEnergy, maxEnergy, deltaEnergy;
    //shielD

    GameObject expl;

    

    void Start()
    { 

        expl = Resources.Load("exp_big") as GameObject;
        hit_explosion = Resources.Load("exp") as GameObject;
        curEnergy = maxEnergy;
        curHealth = maxHealth;

        if (isPlayer)
        {
            stateBar = GameObject.FindGameObjectWithTag("canvas").transform.FindChild("PlayerBar").GetComponent<StateBar>();
        }
        else
        {
            stateBar = GameObject.FindGameObjectWithTag("canvas").transform.FindChild("EnemyBar").GetComponent<StateBar>();
        }
    }

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


    void Update()
    {

        if (curEnergy < maxEnergy)
        {
            changeEnergyOn(deltaEnergy);
        }
        else
        {
            curEnergy = maxEnergy;
        }
 

    }

    public void changeEnergyOn(float _value)
    {

        curEnergy += _value;
        if (curEnergy < 0)
        {
            curEnergy = 0;
        }
        stateBar.changeEnergy(maxEnergy, curEnergy);

    }
    public void changeHealthOn(float _value)
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
        {
            GameObject exp = Instantiate(expl, Random.insideUnitSphere+transform.position, Quaternion.identity);
            Destroy(exp, 2);
        }
     
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Laser")
        {
           
                GameObject expl = Instantiate(hit_explosion, other.transform.position, Quaternion.identity);
                Destroy(expl, 0.8f);
                curHealth -= 5;
                Destroy(other.gameObject);
            
        }

    }
}
