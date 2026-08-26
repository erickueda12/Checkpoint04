using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;

    Transform player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.machine.CurrentState != GameManager.Instance.playingState)
            return;

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;

        direction.y = 0f;

        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Die()
    {
        Destroy(gameObject);

        GameManager.Instance.AddScore(100);
    }

    public void ReachPlayer()
    {
        Destroy(gameObject);
    }
}