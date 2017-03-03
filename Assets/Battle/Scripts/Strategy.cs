using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject((Input.GetTouch(0).fingerId)) && !virtual_jostic.is_on_joystick)
public class Strategy : MonoBehaviour
{

   
    public GameObject shipPlayer;
    public LayerMask lm;
    FireBtn fireBtn;
    

    public GameObject lineTarget;
    public bool is_interact;//for linetarget

   


    private void Start()
    {
        fireBtn = GameObject.FindGameObjectWithTag("fireBtn").GetComponent<FireBtn>();
        shipPlayer = GameObject.FindGameObjectWithTag("Player");    
    }



    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            float kZoom = Camera.main.orthographicSize;


            Vector3 moupos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mouposz0 = new Vector3(moupos.x, moupos.y, 0);

            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mouposz0, kZoom / 6, lm);
            if (hitColliders.Length != 0)
            {

                if (hitColliders.Length > 1)
                {
                    Collider2D col;
                    float dist = Vector2.Distance(hitColliders[0].transform.position, mouposz0);
                    col = hitColliders[0];

                    for (int i = 1; i < hitColliders.Length; i++)
                    {
                        float newDist = Vector2.Distance(hitColliders[i].transform.position, mouposz0);
                        if (dist > newDist)
                        {
                            col = hitColliders[i];
                            dist = newDist;
                        }
                    }
                    hitColliders[0] = col;
                }

                if (hitColliders[0].gameObject.transform.parent.gameObject.tag == "Player")
                {
                    is_interact = true;
                }

                //если кораблей несколько, добаялвем выбор разных целей, а так ппо
                //if (is_interact && hitColliders[0].gameObject.transform.parent.gameObject.tag == "Enemy")
                //{
                //    shipPlayer.GetComponent<Fire_manager>().target = hitColliders[0].gameObject.transform.parent.gameObject.transform;                }           
                //}

            }





            if (is_interact)
            {
                lineTarget.SetActive(true);

                Vector3 input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 ship = shipPlayer.transform.position;
                Vector3 line1 = new Vector3(ship.x, ship.y, 5);
                Vector3 line2 = new Vector3(input.x, input.y, 5);

                lineTarget.GetComponent<LineRenderer>().SetPosition(0, line1);
                lineTarget.GetComponent<LineRenderer>().SetPosition(1, line2);


            }
            else
            {
                lineTarget.SetActive(false);
            }

            if (Input.GetMouseButtonUp(0) && is_interact)
            {
                shipPlayer.GetComponent<Move>().go_to(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                is_interact = false;
            }
        }
    }


     

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Vector3 moupos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector3 mouposz0 = new Vector3(moupos.x, moupos.y, 0);

    //    float kZoom = Camera.main.orthographicSize;
       

    //    Gizmos.DrawSphere( mouposz0, kZoom/6);
    //}
}
