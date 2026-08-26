using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float damageCooldown = 1f;

    private float lastDamageTime;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
            return;

        if (Time.time < lastDamageTime + damageCooldown)
            return;

        lastDamageTime = Time.time;

        GameManager.Instance.LoseLife();

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.ReachPlayer();
        }
    }
}