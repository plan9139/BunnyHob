using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
    

    if (collision.CompareTag("Spike"))
        {
            
            SceneManager.LoadScene(0);
        }
        
    }
    
}
