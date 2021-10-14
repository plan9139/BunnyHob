using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAble : MonoBehaviour
{
    
    [SerializeField]public float jumpForce = 10.0f;

    public float xAngle, yAngle, zAngle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag("Platform"))
        {
        Rigidbody2D rigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else if (collision.CompareTag("Spike"))
        {
            Debug.Log("Im dead");
            Rigidbody2D rigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
            rigidbody.transform.Rotate(90f,0.0f,0.0f, Space.Self);
        }
        
    }
    
}
