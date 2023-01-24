using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject gameOver;
    public AudioSource dead;
    public Text score;
    public Text health;
    float player_Score;
    float maxHealth=5f, currentHealth;

    bool deadSound = false;

    void Start()
    {
        currentHealth = maxHealth;
      
        Debug.Log("currentHealth: " + currentHealth);
    }

    void Update()
    {
        health.text = $"Health: {currentHealth} / {maxHealth}";
        score.text = $"Score: {player_Score}";
        
        if (currentHealth <= 0f || transform.position.y < -33f)
        {

            if (deadSound == false)
            {
                dead.Play();
                deadSound = true;
            }
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

    }





  
    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("collectables"))
        {
            player_Score += others.GetComponent<Collectables>().Collectables_Score;
        }


        if (others.CompareTag("Enemies"))
        {
            currentHealth--;
          
        }
       
    }
}
