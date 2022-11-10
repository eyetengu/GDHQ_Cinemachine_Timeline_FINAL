using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipController : MonoBehaviour
{
    public int speed;
    public GameObject thrusters;
    public GameObject spaceDust;
    public GameObject[] guns;
    public GameObject bulletPrefab;
    public Transform[] gunBarrels;
    public Transform speedControls;
    public Transform driveStickControl;
    public bool moveControlStick;
    public Manager_Canvas canvasMgr;


    void Update()
    {
        //apply speed to starship
        if(Input.GetKeyDown(KeyCode.W))
        {
            speedControls.Rotate(15, 0, 0);
            speed++;
            if(speed > 30)
            {
                speed = 30;
            }
            canvasMgr.AdjustSliderValues(speed);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speedControls.Rotate(-15, 0, 0);
            speed--;
            if(speed < -15)
            {
                speed = -15;
            }
            canvasMgr.AdjustSliderValues(speed);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speedControls.Rotate(-15, 0, 0);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            speedControls.Rotate(15, 0, 0);
        }
        Debug.Log("Speed " + speed);

        //canvasMgr.AdjustSliderValues(speed); 
        //activate thrusters & space dust
        if(speed > 0 || speed < 0)
        {
            thrusters.SetActive(true);
            spaceDust.SetActive(true);
        }
        else 
        { 
            thrusters.SetActive(false);
            spaceDust.SetActive(false);
        }

        //move starship
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 

        //rotate starship
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -10 * Time.deltaTime, 0);
            if(moveControlStick == true)
            {
                driveStickControl.Rotate(0, 0, 20);
                moveControlStick = false;
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 10 * Time.deltaTime, 0);
            
            if (moveControlStick == true)
            {
                driveStickControl.Rotate(0, 0, -20);
                moveControlStick = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            moveControlStick = true;
            driveStickControl.rotation = new Quaternion(0, 0, 0, 0);
        }
        
        //fire bullets
        if(Input.GetMouseButton(0))
        {
            foreach(Transform gun in gunBarrels)
            {
                Instantiate(bulletPrefab, gun.transform.position, gun.rotation);
            }
        }
        
    }
}
