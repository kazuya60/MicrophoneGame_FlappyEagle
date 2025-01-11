using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScreenAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void OnApplicationQuit()
    {
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
