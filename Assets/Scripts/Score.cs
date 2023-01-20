using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : Collectables
{
    float score;
    float maxHealth=5f, currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
      
        Debug.Log("currentHealth: " + currentHealth);
    }

    void Update()
    {
      
    }





  
    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("collectables"))
        {
            score = score + itemsScore;
            Debug.Log("Score: " + score); 

        }


        if (others.CompareTag("Enemies"))
        {
            currentHealth--;
            Debug.Log("maxHealth: " + maxHealth);
            Debug.Log("currentHealth: " + currentHealth);
        }
       
    }
}
