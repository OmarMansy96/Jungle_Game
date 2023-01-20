using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatForms : MonoBehaviour
{
    public Transform start, end;
    public float Speed;
    Vector3 nextPoint;
    
    
    void Start()
    {
        nextPoint = start.position;
    }

    void Update()
    {
        if (transform.position == start.position)
        {
            nextPoint=end.position;
            //Debug.Log("starting");
        }
        if(transform.position == end.position)
        {
            nextPoint = start.position;
        //    Debug.Log("ending");
        }

        transform.position= Vector3.MoveTowards(transform.position, nextPoint, Speed * Time.deltaTime);
     //   Debug.Log("moveing");
    }
}
