using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBar : MonoBehaviour {

    public GameObject Hbar, Ebar;
    public GameObject Ship;

    Transform shipTransform;

    public GameObject barLinePrefab;
    GameObject line;
    LineRenderer barLineRen;

    Core core;
    float calcHealth, calcEnergy;

    void Start()
    {
        core = Ship.GetComponent<Core>();

        shipTransform = Ship.transform;
        line = Instantiate(barLinePrefab,this.transform);
        barLineRen = line.GetComponent<LineRenderer>();
        
    }


    void Update()
    {

        barLineRen.SetPosition(0, shipTransform.position);
        barLineRen.SetPosition(1, Camera.main.ScreenToWorldPoint(transform.position));

        transform.position = Camera.main.WorldToScreenPoint(shipTransform.position + new Vector3(-2, 2, 0));



        calcHealth = core.curHealth / core.maxHealth;
        
        Hbar.transform.localScale = new Vector3(calcHealth, transform.localScale.y, transform.localScale.z);

        calcEnergy = core.curEnergy / core.maxEnergy;
        Ebar.transform.localScale = new Vector3(calcEnergy, transform.localScale.y, transform.localScale.z);

    }

    
}
