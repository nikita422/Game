using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fire_manager : MonoBehaviour
{
    
    Core core;

   // [HideInInspector]
    public Transform target;

    public float reloadCannon, reloadLaser, reloadRocket,reloadTurret;
 
   // [HideInInspector]
    public bool autoFire = false;

    public void setAutoFire(bool _af)
    {
        autoFire = _af;
    }

    private void Start()
    {
        core = GetComponent<Core>();

        if (this.gameObject.tag == "Enemy")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
       
    }

    public List<LaserGun> LaserGuns;
    public List<Cannon> cannons;
    public List<RockerLauncher> rocketLaunchers;
    public List<Turret> turrets;

    public void addCannon(Cannon _cannon)
    {
        cannons.Add(_cannon);
    }
    public void addRocketLauncher(RockerLauncher _rocketLauncher)
    {
        rocketLaunchers.Add(_rocketLauncher);
    }
    public void addtarget(GameObject _target)
    {
        target = _target.transform;
    }
    public void addLaserGun(LaserGun _lt)
    {
        LaserGuns.Add(_lt);
    }



    public void removetarget()
    {
        target = null;
    }

    private void Update()
    {
        reloadGuns();
        if (autoFire&&target)
        {
            fireTurrets();
        }
    }

    void reloadGuns()
    {
        if (reloadCannon < 100)
        {
            if (reloadCannon < 0)
            {
                reloadCannon = 0;
            }
            reloadCannon += 1;
        }
        if (reloadLaser < 100)
        {
            if (reloadLaser < 0)
            {
                reloadLaser = 0;
            }
            reloadLaser += 1;
        }
        if (reloadRocket < 100)
        {
            if (reloadRocket < 0)
            {
                reloadRocket = 0;
            }
            reloadRocket += 1;
        }
        if (reloadTurret < 100)
        {
            if (reloadRocket < 0)
            {
                reloadRocket = 0;
            }
            reloadRocket += 1;
        }
    }

    public void fireTurrets()
    {
        if (!target)
        {
            if (!isFindTarget()) return;
        }
    
        for (int i = 0; i < turrets.Count; i++)
        {
            if (reloadLaser > 20)
            {
                reloadTurret -= 20;
                turrets[i].fire();
            }      
        }
    }


    

    public void fireCannons()
    {
        for (int i = 0; i < cannons.Count; i++)
        {
            if (reloadCannon > 0)
            {
                reloadCannon -= 20;
                cannons[i].fire();
            }
            
        }
    }
    public void fireRockets()
    {
        for (int i = 0; i < rocketLaunchers.Count; i++)
        {
            if (reloadRocket > 20)
            {
                reloadRocket -= 20;
                rocketLaunchers[i].fire();
            }
        }
    }
    public void fireLaserGuns()
    {
        for (int i = 0; i < LaserGuns.Count; i++)
        {
            if (reloadLaser > 20)
            {
                reloadLaser -= 20;
                LaserGuns[i].fire();
            }
        }
    }

    bool isFindTarget()
    {
        if (this.gameObject.tag == "Enemy")
        {
            return false;
        }
        if (this.gameObject.tag == "Player")
        {
            target= GameObject.FindGameObjectWithTag("Enemy").transform;
            return true;
        }
        return false;
    }

    IEnumerator fire_AI()
    {
        yield return new WaitForSeconds(Random.Range(0, 5f));
        fireTurrets();     
    }
 

}






