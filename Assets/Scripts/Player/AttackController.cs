using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour
{


    [SerializeField] GameObject Hitbox;
private bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

IEnumerator WaitingAnimations()
    {
        Hitbox.SetActive(true);
        canAttack = false;
        yield return new WaitForSecondsRealtime(1);
        Hitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(2);
         canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack == true) // ЛКМ или Ctrl
        {
          
          StartCoroutine(WaitingAnimations());
          
        }
    }
}
