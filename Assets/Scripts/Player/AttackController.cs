using UnityEngine;
using System.Collections;

public class AttackController : MonoBehaviour
{


    [SerializeField] GameObject Hitbox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

IEnumerator WaitingAnimations()
    {
        Hitbox.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        Hitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // ЛКМ или Ctrl
        {
          
          StartCoroutine(WaitingAnimations());
          
        }
    }
}
