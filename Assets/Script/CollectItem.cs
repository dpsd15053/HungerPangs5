using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class CollectItem : MonoBehaviour
{
    private Animator anim;
    public float healingAmount = 20f;
    public float damageAmount = 10f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (healingAmount > 0)
            {
                other.GetComponent<SanityManager>().GetSanity(healingAmount);
                
            }

            
            if (damageAmount > 0)
            {
                other.GetComponent<SanityManager>().LoseSanity(damageAmount);

            }
            Destroy(gameObject);


        }
    }


    
}
