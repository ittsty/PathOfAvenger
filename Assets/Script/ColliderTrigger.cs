using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public delegate void OnTrigger();
    public OnTrigger _OnTrigger;

    [SerializeField] private GameObject DoorOpen ;
    [SerializeField] private GameObject DoorClose;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if (_OnTrigger != null)
            {
                _OnTrigger.Invoke();
            }
            if (DoorClose != null)
            {
                this.DoorOpen.gameObject.SetActive(false);
                this.DoorClose.gameObject.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }
}
