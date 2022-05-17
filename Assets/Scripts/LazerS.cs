using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerS : MonoBehaviour
{
    public GameObject hitEffect;
    
    private int lazerDamage = 20;

    private void OnCollisionEnter2D(Collision2D other) {
        
        GameObject effect = Instantiate(hitEffect,transform.position,Quaternion.identity);
        gameObject.transform.localScale = new Vector3();
        Destroy(effect,0.1f);
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
             other.gameObject.GetComponent<EnemyS>().TakeDamage(lazerDamage);
        }
        
    }

}
