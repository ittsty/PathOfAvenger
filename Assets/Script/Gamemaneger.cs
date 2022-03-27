using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    public int targethit = 0;
    public static Gamemaneger instance;
    [SerializeField] private ColliderTrigger Ct1;
    [SerializeField] private ColliderTrigger Ct2;

    [SerializeField] private GameObject bossdoor_o;
    [SerializeField] private GameObject bossdoor_c;

    public delegate void spawnitem();
    public spawnitem _spawnitem;
    [SerializeField] private int _platecount;

    void Start()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Ct1._OnTrigger += platecount;
        Ct2._OnTrigger += platecount;
    }

    // Update is called once per frame
    void Update()
    {
        if(targethit >= 2)
        {
            if(_spawnitem != null)
            {
                _spawnitem.Invoke();
            }
        }
        if (_platecount >= 2)
        {
            bossdoor_c.gameObject.SetActive(false);
            bossdoor_o.gameObject.SetActive(true);
        }
    }

    void platecount()
    {
        Sound_Manager.instance.playPlate();
        _platecount += 1;
    }
}
