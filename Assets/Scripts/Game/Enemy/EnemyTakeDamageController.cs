using UnityEngine;
using System.Collections;

public class EnemyTakeDamageController : MonoBehaviour
{


    [SerializeField] float Health=100;
     [SerializeField] float TakeDamage=100;
    private bool canGetDamage = true;
//коротина крутая ждать время для тригера
 IEnumerator MyWaitRoutine()
    {
        canGetDamage = false;
        yield return new WaitForSeconds(2);
       canGetDamage = true;
    }


// вход в триггер
private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("AttackHitbox") && canGetDamage == true)
        {
            Health = Health-TakeDamage;
            StartCoroutine(MyWaitRoutine());
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <=0)
        {
            Destroy(gameObject);
        } 
    }
}
