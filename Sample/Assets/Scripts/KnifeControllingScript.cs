using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControllingScript : MonoBehaviour
{
    bool isDragging=false;
    bool isAbleToThrow=true;
    Vector3 startDragPosition;
    Vector3 endDragPosition;
    float cooldownTime=0.25f;
    public GameObject knifePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

           
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 40f));
      
            switch (touch.phase)
            {
      
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 40));
                    if (Physics.Raycast(ray))
                    {
                        isDragging = true;
                        startDragPosition = touchPos;

                    }
                    break;
         
                case TouchPhase.Ended:
                    endDragPosition = touchPos;
                    if (isAbleToThrow && isDragging)
                    {
                       StartCoroutine(startThrowing());
                        isDragging = false;
                    }
                    break;
            }
        }
    }

    public IEnumerator startThrowing()
    {

        Debug.Log("throw");
        Debug.Log("start position " + startDragPosition);
        Debug.Log("end position " + endDragPosition);
        if (startDragPosition != endDragPosition)
        {
            GameObject knifeObject = Instantiate(knifePrefab, startDragPosition, Quaternion.identity);
            KnifeScript knife = knifeObject.GetComponent<KnifeScript>();

            knife.setDirection(startDragPosition, endDragPosition);
            isAbleToThrow = false;
            yield return new WaitForSeconds(cooldownTime);
            isAbleToThrow = true;
        }
    }
}
