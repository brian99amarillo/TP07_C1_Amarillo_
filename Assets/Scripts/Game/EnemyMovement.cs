using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SettingsEnemySO setttingsEnemy;
    [SerializeField] private float idleTime = 0f;
    [SerializeField] private float runTime = 0f;
    [SerializeField] private float attackTime = 0f;
    private float direction = -1f;   
    private bool isRunning = false;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.right = new Vector2(-direction, 0f);
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

            isRunning = true;
            animator.SetBool("isIdle", false);
            animator.SetBool("isRun", true);
            rb.linearVelocity = new Vector2(direction*setttingsEnemy.Speed, rb.linearVelocityY);
            yield return new WaitForSeconds(runTime);
            isRunning = false;

            animator.SetBool("isRun", false);
            animator.SetBool("isAttack", true);
            rb.linearVelocity = new Vector2(0f, rb.linearVelocityY);
            yield return new WaitForSeconds(attackTime);
            animator.SetBool("isAttack", false);
            animator.SetBool("isIdle", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        if (Mathf.Abs(collision.GetContact(0).normal.x) < 0.5f) return;

        direction = -direction;
        transform.right = new Vector2(-direction, 0f);

        if (isRunning)
        {
            rb.linearVelocity = new Vector2(direction * setttingsEnemy.Speed, rb.linearVelocityY);
        }
    }
}

