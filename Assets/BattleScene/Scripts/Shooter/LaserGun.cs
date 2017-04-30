using System.Collections;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    
    GameObject prefLaser;

    AudioClip fireSound;
    AudioSource audio;

    private void Start()
    {
        fireSound = Resources.Load("Sound/fire_sound") as AudioClip;
        audio     = GetComponent<AudioSource>();

        prefLaser = Resources.Load("Prefab/Laser") as GameObject;
        transform.GetComponentInParent<Fire_manager>().addLaserGun(this);

        if (transform.root.tag == "Player")
        {
            prefLaser.layer = LayerMask.NameToLayer("TargetEnemy");
        }
        if (transform.root.tag == "Enemy")
        {
            prefLaser.layer = LayerMask.NameToLayer("TargetPlayer");
        }
    }

    public void fire()
    {
        StartCoroutine("fire");
    }

    //нужен только из за временной задержки
    IEnumerator firer(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        audio.PlayOneShot(fireSound, 1);
        Instantiate(prefLaser, transform.position, transform.rotation);
    }
}
