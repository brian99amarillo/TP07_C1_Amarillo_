using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SettingsEnemySO setttingsEnemy;
    [SerializeField] private float idleTime = 0f;
    [SerializeField] private float runTime = 0f;
    [SerializeField] private float attackTime = 0f;
   
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(RutineMovement());
    }

    private IEnumerator RutineMovement()
    {
        while(true)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
            animator.SetBool("isIdle", true);
            animator.SetBool("isRun", false);
            yield return new WaitForSeconds(idleTime);

            animator.SetBool("isIdle", false);
            animator.SetBool("isRun", true);
            rb.linearVelocity = new Vector2(-setttingsEnemy.Speed, rb.linearVelocityY);
            yield return new WaitForSeconds(runTime);

            animator.SetBool("isRun", false);
            animator.SetBool("isAttack", true);
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
            yield return new WaitForSeconds(attackTime);
            animator.SetBool("isAttack", false);
            animator.SetBool("isIdle", true);
        }
    }
}

