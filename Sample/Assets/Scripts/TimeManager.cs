using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void TimeOn()
    {
        Time.timeScale = 1.0f;
    }
    public void TimeOff()
    {
        Time.timeScale = 0.0f;
    }
}
