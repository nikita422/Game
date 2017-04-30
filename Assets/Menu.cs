using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

    
    List<string> nameShips;
    public Image img0,img1,img2;

    public Color aClr,Naclr;


    public AudioClip clickSound; // звуки
    AudioSource audio;
    Image loadImg;
    bool alreadyload;
    void Start () {
        alreadyload = Out.playerProfile.ready;
        loadImg = GameObject.Find("load").GetComponent<Image>();
        if (alreadyload)
        {
            loadImg.transform.parent.parent.gameObject.SetActive(false);
        }
        Naclr = img1.color;
        
        audio =Camera.main.GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (!alreadyload)
        {
            if (!Out.playerProfile.ready)
            {
                if (loadImg.fillAmount < 1)
                {
                    loadImg.fillAmount += Time.deltaTime * 0.5f;
                }
            }
            else
            {
                if (loadImg.fillAmount < 0.99f)
                {
                    loadImg.fillAmount = Mathf.Lerp(loadImg.fillAmount, 1, 0.1f);
                }
                else
                {
                    loadImg.transform.parent.parent.gameObject.SetActive(false);
                    alreadyload = true; 
                }
            }
        }
    }


    public void clickSoundPlay()
    {
        audio.PlayOneShot(clickSound, 1);
        print(1);
    }

    public void setActiveSlot(int _n)
    {
        set_image(_n);   
        Out.playerProfile.setActiveShip(_n);
    }
     


    void set_image(int _n)
    {
        img0.color = Naclr;
        img1.color = Naclr;
        img2.color = Naclr;
         
        if (_n == 0)
        {
            img0.color = aClr;
        }
        if (_n == 1)
        {
            img1.color = aClr;
        }
        if (_n == 2)
        {
            img2.color = aClr;
        }

    }

    public void goEditor() {
       
       
        Application.LoadLevel("Editor");
    }
    public void goBattle()
    {
       Application.LoadLevel("Battle");
    }
}
