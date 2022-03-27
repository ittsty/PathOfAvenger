using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyEffDestroy : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            HealthSystem.instance.SetHealth(20f);
        }
    }
}
