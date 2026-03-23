using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour
{


    [SerializeField] GameObject Hitbox;
    [SerializeField] GameObject UpHitbox;
    [SerializeField] GameObject DownHitbox;
private bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

IEnumerator BasicAttack()
    {
        Hitbox.SetActive(true);
        canAttack = false;
        yield return new WaitForSecondsRealtime(1);
        Hitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(2);
         canAttack = true;
    }
    IEnumerator UpAttack()
    {
        UpHitbox.SetActive(true);
        canAttack = false;
        yield return new WaitForSecondsRealtime(0.25f);
        UpHitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(1);
         canAttack = true;
    }
    IEnumerator DownAttack()
    {
        DownHitbox.SetActive(true);
        canAttack = false;
        yield return new WaitForSecondsRealtime(1.5f);
        DownHitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(5);
         canAttack = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack == true && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) // ЛКМ или Ctrl
        {
          
          StartCoroutine(BasicAttack());
          
        }
        else if(Input.GetKey(KeyCode.Mouse0) && canAttack == true && Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
             StartCoroutine(UpAttack());
        }
else  if (Input.GetKey(KeyCode.Mouse0) && canAttack == true && !Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) // ЛКМ или Ctrl
        {
          
          StartCoroutine(DownAttack());
          
        }
        else if (Input.GetKey(KeyCode.Mouse0) && canAttack == true && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) // ЛКМ или Ctrl
        {
          
          StartCoroutine(BasicAttack());
          
        }

    }
}
