using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
  
    public int damage = 10; // У каждого СВОЙ урон (можно менять в инспекторе!)
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            // Просто говорим цели: "получи урон"
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            
           
        }
    }

}
