using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCruiser : MonoBehaviour
{
    public GameObject _vCam1;
    public GameObject _vCam2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * 3 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _vCam1.SetActive(true);
            _vCam2.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _vCam1.SetActive(false);
            _vCam2.SetActive(true);
        }
    }
}
