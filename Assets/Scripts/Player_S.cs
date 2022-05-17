using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_S : MonoBehaviour
{

    public int maxHealth = 100;
    public int currnetHealth;

    public HealthBarS healthBarS;

    public int maxEnergy = 1000;
    public int currnetEnergy;
    public Enerji_S enerji_S;
    
    
    public void Start()
    {
        currnetHealth = maxHealth;
        healthBarS.SetMaxHealth(maxHealth);
        currnetEnergy = maxEnergy;
        enerji_S.SetMaxEnergy(maxEnergy);
    }

    
    

    void Update()
    {
       
        
        
    }

    public void SpendEnergy(int spend){
        currnetEnergy -= spend;
        enerji_S.SetEnergy(currnetEnergy);
    }
     public void RechargeEnergy(int recharge){
         if (currnetEnergy<maxEnergy)
         {
             currnetEnergy += recharge;
         }
        
        enerji_S.SetEnergy(currnetEnergy);
    }
    public void TakeDamage(int damage){
        currnetHealth-=damage;
        healthBarS.SetHealth(currnetHealth);
    }
}
