using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barriers_spawn : MonoBehaviour
{
    //public Text textComponent;
    public GameObject barrier;
    public int barriersCount;
    public float [] timeInst;
    public float [] lifeTime; 
    private float [] timeCollapse;
    public Vector3 [] barrierPosition;
    private bool[] isCreated;
    private bool[] isDestroyed;
    private float timer;
    private GameObject[] bars;
    private GameObject [] barsDestroy; 
    void Start()
    {
        barsDestroy = new GameObject[barriersCount];
        timeCollapse = new float[barriersCount];
        isCreated = new bool[barriersCount];
        isDestroyed = new bool[barriersCount];
        timer = 0; 
        bars = new GameObject[barriersCount];

        for (int i = 0; i < barriersCount; i++)
        {
            timeCollapse[i] = timeInst[i] + lifeTime[i]; 
            bars[i] = barrier;
            timeCollapse[i] = timeInst[i] + lifeTime[i];
            isCreated[i] = false;
            isDestroyed[i] = false;
        }
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        //textComponent.text = timer.ToString();
        for (int i = 0; i < barriersCount; i++)
        {
            if (timer >= timeInst[i] && isCreated[i] == false)
            {
                barsDestroy[i] = Instantiate(bars[i], barrierPosition[i], Quaternion.identity);
                isCreated[i] = true;
            }

            if (timer >= timeCollapse[i] && isDestroyed[i] == false)
            {
                Destroy(barsDestroy[i]);
                isDestroyed[i] = true;
            }
        }
    }
    
}