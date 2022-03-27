using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon_Fireball : MonoBehaviour
{
    [SerializeField] private float _Damage;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collider.tag == "Player")
        {
            HealthSystem.instance.SetHealth(_Damage);
            //rb.bodyType = RigidbodyType2D.Static;
            Destroy(this.gameObject);
        }
    }
}
