using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public float speed;
    public Vector3 finalDestinationVector;
    public bool isReadyForMovement;
    public float boundX;//module of x boundaries of screen
    public float boundZ;
    public void setDirection(Vector3 startOfDirection,Vector3 directionVector) {
        //finalDestinationVector = new Vector3(directionVector.x, 0f, directionVector.y);
        finalDestinationVector = directionVector;
        Debug.Log("Direction " +(finalDestinationVector - transform.position));
        transform.rotation = Quaternion.FromToRotation(transform.forward, finalDestinationVector - startOfDirection);
        isReadyForMovement = true;
    }
    void Start()
    {
        //GameObject camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideBounds())
        {
            if (isReadyForMovement)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
        else{
            Destroy(this.gameObject);
        }
    }

    bool isInsideBounds(){
        if (Mathf.Abs(transform.position.x) > boundX || Mathf.Abs(transform.position.z) > boundZ) {
            return false;
        }
        return true;
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("Main Camera").GetComponent<sound>().PlaySound();
            GameObject enemyObject = other.gameObject;
            enemy1 enemyScript = enemyObject.GetComponentInChildren<enemy1>();
            if (enemyScript == null)
            {
                Debug.Log("Could not get <enemyScript> component in this GameObject or any of its children.");
                return;
            }
            enemyScript.Damage(1, transform.forward * 1 * speed);
            Destroy(this.gameObject);
        }
    }
}
