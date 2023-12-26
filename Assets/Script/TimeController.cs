using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void FastTime()
    {
        Time.timeScale = 0.8f;
        
    }
    public void SlowTime()
    {
        float FixedTime = 0.01f;
        Time.timeScale = 0.04f;
        Time.fixedDeltaTime = FixedTime * Time.timeScale;
        
    }
}
