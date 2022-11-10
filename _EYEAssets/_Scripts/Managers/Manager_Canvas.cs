using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Manager_Canvas : MonoBehaviour
{
    public Slider _positiveSpeedSlider;
    public Slider _negativeSpeedSlider;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdjustSliderValues(int speed)
    {
        if(speed > 0)
        {
            _positiveSpeedSlider.value = speed;
            _negativeSpeedSlider.value = 0;
        }
        if (speed < 0)
        {
            _positiveSpeedSlider.value = 0;
            _negativeSpeedSlider.value = -speed;
        }
        if(speed == 0)
        {
            _positiveSpeedSlider.value = 0;
            _negativeSpeedSlider.value = 0;
        }
    }
}
