using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCon : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void onDisable()
    {
        this.gameObject.SetActive(false);
    }

}
