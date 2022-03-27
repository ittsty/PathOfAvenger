using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ClassStat")]
public class ClassSO : ScriptableObject
{
    [SerializeField] private string _ClassName = "Archer";
    public string ClassName => _ClassName;

    [SerializeField] private float _CoolDown = 0.5f;
    public float CoolDown => _CoolDown;

    [SerializeField] private float _Def = 0.5f;
    public float Def => _Def;
}
