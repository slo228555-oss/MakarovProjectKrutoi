using UnityEngine;

public class Teleport : MonoBehaviour
{

  private Camera mainCamera;
    private PlayerInventory inventory;
    
    [Header("Настройки телепортации")]
    public float cooldown = 2f;
    public int teleportCost = 1;           // Сколько монет стоит телепорт
    private float nextTeleportTime = 0;
    
    void Start()
    {
        mainCamera = Camera.main;
        
        // Находим инвентарь игрока
        inventory = GetComponent<PlayerInventory>();
        if (inventory == null)
        {
            Debug.LogError("❌ PlayerInventory не найден!");
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TryTeleport();
        }
    }
    
    void TryTeleport()
    {
        // Проверка КД
        if (Time.time < nextTeleportTime)
        {
            float remaining = nextTeleportTime - Time.time;
            Debug.Log($"❌ Телепорт через {remaining:F1} сек");
            return;
        }
        
        // ПРОВЕРКА МОНЕТ
        if (inventory == null || inventory.GetCoins() < teleportCost)
        {
            Debug.Log($"❌ Не хватает монет! Нужно: {teleportCost}, есть: {(inventory != null ? inventory.GetCoins() : 0)}");
            return;
        }
        
        // Получаем позицию мыши
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        
        // СПИСЫВАЕМ МОНЕТЫ
        inventory.AddCoins(teleportCost);
      
        // Телепортируем
        transform.position = mousePos;
        
        // Обновляем КД
        nextTeleportTime = Time.time + cooldown;
        
        Debug.Log($"✨ Телепорт! Потрачено {teleportCost} монет. Осталось: {inventory.GetCoins()}");
    }

}
