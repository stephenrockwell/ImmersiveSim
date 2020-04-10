using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownFunction : MonoBehaviour
{
    public TimeManagement timer;
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            timer.DoSlowmotion();
        }
    }
}
