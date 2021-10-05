using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public static int playerSelected = 0;
    public bool isGreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (isGreen)
        {
            playerSelected = 1;
        }
        else
        {
            playerSelected = 0;
        }
        SceneManager.LoadScene("Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
