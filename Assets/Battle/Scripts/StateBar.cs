using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateBar : MonoBehaviour {

    public Image Hbar, Ebar;

    private void Start()
    {      
       Hbar = transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
       Ebar = transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
    }

    public void changeHealth(float _max,float _cur)
    {  
        Hbar.fillAmount = _cur / _max;
    }

    public void changeEnergy(float _max, float _cur)
    {
        Ebar.fillAmount = _cur / _max;
    }

}
