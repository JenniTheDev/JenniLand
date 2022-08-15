using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] Spawner objectSpawner;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        objectSpawner.Return(collision.gameObject);
    }
}