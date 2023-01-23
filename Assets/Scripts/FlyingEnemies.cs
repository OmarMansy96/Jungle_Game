using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour
{
    Transform Player;
    SpriteRenderer spR;
    [SerializeField] float flyingSpeed=2f;
    [SerializeField] float distance = 3f;
    [SerializeField] bool isFlying=true;
    Vector2 startPoint, endPoint;
   
    void Start()
    {

        spR = GetComponent<SpriteRenderer>();
        Player = FindObjectOfType<Player_Movement>().transform;// || Player = GameObject.Find("player");

        startPoint = transform.position;
        endPoint = new Vector2(startPoint.x, transform.position.y + distance);

        StartCoroutine(FlyingEnemy());
    }

    void Update()
    {
        
        
        if(Player.position.x > transform.position.x) 
          spR.flipX = true;
       
        else 
          spR.flipX = false;
        
     
        

    }
    IEnumerator FlyingEnemy()
    {

        float value = 0;
        
        while (true)
        {
            yield return null;

            if (isFlying)
            {
              transform.position =  Vector2.Lerp(startPoint, endPoint, value);
            }
            else
            {
                transform.position = Vector2.Lerp(endPoint, startPoint, value);
            }

            value = value + Time.deltaTime * flyingSpeed;


            if (value > 1)
            {
                value = 0;
                isFlying = !isFlying;
            }
        }
       
    }

}
