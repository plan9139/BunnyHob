using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 7;
    public int jumpForce = 800;
    public float moveX;
    public bool isPlatform;
    private Animator anim;
    private Rigidbody2D rigidbody;
    private bool mirrered;
    [SerializeField]private int score = 0;

    public void AddScore()
    {
        score = score + 1;
    }

    public void AddRedScore()
    {
        score = score + 2;
    }

    public int GetScore()
    {
        return score; 
    }
    
    public void Start ()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isPlatform==true)
        {
            
            Jump();
        }
        if (!isPlatform)
        {
            anim.SetBool("IsJump",true);
        }
        if (moveX!=0 && isPlatform)
        {
            anim.SetBool("IsRun",true);
        }
        else
        {
            anim.SetBool("IsRun",false);
        }
        if (moveX<0.0f && mirrered==false)
        {
            FlipPlayer();    
        }
        else if (moveX>0.0f && mirrered==true)
        {
            FlipPlayer();    
        }
        rigidbody.velocity = new Vector2(moveX*speed,gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    private void FlipPlayer()
    {
        mirrered = !mirrered;
        Vector2 local = gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local; 
    }
    public void Jump()
    {
        gameObject.GetComponent<AudioSource>().Play();
        rigidbody.AddForce(Vector2.up*jumpForce);
        isPlatform = false;

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Platform")
        {
            isPlatform = true;
            anim.SetBool("IsJump",false);
        }
        if(other.gameObject.tag=="End")
        {
            SceneManager.LoadScene(3);
        }
        if(other.gameObject.tag=="End2")
        {
            SceneManager.LoadScene(5);
        }
        if(other.gameObject.tag=="End3")
        {
            SceneManager.LoadScene(7);
        }
    }
    
   
   
}
