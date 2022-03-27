using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassCon : MonoBehaviour
{
    private enum ActiveClass { Melee, Range, Magic };
    [SerializeReference] private ClassSO Class1;
    [SerializeReference] private ClassSO Class2;
    [SerializeReference] private ClassSO Class3;
    private ActiveClass activeClass;
    [SerializeField] private GameObject _Classeff;
    [SerializeField] private SpriteRenderer ClassUI;
    [SerializeField] private Sprite[] spriteArray;


    public delegate void ChangeCooldown(float cooldown);
    public ChangeCooldown OnChangeCD;

    public delegate void ChangeingClass(string _class);
    public ChangeingClass OnChangeClass;
    void Start()
    {
        activeClass = ActiveClass.Melee;
        OnChangeCD.Invoke(Class1.CoolDown);
        OnChangeClass.Invoke(Class1.ClassName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeClass();
            _Classeff.gameObject.SetActive(true);
        }
    }

    private void ChangeClass()
    {
        if (activeClass == ActiveClass.Melee)
        {
            StartCoroutine(Flash());
            activeClass = ActiveClass.Range;
            OnChangeCD.Invoke(Class2.CoolDown);
            OnChangeClass.Invoke(Class2.ClassName);
            ClassUI.sprite = spriteArray[1];
        }
        else if (activeClass == ActiveClass.Range)
        {
            StartCoroutine(Flash());
            activeClass = ActiveClass.Magic;
            OnChangeCD.Invoke(Class3.CoolDown);
            OnChangeClass.Invoke(Class3.ClassName);
            ClassUI.sprite = spriteArray[2];
        }
        else if (activeClass == ActiveClass.Magic)
        {
            StartCoroutine(Flash());
            activeClass = ActiveClass.Melee;
            OnChangeCD.Invoke(Class1.CoolDown);
            OnChangeClass.Invoke(Class1.ClassName);
            ClassUI.sprite = spriteArray[0];
        }
    }

    IEnumerator Flash()
    {

        for (int n = 0; n < 1; n++)
        {
            ClassUI.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            ClassUI.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
