using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public GameObject Target;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Arrow")
        {
            Destroy(this.Target);
        }
    }
}
