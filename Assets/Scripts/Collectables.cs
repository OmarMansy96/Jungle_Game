using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{

    public AudioSource collectSound;
    public GameObject explosion;
    SpriteRenderer sR;
    public float Collectables_Score;

    
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sR.enabled = false;
            //transform.GetChild(0).gameObject.SetActive(true);
            explosion.SetActive(true);
            StartCoroutine(waitingExplosion());

           
        }
    }

    IEnumerator waitingExplosion()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
