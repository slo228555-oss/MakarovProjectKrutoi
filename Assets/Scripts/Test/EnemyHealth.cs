using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 30;
    
    // Этот метод вызывается ЛЮБЫМ хитбоксом
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Враг получил {damage} урона! Осталось: {health}");
        
        if (health <= 0)
            Destroy(gameObject);
    }
}