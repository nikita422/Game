using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fire_manager : MonoBehaviour
{
    //2
    Core core;

    [HideInInspector]
    public Transform target;

    public float maxFireDist = 20;

    [HideInInspector]
    public bool autoFire = false;

    public void setAutoFire(bool _af)
    {
        autoFire = _af;
    }

    private void Start()
    {
        core = GetComponent<Core>();

        if (this.gameObject.tag == "Player")
        {       
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        else
        {             
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public List<Laser_turret> turrets;

    public void addtarget(GameObject _target)
    {
        target = _target.transform;
    }

    public void removetarget()
    {
        target = null;
    }

    public void addTurret(Laser_turret _lt)
    {
        turrets.Add(_lt);
    }

    private void Update()
    {
        if (autoFire&&target)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < maxFireDist && core.curEnergy>30)
            {
                float time = Random.Range(0, 5f);
                StartCoroutine(fire_AI(time));
            }
        }
    }

    public void fire()
    {
        if (!target) return;
    
        for (int i = 0; i < turrets.Count; i++)
        {            
                turrets[i].fire(target.position);       
        }
    }


    IEnumerator fire_AI(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        fire();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if(target)
        Gizmos.DrawLine(transform.position, target.transform.position);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, maxFireDist);
    }

}






