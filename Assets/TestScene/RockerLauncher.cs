using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockerLauncher : MonoBehaviour {

    GameObject prefBullet;

    private void Start()
    {
        prefBullet = Resources.Load("Prefab/Rocket") as GameObject;
        transform.GetComponentInParent<Fire_manager>().addRocketLauncher(this);

        if (transform.root.tag == "Player")
        {
            prefBullet.layer = LayerMask.NameToLayer("TargetEnemy");
        }
        if (transform.root.tag == "Enemy")
        {
            prefBullet.layer = LayerMask.NameToLayer("TargetPlayer");
        }

    }

    public void fire()
    {
        StartCoroutine("fireIEnumerator");
    }

    //нужен только из за временной задержки
    IEnumerator fireIEnumerator()
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        //  audio.PlayOneShot(fireSound, 1);
        Instantiate(prefBullet, transform.position, transform.rotation);
    }
}
