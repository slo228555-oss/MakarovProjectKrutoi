using UnityEngine;

public class PlayerWalkController : MonoBehaviour
{
 private Rigidbody2D rb;
[SerializeField] float speed;



    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();  
    }


void Move()
    {
        // Ось Horizontal - клавиши A, D, левая стрелка, правая стрелка. Принимает значения от -1 до 1.
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(moveX, moveY).normalized * speed;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
