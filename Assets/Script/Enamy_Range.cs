using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enamy_Range : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float HP = 100f;
    [SerializeField] private Transform target;
    private float _NextAttack;
    private float _Cooldown = 2f;

    private bool _isWalk = false;
    private bool _isDie = false;
    private bool _isATK = false;

    public Transform firepoint;
    public GameObject bullet; 
    public float bulletforce = 20f;

    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D rb_firepoint;

    public static Enamy_Range instance;
    void Start()
    {
        instance = this;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        animator.SetBool("isWalk", _isWalk);
        Fliping();
    }
    private void FixedUpdate()
    {
        Seeking();
        rb_firepoint.MovePosition(rb.position);
        Vector2 lookdir = (Vector2)target.position - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb_firepoint.rotation = angle;
    }

    private void Fliping()
    {
        if (rb.position.x < target.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    private void Seeking()
    {
        if (10f > Vector2.Distance(transform.position, target.position) && Vector2.Distance(transform.position, target.position) > 1.5f && !_isDie)
        {
            rb.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            _isWalk = true;
        }
        if (10f > Vector2.Distance(transform.position, target.position) && Vector2.Distance(transform.position, target.position) > 1.5f && !_isATK && !_isDie && Time.time > _NextAttack)
        {
            StartCoroutine(shootplayer());
            _isWalk = false;
            _NextAttack = Time.time + _Cooldown;
        }
        else
        {
            _isWalk = false;
        }
    }
    IEnumerator shootplayer()
    {
        animator.SetTrigger("isAttack");
        _isATK = true;
        yield return new WaitForSeconds(0.25f);
        GameObject bull = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
        _isATK = false;
    }
    public void _GetDamage(float Dmg)
    {
        HP -= Dmg;
        if (HP > 0)
        {
            StartCoroutine(GetDamage());
        }
        else
        {
            _isDie = true;
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetBool("isDie", true);
        }
    }
    IEnumerator GetDamage()
    {
        for (int n = 0; n < 3; n++)
        {
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("isHurt");
            yield return new WaitForSeconds(0.1f);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
