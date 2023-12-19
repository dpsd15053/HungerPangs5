using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {

            Die();
            RestartLevel();

        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cherry"))
        {

            anim.SetTrigger("angry");

        }
        if (other.CompareTag("banana"))
        {

            anim.SetTrigger("happy");

        }

    }

    public void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        
    }
   
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
