using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private float _Damage;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Range")
        {
            Enamy_Range rangeScriept = collision.gameObject.GetComponent<Enamy_Range>();
            rangeScriept._GetDamage(_Damage * 1.15f);
        }
        if (collision.collider.tag == "Armor")
        {
            Enamy_Armor armorScriept = collision.gameObject.GetComponent<Enamy_Armor>();
            armorScriept._GetDamage(_Damage * 0.5f);
        }
        if (collision.collider.tag == "Melee")
        {
            Enamy_Melee meleeScriept = collision.gameObject.GetComponent<Enamy_Melee>();
            meleeScriept._GetDamage(_Damage);
        }
        if (collision.collider.tag == "Boss")
        {
            BossHealth bossScriept = collision.gameObject.GetComponent<BossHealth>();
            bossScriept._GetDamage(_Damage);
        }
        if (collision.collider.tag == "Target")
        {
            target _target = collision.gameObject.GetComponent<target>();
            _target.getHit();
        }
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(this.gameObject);
    }
}
