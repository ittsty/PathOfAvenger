using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D FP;

    [SerializeField] private float movespeed = 5f;
    [SerializeField] private Camera cam;

    [SerializeField] private float move;
    private Vector2 movement;
    private Vector2 mousepos;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        move = movement.sqrMagnitude;
        animator.SetFloat("Speed", movement.sqrMagnitude);
        ismoving();
    }

    private void ismoving()
    {
        if (movement.sqrMagnitude > 0)
        {
            Sound_Manager.instance.playwalk();
        }
        else if (movement.sqrMagnitude == 0)
        {
            Sound_Manager.instance.stopwalk();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * movespeed * Time.fixedDeltaTime));
        FP.MovePosition(rb.position + (movement * movespeed * Time.fixedDeltaTime));
        Vector2 lookdir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        FP.rotation = angle;
    }
}
