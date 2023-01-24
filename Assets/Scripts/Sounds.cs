using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource gameComplete;
    
    public AudioSource Hit;
    bool ended =true;
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag ("theEnd") && ended)
        {
            gameComplete.Play ();
            ended=false;
        }
        if (others.CompareTag("Enemies"))
        {
            Hit.Play ();
        }
    }
}
