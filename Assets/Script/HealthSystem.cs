using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;

    [SerializeField] private float _maxMana = 100f;
    [SerializeField] private float _currentMana = 100f;
    public float Mana => _currentMana;

    [SerializeField] private Slider _HPslider;
    [SerializeField] private Slider _MPslider;

    [SerializeField] private CharacterHealth CH;
    [SerializeField] private AttackCon AC;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;


    [SerializeField] private GameObject overpanal;

    public static HealthSystem instance;
    private void OnEnable()
    {
        CH.GetDamage += SetHealth;
        CH.SetMaxHealth += SetMaxHealth;
        CH.SetMaxMana += SetMaxMana;
        CH.AddHealth += AddHealth;
        CH.AddMana += AddMana;
        AC.UseMana += SetMana;
    }
    private void OnDisable()
    {
        CH.GetDamage -= SetHealth;
        CH.SetMaxHealth -= SetMaxHealth;
        CH.SetMaxMana -= SetMaxMana;
        CH.AddHealth -= AddHealth;
        CH.AddMana -= AddMana;
        AC.UseMana -= SetMana;
    }

    void Start()
    {
        instance = this;
    }
    private void SetMaxHealth(float Health)
    {
        _HPslider.maxValue = Health;
        _HPslider.value = Health;
    }
    public void SetHealth(float Health)
    {
        _currentHealth -= Health;
        if(_currentHealth > 1)
        {
            _HPslider.value = _currentHealth;
            StartCoroutine(Flash());
        }
        else
        {
            _HPslider.value = _currentHealth;
            rb.bodyType = RigidbodyType2D.Static;
            Sound_Manager.instance.playDie();
            overpanal.gameObject.SetActive(true);
        }
    }

    public void AddHealth(float Health)
    {
        _currentHealth += Health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        _HPslider.value = _currentHealth;
    }

    private void SetMaxMana(float Mana)
    {
        _MPslider.maxValue = Mana;
        _MPslider.value = Mana;
    }
    public void SetMana(float Mana)
    {
        _currentMana -= Mana;
        _MPslider.value = _currentMana;
    }

    public void AddMana(float Mana)
    {
        _currentMana += Mana;
        if (_currentMana > _maxMana)
        {
            _currentMana = _maxMana;
        }
        _MPslider.value = _currentMana;
    }

    IEnumerator Flash()
    {
        for (int n = 0; n < 3; n++)
        {
            sr.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
