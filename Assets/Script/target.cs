using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public void getHit()
    {
        //Debug.Log("hit");
        Gamemaneger.instance.targethit += 1;
        Destroy(this.gameObject);
    }
}
