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
    AudioSource sound;
    public GameObject currentObjectState;
    // lifes left
    public int currentLifes;
    // function which changes lifes and model with them
    public void changeLifes(int deltaLifesChange)
    {
        currentLifes += deltaLifesChange;
        if (currentLifes <= 0)
            currentLifes = 0;
        else if (currentLifes > 5)
            currentLifes = 5;
        // set corresponding object state to current lifes
        switch(currentLifes)
        {
            case 1:
                SetNewObject(ObjectsStates1);
                sound.Play();
                break;
            case 2:
                SetNewObject(ObjectsStates2);
                sound.Play();
                break;
            case 3:
                SetNewObject(ObjectsStates3);
                sound.Play();
                break;
            case 4:
                SetNewObject(ObjectsStates4);
                sound.Play();
                break;
            case 5:
                SetNewObject(ObjectsStates5);
                sound.Play();
                break;
            default:
                Destroy(currentObjectState);
                sound.Play();
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
        sound = GetComponent<AudioSource>();
        currentLifes = 5;
    }
}
