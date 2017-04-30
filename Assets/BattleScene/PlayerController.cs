using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 


public class PlayerController : MonoBehaviour
{

    float speed = 0f, speedlimit = 7,
        rotationspeed = 0, rotationspeedlimit = 50;

    string buttonDown;

    public bool isSliderSpeed;
    public Slider slider;

   

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 vec3= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec3 += new Vector3(0, 0, 10);
        transform.position = Vector3.Lerp(transform.position,vec3,.02f);
        */
        InputHandle();
        UiInput();

        transform.Rotate(0, 0, rotationspeed * Time.deltaTime);

        transform.position += new Vector3(speed * Time.deltaTime * -Mathf.Sin(transform.eulerAngles.z / 180 * Mathf.PI),
            speed * Time.deltaTime * Mathf.Cos(transform.eulerAngles.z / 180 * Mathf.PI), 0);

        //print(Mathf.Sin(transform.eulerAngles.z/180*Mathf.PI));

        if (rotationspeed < 0) rotationspeed += 1;
        if (rotationspeed > 0) rotationspeed -= 1;

    }



    private void InputHandle()
    {
        if (!isSliderSpeed)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("up arrow key is held down");
                if (speed < speedlimit)
                    speed += 4 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                print("down arrow key is held down");
                if (speed > -speedlimit)
                    speed -= 4 * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("left arrow key is held down");
            if (rotationspeed < rotationspeedlimit)
                rotationspeed += 5;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("right arrow key is held down");
            if (rotationspeed > -rotationspeedlimit)
                rotationspeed -= 5;
        }
    }

    private void UiInput()
    {
        
        if (buttonDown == "LeftButton")
        {
            print("LEFT BUTTON");
            if (rotationspeed < rotationspeedlimit)
                rotationspeed += 5;
        }
        if (buttonDown == "RightButton")
        {
            print("RIGHT BUTTON");
            if (rotationspeed > -rotationspeedlimit)
                rotationspeed -= 5;
        }
        if (isSliderSpeed)
        {
            speed = speedlimit * slider.value;
        }
    }

    public void IsMenuButtonDown(string button)
    {
    
        buttonDown = button;
        print(buttonDown);
    }
    public void IsMenuButtonUp()
    {
      // buttonDown = "";
    }


}
