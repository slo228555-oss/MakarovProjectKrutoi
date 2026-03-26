using UnityEngine;

public class Coin : MonoBehaviour
{
     public int coinValue = 1;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Получаем инвентарь с ИГРОКА
            PlayerInventory inv = other.GetComponent<PlayerInventory>();
            if (inv != null)
            {
                inv.AddCoins(coinValue);
            }
            Destroy(gameObject);
        }
    }


}
