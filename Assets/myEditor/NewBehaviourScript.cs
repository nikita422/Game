using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour
{



    GameObject parent;
    /*
     Кнопка открывающая меню
         
         
         
         
         
         */


    public GameObject curBlock;

    void Start()
    {
        parent = GameObject.Find("0");
    }



    public void instance(int _n)
    {
        if (curBlock) Destroy(curBlock);
        print("ShipsBlock/" + _n.ToString());
        curBlock = Instantiate((GameObject)Resources.Load("ShipsBlock/" + _n.ToString(), typeof(GameObject)), parent.transform);
        curBlock.transform.tag = "EditorOnly";
        
    }

    public void instance(string name,Vector2 _pos)
    {
 
        GameObject block = Instantiate((GameObject)Resources.Load("ShipsBlock/" + name, typeof(GameObject)), parent.transform);
        block.transform.position = _pos;
        

    }


    void Update()
    {
        

        if (curBlock)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 intPos = new Vector2(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y));
            //   curBlock.transform.position = Vector2.Lerp(curBlock.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.5f);
            curBlock.transform.position = intPos;

        }

        if (Input.GetMouseButtonUp(0) && curBlock)
        {
            curBlock = null;
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !curBlock)
        {
            float kZoom = Camera.main.orthographicSize;


            Vector3 moupos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mouposz0 = new Vector3(moupos.x, moupos.y, 0);
        
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mouposz0, kZoom / 6);//what about layers, bitch?
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
                curBlock = hitColliders[0].gameObject;
            }
            print(hitColliders[0]);

        }
    }

    /*
     * 
     * 1_1x
     * 1_1y
     * 1_2
     * 1_3
     * 
     * 
     * 
     */



    public void save()
    {
        Ship ship = new Ship();
        ship.name = "1";
        

        GameObject[] blocks= GameObject.FindGameObjectsWithTag("EditorOnly");
        for (int i = 0; i < blocks.Length; i++)
        {
            string name = blocks[i].name.Substring(0,1); //get type + number-------------
            ship.addBlock(name, blocks[i].transform.position); 
        }

        Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Save<Ship>("C:/ds.xml", ship);


    }
    public void load()
    {
        Ship ship = new Ship();

        ship = Com.Nravo.FlipTheBoard.PersistantStorage.EncryptedXmlSerializer.Load<Ship>("C:/ds.xml");

        List<Ship.Block> blocks = new List<Ship.Block>();
        blocks = ship.blocks;
        for (int i = 0; i < blocks.Count; i++)
        {
            instance(blocks[i].name, blocks[i].pos);
        }
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
