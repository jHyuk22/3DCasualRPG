using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;

    [SerializeField]
    private Animator animator;
    private int enemyCount = 0;

    private void Update()
    {
        animator.SetBool("IsAttacking", IsAttacking);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log($"TriggerEnter: {other.gameObject.tag}");
        if (other.gameObject.tag == "Monster")
        {
            enemyCount++;
            Debug.Log("enemyCount: " + enemyCount);
            if (!IsAttacking)
            {
                IsAttacking = true;
            }
        }
    }

    private void OnTriggerExit(UnityEngine.Collider other)
    {
        Debug.Log($"TriggerExit: {other.gameObject.tag}");
        if (other.gameObject.tag == "Monster")
        {
            enemyCount--;
            Debug.Log("enemyCount: " + enemyCount);
            if (enemyCount == 0)
                IsAttacking = false;
        }
    }
}
