using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    // array of object Types
    public GameObject ObjectsStates1;
    public GameObject ObjectsStates2;
    public GameObject ObjectsStates3;
    public GameObject ObjectsStates4;
    public GameObject ObjectsStates5;
    // current state of Treasure
    public GameObject currentObjectState;
    // lifes left
    private int currentLifes = 5;
    // function which changes lifes and model with them
    public void changeLifes(int deltaLifesChange)
    {
        currentLifes += deltaLifesChange;
        if (currentLifes <= 0)
            currentLifes = 1;
        else if (currentLifes > 5)
            currentLifes = 5;
        // set corresponding object state to current lifes
        switch(currentLifes)
        {
            case 1:
                SetNewObject(ObjectsStates1);
                break;
            case 2:
                SetNewObject(ObjectsStates2);
                break;
            case 3:
                SetNewObject(ObjectsStates3);
                break;
            case 4:
                SetNewObject(ObjectsStates4);
                break;
            default: // case 5
                SetNewObject(ObjectsStates5);
                break;
        }
    }
    // new model setter
    void SetNewObject(GameObject newGameObject)
    {
        Destroy(currentObjectState);
        currentObjectState = Instantiate(newGameObject, currentObjectState.transform.position, currentObjectState.transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLifes = 5;
    }
}
