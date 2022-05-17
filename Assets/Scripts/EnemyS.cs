using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{


    public int maxHealth = 100;
    public int currnetHealth;

    public HealthBarS healthBarS;

    

    // [SerializeField]private int attackDamage=10;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        currnetHealth = maxHealth;
        healthBarS.SetMaxHealth(maxHealth);

    }

    private void Update() {
        if (currnetHealth<=0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<ControlS>().Testere)
            {
                TakeDamage(other.gameObject.GetComponent<ControlS>().attackDamage);
            }
            else if ( Mathf.Abs( rb.velocity.x)> Mathf.Abs( rb.velocity.y))
            {
                 other.gameObject.GetComponent<Player_S>().TakeDamage((int)Mathf.Abs( rb.velocity.x)*1);
                //  Debug.Log((int)Mathf.Abs( rb.velocity.x)+" kadar hasar vurdum");
            }
            else if ( Mathf.Abs( rb.velocity.y)> Mathf.Abs( rb.velocity.x))
            {
                other.gameObject.GetComponent<Player_S>().TakeDamage((int)Mathf.Abs( rb.velocity.y)*1);
                // Debug.Log((int)Mathf.Abs( rb.velocity.y)+" kadar hasar vurdum");
            }
            else
            {
                other.gameObject.GetComponent<Player_S>().TakeDamage((int)Mathf.Abs( rb.velocity.y)*1);
                // Debug.Log((int)Mathf.Abs( rb.velocity.x)+" kadar hasar vurdum");
            }
            
            

            // if (Mathf.Abs( rb.velocity.x)>10 || Mathf.Abs( rb.velocity.y) > 10)
            // {
            //     other.gameObject.GetComponent<Player_S>().TakeDamage((int)Mathf.Abs( rb.velocity.x)*1);
            // }
            // else if (Mathf.Abs( rb.velocity.x)>15 || Mathf.Abs( rb.velocity.y) > 15)
            // {
            //     other.gameObject.GetComponent<Player_S>().TakeDamage(attackDamage*4);
            // }
            // else
            // {
            //     other.gameObject.GetComponent<Player_S>().TakeDamage(attackDamage);
            // }
        }


    }

     public void TakeDamage(int damage){
        currnetHealth-=damage;
        healthBarS.SetHealth(currnetHealth);
    }

}
