using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _maxMana = 100f;
    [SerializeField] private SpriteRenderer HP_bot;
    [SerializeField] private SpriteRenderer MP_bot;

    [SerializeField] private GameObject HP_eff;
    [SerializeField] private GameObject MP_eff;

    private bool _MPCooldown = false;
    private bool _HPCooldown = false;

    public delegate void _SetMaxHealth(float Health);
    public _SetMaxHealth SetMaxHealth;
    public delegate void _SetMaxMana(float Mana);
    public _SetMaxMana SetMaxMana;
    public delegate void _GetDamage(float Health);
    public _GetDamage GetDamage;

    public delegate void _AddHealth(float Health);
    public _AddHealth AddHealth;
    public delegate void _AddMana(float Mana);
    public _AddMana AddMana;

    void Start()
    {
        SetMaxHealth.Invoke(_maxHealth);
        SetMaxMana.Invoke(_maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !_HPCooldown)
        {
            AddHealth.Invoke(50f);
            HP_eff.gameObject.SetActive(true);
            StartCoroutine(HP_cooldown());
        }
        if (Input.GetKeyDown(KeyCode.V) && !_MPCooldown)
        {
            AddMana.Invoke(50f);
            MP_eff.gameObject.SetActive(true);
            StartCoroutine(MP_cooldown());
        }
    }

    IEnumerator MP_cooldown()
    {
        _MPCooldown = true;
        MP_bot.color = Color.gray;
        yield return new WaitForSeconds(15f);
        MP_bot.color = Color.white;
        _MPCooldown = false;
    }
    IEnumerator HP_cooldown()
    {
        _HPCooldown = true;
        HP_bot.color = Color.gray;
        yield return new WaitForSeconds(15f);
        HP_bot.color = Color.white;
        _HPCooldown = false;
    }
}
