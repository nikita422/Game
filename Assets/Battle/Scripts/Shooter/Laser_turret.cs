using System.Collections;
using UnityEngine;

public class Laser_turret : MonoBehaviour
{
    Core core;
    GameObject laser;

    AudioClip impact;
    AudioSource audio;

    //можно поворачивать туррель в эту сторону
    Vector3 direction;

    /// <summary>
    int laser_speed = 50;
    float accuracy = 0.1f;
    /// </summary>

    
    

    private void Start()
    {
         transform.parent.GetComponent<Fire_manager>().addTurret(this);
        if (transform.parent.tag == "Player")
        {
            laser = Resources.Load("Laser") as GameObject;
            
        }
        else
        {
            laser = Resources.Load("LaserEnemy") as GameObject;
        }
        impact = Resources.Load("fire_sound") as AudioClip;
        audio = GetComponent<AudioSource>();       
         core = transform.parent.GetComponent<Core>();   
    }

    public void fire(Vector3 _target)
    {
        Vector3 heading = -transform.position + _target;
        var distance = heading.magnitude;
        direction = heading / distance;
        //if (Vector3.Dot(heading, this.transform.forward) < 0) {
        //    print("no_shoot");
        //    return;

        //}//нужно вычислить можно ли стрелять или нет
        float time = Random.Range(0, 1f);

        Vector3 accuracyVec = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy),0);

        if (core.curEnergy > 5)
        {
            core.curEnergy -= 5;
            
            StartCoroutine(fire_laser(direction+accuracyVec, time));            
        }
            
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + direction);
    }


    //нужен только из за временной задержки
    IEnumerator fire_laser(Vector3 _direction, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        audio.PlayOneShot(impact, 1);
        GameObject g = Instantiate(laser, transform.position, Quaternion.identity);
        g.GetComponent<Laser>().fire(_direction, laser_speed);
        Destroy(g, 2f);

    }
}
