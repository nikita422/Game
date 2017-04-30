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
   
    public GameObject curBlock;
    public int price=0;

    public GameObject exitQwst;
    public Text priceText,playerMoneyText;

    bool alreadySave=false;

    void Start()
    {
        loadShip();
        playerMoneyText.text = Out.playerProfile.playerMoney.ToString();
        parent = GameObject.Find("Parent");      
    }

    

    public void instance(int _n)
    {
        if (curBlock) Destroy(curBlock);
        curBlock = Instantiate((GameObject)Resources.Load("ShipsBlockEditor/" + _n.ToString(), typeof(GameObject)), parent.transform);
        curBlock.transform.tag = "EditorOnly";
        alreadySave = false;
        price += 100;
        priceText.text = price.ToString();
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

        

            if (curBlock)
            {


                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Vector2 intPos = new Vector2(Mathf.CeilToInt(pos.x / 0.65f) * 0.65f, Mathf.CeilToInt(pos.y / 0.65f) * 0.65f);
                //curBlock.transform.position = Vector2.Lerp(curBlock.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),0.5f);
                curBlock.transform.position = intPos;

            }
           
            if (Input.GetMouseButtonUp(0) && curBlock)
            {

                if (EventSystem.current.IsPointerOverGameObject())
                {
                price -= 100;
                priceText.text = price.ToString();
                Destroy(curBlock);
                }
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


             
        }

    }


    void save()
    {
        Ship ship = new Ship();
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("EditorOnly");
        for (int i = 0; i < blocks.Length; i++)
        {           
            string name = blocks[i].name.Substring(0, blocks[i].name.Length-7); //get type + number-------------
          
            ship.addBlock(name, blocks[i].transform.position);
        }
         
         

        Out.playerProfile.saveActiveShip(ship);
        alreadySave = true;
    }

    public void try_buy()
    {
        if (price > Out.playerProfile.playerMoney)
        {
            print("Not Enough Money");
        }
        else
        {
            Out.playerProfile.playerMoney -= price;
            priceText.text = "0";
            playerMoneyText.text = Out.playerProfile.playerMoney.ToString();
            save();
        }
        
    }




    public void loadShip()
    {
       
         

        List<Ship.Block> blocks = new List<Ship.Block>();
        blocks = Out.playerProfile.getActiveShip().blocks;
      //  nameShipText.text = Out.Saver.gamesave.getActiveShip().name;
        for (int i = 0; i < blocks.Count; i++)
        {
            instance(blocks[i].name, blocks[i].pos);
        }

    }

    public void tryGoMenu()
    {
        if (alreadySave)
        {
            exitQwstYES();
            return;
        }
        parent.SetActive(false);
        exitQwst.transform.position = new Vector2(0, 0);
    }

    public void exitQwstNO()
    {
        exitQwst.transform.position = new Vector2(100, 100);
        parent.SetActive(true);
    }
    public void exitQwstYES()
    {
         
        Application.LoadLevel("Menu");
    }
}
