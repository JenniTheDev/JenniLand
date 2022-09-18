using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    [SerializeField] private JenniRunEventManager gameEventManager;
    [SerializeField] private LayerMask obstacleLayer;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == obstacleLayer)
        {
            gameEventManager.RaiseOnJenniRunStop();
        }
    }
}