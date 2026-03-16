using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created[Header("⚜️ НАСТРОЙКИ, ДОСТОЙНЫЕ ПОВЕЛИТЕЛЯ ⚜️")]
    [Tooltip("Скорость, с которой враг будет рассекать пространство")]
    public float speed = 3f;
    
    [Tooltip("Расстояние, на котором враг замечает игрока")]
    public float detectionRange = 5f;
    
    [Tooltip("Левая граница движения врага (перетащите сюда объект)")]
    public Transform leftBoundary;
    
    [Tooltip("Правая граница движения врага (перетащите сюда объект)")]
    public Transform rightBoundary;
    
    [Header("👁️ ССЫЛКИ НА ВЕЛИКОГО ИГРОКА 👁️")]
    [Tooltip("Самый главный объект - игрок")]
    public Transform player;
    
    // Приватные переменные, недостойные взора Повелителя
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int direction = 1; // 1 = вправо, -1 = влево
    private bool isChasing = false;

    void Start()
    {
        // С трепетом получаем компоненты для служения
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Если Повелитель забыл указать границы, создаём их мысленно
        if (leftBoundary == null)
        {
            GameObject left = new GameObject("LeftBoundary");
            left.transform.position = transform.position + Vector3.left * 5f;
            leftBoundary = left.transform;
        }
        
        if (rightBoundary == null)
        {
            GameObject right = new GameObject("RightBoundary");
            right.transform.position = transform.position + Vector3.right * 5f;
            rightBoundary = right.transform;
        }
        
        // Если Повелитель не указал игрока, ищем его священную тушку
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        // Если нет игрока - просто ходим
        if (player == null)
        {
            Patrol();
            return;
        }
        
        // Считаем расстояние до великого игрока
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // Решаем, что делать
        if (distanceToPlayer <= detectionRange)
        {
            // Игрок рядом - ПРЕСЛЕДУЕМ!
            ChasePlayer();
        }
        else
        {
            // Игрок далеко - патрулируем
            Patrol();
        }
        
        // Поворачиваемся в сторону движения
        UpdateFacingDirection();
    }

    /// <summary>
    /// ПРОСТО ХОДИМ ВЛЕВО-ВПРАВО, КАК ПРИКАЗАЛ ПОВЕЛИТЕЛЬ
    /// </summary>
    void Patrol()
    {
        isChasing = false;
        
        // Двигаемся в текущем направлении
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        
        // Проверяем, не дошли ли до границы
        if (direction > 0 && transform.position.x >= rightBoundary.position.x)
        {
            direction = -1; // Поворачиваем налево
        }
        else if (direction < 0 && transform.position.x <= leftBoundary.position.x)
        {
            direction = 1; // Поворачиваем направо
        }
    }

    /// <summary>
    /// ИДЁМ К ВЕЛИКОМУ ИГРОКУ ПО ОСИ X
    /// </summary>
    void ChasePlayer()
    {
        isChasing = true;
        
        // Определяем направление к игроку
        float playerDirection = player.position.x - transform.position.x;
        
        // Идём к игроку
        if (playerDirection > 0)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            direction = 1;
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            direction = -1;
        }
    }

    /// <summary>
    /// ПОВОРАЧИВАЕМ ВРАГА В СТОРОНУ ДВИЖЕНИЯ
    /// </summary>
    void UpdateFacingDirection()
    {
        if (spriteRenderer != null)
        {
            if (direction > 0)
                spriteRenderer.flipX = false; // Смотрим вправо
            else
                spriteRenderer.flipX = true;  // Смотрим влево
        }
    }

    /// <summary>
    /// ВИЗУАЛИЗАЦИЯ ДЛЯ ВЕЛИКОГО ПОВЕЛИТЕЛЯ В РЕДАКТОРЕ
    /// </summary>
    void OnDrawGizmosSelected()
    {
        // Рисуем границы движения
        if (leftBoundary != null && rightBoundary != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(leftBoundary.position, rightBoundary.position);
            
            // Рисуем кружки на границах
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(leftBoundary.position, 0.3f);
            Gizmos.DrawWireSphere(rightBoundary.position, 0.3f);
        }
        
        // Рисуем радиус обнаружения игрока
        Gizmos.color = isChasing ? Color.red : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
