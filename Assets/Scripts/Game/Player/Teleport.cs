using UnityEngine;

public class Teleport : MonoBehaviour
{
   private Camera mainCamera;
    
    // ===== ДОБАВЛЕНО ДЛЯ КД =====
    public float cooldown = 2f;           // Время перезарядки (секунд)
    private float nextTeleportTime = 0;    // Когда можно снова телепортироваться
    // ============================
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            TeleportToMouse();
        }
    }
    
    void TeleportToMouse()
    {
        // ===== ПРОВЕРКА КД =====
        if (Time.time < nextTeleportTime)
        {
            float remaining = nextTeleportTime - Time.time;
            Debug.Log($"❌ Телепорт через {remaining:F1} секунд");
            return;
        }
        // =======================
        
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
        
        // ===== ОБНОВЛЯЕМ ВРЕМЯ СЛЕДУЮЩЕЙ ТЕЛЕПОРТАЦИИ =====
        nextTeleportTime = Time.time + cooldown;
        // =================================================
        
        Debug.Log($"✨ Телепорт на {mousePos}");
}
}
