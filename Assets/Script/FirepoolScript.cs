using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepoolScript : MonoBehaviour
{
    private PolygonCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<PolygonCollider2D>();
    }
    private void EnableHitbox()
    {
        _collider.enabled = true;
    }
    private void DisableHitbox()
    {
        _collider.enabled = false;
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            HealthSystem.instance.SetHealth(22f);
        }
    }
}
