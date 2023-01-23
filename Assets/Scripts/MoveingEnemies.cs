using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingEnemies : MonoBehaviour
{

    public Transform start, end;
    public float Speed;
    Vector3 nextPoint;
    SpriteRenderer spR;

    void Start()
    {
        spR = GetComponent<SpriteRenderer>();

        nextPoint = start.position;
        spR.flipX = true;
    }

    void Update()
    {
        if (transform.position == start.position)
        {
            nextPoint = end.position;
            spR.flipX = false;
        }
        if (transform.position == end.position)
        {
            nextPoint = start.position;
            spR.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPoint, Speed * Time.deltaTime);
    }
    //public Vector2 startPoint,endPoint;
    //Vector3 nextPoint;
    //public float Distance = 3f;
    //public float enemySpeed;
    //SpriteRenderer spR;
    //bool right = true;

    //void Start()
    //{
    //    spR = GetComponent<SpriteRenderer>();
    //   startPoint = transform.position;
    //   endPoint= new Vector2(startPoint.x+Distance,startPoint.y);
    //    StartCoroutine(Moveing());
    //}

    //void Update()
    //{

    //}

    //IEnumerator Moveing()
    //{
    //    float value = 0f;
    //    while (true)
    //    {
    //        yield return null;

    //        if (right)
    //        {
    //            nextPoint = endPoint;
    //            transform.position = Vector2.Lerp(startPoint, nextPoint, value);
    //            spR.flipX = false;
    //        }
    //        else
    //        {
    //            nextPoint = startPoint;
    //            transform.position=Vector2.Lerp(endPoint, nextPoint, value);
    //            spR.flipX = true;
    //        }
    //        value = value+Time.deltaTime*enemySpeed;

    //        if(value > 1f)
    //        {
    //            value = 0f;
    //            right = !right;
    //        }
    //    }

    //}
    //private void OnTriggerEnter2D(Collider2D others)
    //{
    //    if (others.CompareTag("collider"))
    //    {
    //        right = !right;
    //    }
    //}
}
