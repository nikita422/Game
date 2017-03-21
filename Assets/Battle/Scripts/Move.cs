using UnityEngine;
using System.Collections;
/*
 * 3
Rsponsibility: плавное передвижение
Duality:       true    
     
    вынести поиск врага наружу


    -:
    
     
*/


public class Move : MonoBehaviour
{

    public float targetDistance;//расстояния до цели когда борт в борт  для енеми
    public Vector3 target_position;
    public GameObject target;//enemy only
    Core core;

    public bool move = false;
    public float maxSpeed, curSpeed;
    public float rotateSpeed;

    private void Start()
    {
        core = GetComponent<Core>();
        if (!core.isPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player");
         //   StartCoroutine("enemyBrain");
        }
        
    }

    public void goON()
    {
        StartCoroutine("enemyBrain");
    }


    void Update()
    {
        if (move)
        {
            Vector3 tar = new Vector3(target_position.x, target_position.y, 0);
            Vector2 v1 = tar - transform.position;
            Vector2 v2 = transform.up;

            var sign = Mathf.Sign(v1.x * v2.y - v1.y * v2.x);
            float angle = Vector2.Angle(tar - transform.position, transform.up);
            
            if (angle > 30)
            {
                curSpeed = Mathf.SmoothStep(curSpeed, 0, 0.1f);
            }
            else
            {
                if (Vector2.Distance(transform.position, target_position) > 1)
                {
                    curSpeed = Mathf.SmoothStep(curSpeed, maxSpeed, 0.1f);
                }
                else
                {
                    curSpeed = Mathf.SmoothStep(curSpeed, 0, 0.1f);
                    if (curSpeed < 0.01)
                    {
                        move = false;
                    }
                }
            }
            Vector3 relativePos = target_position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.back);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1f);//rotate this!


        }

        transform.Translate(0, curSpeed * Time.deltaTime, 0);
    }

    

    public void go_to(Vector3 pos)
    {
        target_position = pos;
        move = true;
    }

    IEnumerator enemyBrain()
    {
        while (target) //variable that enables you to kill routine
        {

            {
                Vector3 cameraRelative = target.transform.InverseTransformPoint(transform.position);
                if (cameraRelative.x > 0)
                {
                    //right
                    target_position = target.transform.position + targetDistance * (target.transform.right);
                }
                else
                {
                    target_position = target.transform.position + targetDistance * (-target.transform.right);
                    //left
                }

                go_to(target_position);
                yield return new WaitForSeconds(1f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color =  Color.red;
        if (target)
            //Gizmos.DrawLine(transform.position, target_position);
            Gizmos.DrawLine(transform.position, target_position);
    }

}
