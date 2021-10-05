using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSound : MonoBehaviour
{
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
