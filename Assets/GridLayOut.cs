using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Image>().color = new Color (Random.Range(0.5f, 0.95f), Random.Range(0.5f, 0.95f), Random.Range(0.5f, 0.95f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
