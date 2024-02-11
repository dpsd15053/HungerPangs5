using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SanityManager : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private Image SanityBar;
    private float FullSanity = 100f;
    private float CurrentSanity;
    [SerializeField] private float DamageRate = 2f;

    private Slider SanitySlider;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        CurrentSanity = FullSanity;

        if (SanitySlider != null)
        {
            SanitySlider.maxValue = FullSanity;
            SanitySlider.value = CurrentSanity;
        }


    }

    
    void Update()
    {
        LoseSanity(DamageRate * Time.deltaTime);
        if (SanityBar.fillAmount < .01f)
        {
            Die();
        }
    }

    
    public void LoseSanity(float damage)
    {
        
        FullSanity -= damage;
        SanityBar.fillAmount = FullSanity / 100f;


    }
    public void GetSanity(float HealingAmount)
    {
        
        FullSanity += HealingAmount;
        FullSanity = Mathf.Clamp(FullSanity, 0, 100);
        

        if (SanitySlider != null)
        {
            SanitySlider.value = CurrentSanity;
        }
      
    }


    public void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        RestartLevel();


    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
