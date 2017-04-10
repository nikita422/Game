using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Editor : MonoBehaviour
    
{
    /*
     * типо если блоков нет, то нормик грузи только парента
     редактор    
     слотовая система сохраненийы
         */
  
    GameObject parent;
    public Text nameShipText;
    public string nameship;
    public GameObject curBlock;

   

    void Start()
    {
       // loadShip(); mobile bag
        parent = GameObject.Find("Parent");

        
    }

    

    public void instance(int _n)
    {
       if (curBlock) Destroy(curBlock);

        //curBlock = Instantiate((GameObject)Resources.Load("ShipsBlockEditor/" + _n.ToString(), typeof(GameObject)),new Vector3(1,0,0)+parent.transform.position,Quaternion.identity, parent.transform);
        
        
        curBlock.transform.tag = "EditorOnly";
         
    }

    public void instance(string name,Vector2 _pos)
    {
        if (!parent)
        {
            parent = GameObject.Find("Parent");
        }
       GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlockEditor/" + name, typeof(GameObject)), parent.transform);
       block.transform.position = _pos;
       block.tag = "EditorOnly";
    }


    void Update()
    {

        
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && curBlock)
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        Destroy(curBlock);
        //    }
        //    curBlock = null;
        //}
         
        //if (Input.touchCount > 0 && curBlock)   
        //{                  
        //        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);               
        //        Vector2 intPos = new Vector2(Mathf.CeilToInt(pos.x / 0.65f) * 0.65f, Mathf.CeilToInt(pos.y / 0.65f) * 0.65f);
        //    //curBlock.transform.position = Vector2.Lerp(curBlock.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.5f);
             
        //    curBlock.transform.position = intPos;                    
        //}

        //if (Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject() && !curBlock)
        //{

        //    float kZoom = Camera.main.orthographicSize;


        //    Vector3 moupos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    Vector3 mouposz0 = new Vector3(moupos.x, moupos.y, 0);

        //    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mouposz0, kZoom / 6);//what about layers, bitch?
        //    if (hitColliders.Length != 0)
        //    {

        //        if (hitColliders.Length > 1)
        //        {
        //            Collider2D col;
        //            float dist = Vector2.Distance(hitColliders[0].transform.position, mouposz0);
        //            col = hitColliders[0];

        //            for (int i = 1; i < hitColliders.Length; i++)
        //            {
        //                float newDist = Vector2.Distance(hitColliders[i].transform.position, mouposz0);
        //                if (dist > newDist)
        //                {
        //                    col = hitColliders[i];
        //                    dist = newDist;
        //                }
        //            }
        //            hitColliders[0] = col;
        //        }
        //        curBlock = hitColliders[0].gameObject;
        //    }


        //}

    }


    void save()
    {
        Ship ship = new Ship();
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("EditorOnly");
        for (int i = 0; i < blocks.Length; i++)
        {
            
            string name = blocks[i].name.Substring(0, 1); //get type + number-------------
            ship.addBlock(name, blocks[i].transform.position);
        }
        ship.name = nameship;


        Out.Saver.gamesave.saveActiveShip(ship);
        
    }

    public void try_buy()
    {
        save();
    }




    public void loadShip()
    {
       
         

        List<Ship.Block> blocks = new List<Ship.Block>();
        blocks = Out.Saver.gamesave.getActiveShip().blocks;
      //  nameShipText.text = Out.Saver.gamesave.getActiveShip().name;
        for (int i = 0; i < blocks.Count; i++)
        {
            instance(blocks[i].name, blocks[i].pos);
        }

    }

    public void goMenu()
    {
        Application.LoadLevel("Menu");
    }

    public void clear()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("EditorOnly");
        for (int i = 0; i < blocks.Length; i++)
        {
            Destroy(blocks[i]);
        }
    }
}
