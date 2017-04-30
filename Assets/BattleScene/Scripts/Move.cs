using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 Этот класс висит на геймобжекте корабля игрока и корабля противника
 Отвечает за передвижение корабля, обрабатывает  input  
 */

public class Move : MonoBehaviour
{
    /*
     корабль двигается плохо, совсем не похож на большой и мощный 
     
     Сделать чтобы турели стреляли некоторые вперед только а некоторые и вращаться могли 
         
         
         
         
         
         */




    public float targetBetweenShip;//переменная для аи врага, выставляем здесь расстояние между кораблями
    public Vector3 target_position;//куда летим?
    public GameObject target;//enemy only
    Core core;//ссылка на ядро, чтобы брать энергию 
    public List<Engine> engineList;

    public bool move = false; // двигаемся ли?
    public float maxSpeed=4, curSpeed;//максимальная скорость, скорость нынешняя
    public float rotateSpeed=4;//скорость поворота


   
    private void Start()
    {
        engineList = new List<Engine>();
        core = GetComponent<Core>();//получаем скрипт, который висит на том же объекте что и этот скрипт
        if (!core.isPlayer)//узнаем являемся ли мы враго или игроком
        {
            target = GameObject.FindGameObjectWithTag("Player");//сразу находим цель для врага
         //   StartCoroutine("enemyBrain");//если раскоментить то корабль врага сразу после старта боя полетит на тебя воевать.
        }
        
    }
  
    public void goON()
    {
        //DEBUG нужно для того, чтобы корабль врага начал воевать толкьо по нажатию кнопки на интрефейсе
        StartCoroutine("enemyBrain"); // запускаем со-программу (она ниже)
        GetComponent<Fire_manager>().autoFire = true;//запускаем режим автоматического ведения огня
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
               
                if (Vector2.Distance(transform.position, target_position) > 10)
                {
                    curSpeed = Mathf.SmoothStep(curSpeed, maxSpeed, 0.1f);
                }
                else
                {
                    curSpeed = Mathf.SmoothStep(curSpeed, 0, 0.1f);
                }
            }
            else
            {

                if (Vector2.Distance(transform.position, target_position) > 1)
                {
                    curSpeed = Mathf.SmoothStep(curSpeed, maxSpeed, 0.1f);
                }
                else
                {
                    if (angle < 5)
                    {
                        move = false;
                        allEngineMode(false);
                    }
                    curSpeed = Mathf.SmoothStep(curSpeed, 0, 0.1f);
                    if (curSpeed < 0.1)
                    {
                        move = false;
                        allEngineMode(false);
                    }
                }
            }
            Vector3 relativePos = target_position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.back);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);//rotate this!


        }

        transform.Translate(0, curSpeed * Time.deltaTime, 0);
        
    }

    void allEngineMode(bool _go)
    {
        if (_go)
        {
            for (int i = 0; i <engineList.Count; i++)
            {
                engineList[i].EngineOn();
            }
        }
        else
        {
            for (int i = 0; i < engineList.Count; i++)
            {
                engineList[i].EngineOff();
            }
        }
    }

    public void go_to(Vector3 pos)
    {
        target_position = pos;
        move = true;
        allEngineMode(true);
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
                    target_position = target.transform.position + targetBetweenShip * (target.transform.right);
                }
                else
                {
                    target_position = target.transform.position + targetBetweenShip * (-target.transform.right);
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
