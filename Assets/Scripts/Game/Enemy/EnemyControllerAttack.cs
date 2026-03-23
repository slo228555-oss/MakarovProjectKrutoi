using UnityEngine;
using System.Collections;
public class EnemyControllerAttack : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject RightHitbox;
    [SerializeField] GameObject LeftHitbox;
    private float playerPos ;
    private float enemyPos ;
private bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos= Player.transform.position.x;
        enemyPos= transform.position.x;
        EnemyAttack();
    }
    public void EnemyAttack()
    {
        if( enemyPos > playerPos && canAttack == true)
        {
            StartCoroutine(WAitingAttackLeft());
        }
        else if (enemyPos < playerPos &&canAttack == true)
        {
             StartCoroutine(WAitingAttackRight());
        }
    }


IEnumerator WAitingAttackLeft()
    {
       
        canAttack = false;
LeftHitbox.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
         LeftHitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(2);
         canAttack = true;
    }
IEnumerator WAitingAttackRight()
    {
       
        canAttack = false;
        RightHitbox.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
         RightHitbox.SetActive(false);
         yield return new WaitForSecondsRealtime(2);
         canAttack = true;
    }


}
