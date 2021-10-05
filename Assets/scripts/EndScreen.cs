using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject EndScreenScore;
    // Start is called before the first frame update
    void Start()
    {
        EndScreenScore = GameObject.FindGameObjectWithTag("EndScreenScore");
        EndScreenScore.GetComponent<TextMeshProUGUI>().text = "Score: " + HealthScript.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
