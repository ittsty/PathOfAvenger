using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAtk : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject fx;
    [SerializeField] private Transform point;
    [SerializeField] AttackCon _AttackCon;

    private void OnEnable()
    {
        _AttackCon.Melee += MeleeAtk;
    }
    private void OnDisable()
    {
        _AttackCon.Melee -= MeleeAtk;
    }

    private void MeleeAtk()
    {
        animator.SetTrigger("atk");
        GameObject _fx = Instantiate(fx, point.position, point.rotation * Quaternion.Euler(0, 0, 140));
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

}
