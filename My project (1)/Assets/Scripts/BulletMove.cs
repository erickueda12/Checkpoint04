using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float timeToReset = 3f;
    [SerializeField] string enemyTag = "Enemy";

    public void StartProjectile()
    {
        CancelInvoke();

        Invoke(nameof(ResetBullet), timeToReset);
    }

    private void Update()
    {
        transform.Translate(
            Vector3.forward * speed * Time.deltaTime
        );
    }

    private void ResetBullet()
    {
        CancelInvoke();

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Die();
            }
        }

        ResetBullet();  
    }
}