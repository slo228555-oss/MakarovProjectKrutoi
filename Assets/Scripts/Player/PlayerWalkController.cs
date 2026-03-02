using UnityEngine;

public class PlayerWalkController : MonoBehaviour
{
 private Rigidbody2D rb;
[SerializeField] float speed;

[SerializeField] float forceJump = 10;
private bool isGrounded;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();  
    }
void OnCollisionEnter2D(Collision2D collision)
    {
        // Если то, чего коснулись, имеет тег "Ground"
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
           
        }
    }
    
    // Когда перестаем касаться
    void OnCollisionExit2D(Collision2D collision)
    {
        // Если ушли с объекта с тегом "Ground"
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
           
        }
    }
    


    void Move()
{
    float moveX = Input.GetAxisRaw("Horizontal");
    
    // Двигаемся только по X, Y всегда 0
    rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocityY);
}
    // Update is called once per frame
    void Update()
    {
        Move();
      
       if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * forceJump, ForceMode2D.Force);
        }
    }
}
