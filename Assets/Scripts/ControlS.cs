using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlS : MonoBehaviour
{

    public int attackDamage = 20;
    
    public Camera cam;
    public float donusHızı = 380;
    public float speed = 5f;
    public Rigidbody2D rb;
    
    Vector2 mousePos;
    Vector2 movment;
    public Player_S player_S;
    

    private void Start() {
       
    }
    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);  
        
    }
    private void FixedUpdate() {
        rb.MovePosition(rb.position + movment * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos -rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg-90;
        rb.rotation = angle; 
        Spin();
    }

   public bool Testere = false;
   private bool Kullan = true;
  
  
    private void Spin()
    {
        if (player_S.currnetEnergy==0)
        {
            Kullan = false;
        }
        else if (player_S.currnetEnergy == 200)
        {
            Kullan=true;
        }
        if (Input.GetKey(KeyCode.Space)&&player_S.currnetEnergy>0&&Kullan==true)
        {
            transform.Rotate(0, 0, donusHızı * Time.timeScale);
            Testere = true;
            player_S.SpendEnergy(5);
            
        }
        else
        {
            Testere=false;
            player_S.RechargeEnergy(1);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
       
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Çaliişti");
           
           Shake_ControllerS.isShake = true;
           
           
           
        }
        else
        {
            Shake_ControllerS.isShake = false;
            
            
        }
    }
}
