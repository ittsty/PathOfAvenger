using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitboxScript : MonoBehaviour
{
    [SerializeField] private float _Damage;
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Armor")
        {
            Enamy_Armor armorScriept = collider.gameObject.GetComponent<Enamy_Armor>();
            armorScriept._GetDamage(_Damage * 0.8f);
        }
        if (collider.tag == "Melee")
        {
            Enamy_Melee meleeScriept = collider.gameObject.GetComponent<Enamy_Melee>();
            meleeScriept._GetDamage(_Damage * 1.1f);
        }
        if (collider.tag == "Range")
        {
            Enamy_Range rangeScriept = collider.gameObject.GetComponent<Enamy_Range>();
            rangeScriept._GetDamage(_Damage * 1f);
        }
        if (collider.tag == "Boss")
        {
            BossHealth bossScriept = collider.gameObject.GetComponent<BossHealth>();
            bossScriept._GetDamage(_Damage);
        }
    }
}
