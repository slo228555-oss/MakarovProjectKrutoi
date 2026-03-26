using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Text MoneyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created public int coinValue = 1;
     private int coins = 0;
    
    void Start()
    {
        LoadCoins();
    }
    
    public void AddCoins(int amount)
    {
        coins += amount;
        MoneyText.text = $"Money: {coins}";
        Debug.Log($"💰 Монет: {coins}");
        SaveCoins();
    }
    
    public int GetCoins()
    {
        return coins;
    }
    
    void SaveCoins()
    {
        PlayerPrefs.SetInt("PlayerCoins", coins);
        PlayerPrefs.Save();
    }
    
    void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("PlayerCoins", 0);
    }
}
