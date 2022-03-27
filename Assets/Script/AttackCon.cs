using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCon : MonoBehaviour
{
    [SerializeField] private Transform _firepoint;
    [SerializeField] private GameObject _select_bullet;
    [SerializeField] private GameObject[] bullet;
    private float _Bulletforce = 20f;
    private float _Cooldown = 2f;
    private string _Activeclass;

    public delegate void MeleeAttk();
    public MeleeAttk Melee;
    public delegate void _UseMana(float Mana);
    public _UseMana UseMana;

    [SerializeField] private GameObject[] Weapon;
    private float Nextfire;

    [SerializeField] ClassCon _ClassCon;

    private void OnEnable()
    {
        _ClassCon.OnChangeCD += ChangeCD;
        _ClassCon.OnChangeClass += ChangeClass;
    }
    private void OnDisable()
    {
        _ClassCon.OnChangeCD -= ChangeCD;
        _ClassCon.OnChangeClass -= ChangeClass;

    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > Nextfire)
        {
            if(_Activeclass != "Melee")
            {
                Shoot();
            }
            else
            {
                MeleeAtk();
            }
        }
    }

    private void MeleeAtk()
    {
        Nextfire = Time.time + _Cooldown;
        Sound_Manager.instance.playSword();
        Melee.Invoke();
    }

    private void Shoot()
    {
        Nextfire = Time.time + _Cooldown;
        if (_Activeclass == "Magic" && (HealthSystem.instance.Mana >12f) )
        {
            SpawnBullet();
            Sound_Manager.instance.playPlayerFB();
            UseMana.Invoke(12f);
        }
        else if (_Activeclass == "Archer")
        {
            SpawnBullet();
            Sound_Manager.instance.playBow();
        }
    }

    private void SpawnBullet()
    {
        GameObject bull = Instantiate(_select_bullet, _firepoint.position, _firepoint.rotation);
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        rb.AddForce(_firepoint.up * _Bulletforce, ForceMode2D.Impulse);
    }

    private void ChangeCD(float _CD)
    {
        _Cooldown = _CD;
    }

    private void ChangeClass(string _Class)
    {
        _Activeclass = _Class;
        switch (_Activeclass)
        {
            case "Melee":
                Weapon[0].SetActive(true);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(false);
                break;
            case "Archer":
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(true);
                Weapon[2].SetActive(false);
                _select_bullet = bullet[0];
                break;
            case "Magic":
                Weapon[0].SetActive(false);
                Weapon[1].SetActive(false);
                Weapon[2].SetActive(true);
                _select_bullet = bullet[1];
                break;
        }
    }
}
