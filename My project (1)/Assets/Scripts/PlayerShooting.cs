using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private PoolManager poolManager;

    private void Update()
    {
        if (GameManager.Instance.machine.CurrentState != GameManager.Instance.playingState)
            return;

        Shoot();
    }

    private void Shoot()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
            return;

        GameObject bulletObject = poolManager.PooledGameObject();

        if (bulletObject == null)
            return;

        bulletObject.transform.position = bulletSpawnPoint.position;
        bulletObject.transform.rotation = bulletSpawnPoint.rotation;

        bulletObject.SetActive(true);

        BulletMove bullet = bulletObject.GetComponent<BulletMove>();

        bullet.StartProjectile();
    }
}