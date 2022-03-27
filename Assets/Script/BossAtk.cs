using System.Collections;
using UnityEngine;

public class BossAtk : MonoBehaviour
{
    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private BossHealth bossHealth;

    [SerializeField] private GameObject HealthBar;
    private Transform _Player_pos;
    private Transform _Boss_pos;

    [SerializeField] private Transform Slam_sp1;
    [SerializeField] private Transform Slam_sp2;
    [SerializeField] private GameObject Slam;

    [SerializeField] private GameObject Melee;

    [SerializeField] private GameObject Area_hit;
    [SerializeField] private GameObject HitBox;

    [SerializeField] private GameObject FireBall;

    [SerializeField] private SpriteRenderer sr;
    private float bulletforce = 15f;
    private bool bossActive = false;
    private bool _isAtk = false;
    private bool _isDie = false;

    private Animator animator;
    private float Nextmove;
    private float CD = 3f;
    private void OnEnable()
    {
        colliderTrigger._OnTrigger += StartBattle;
        bossHealth.halfstage += Half;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        _Player_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _Boss_pos = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _isDie = BossHealth.instance.isDie;
        if (Time.time > Nextmove && bossActive == true && !_isAtk &&!_isDie)
        {
            int rnd = Random.Range(1, 5);
            switch (rnd)
            {
                case 1:
                    StartCoroutine(MeleeAtk());
                    break;
                case 2:
                    StartCoroutine(Slaming());
                    break;
                case 3:
                    StartCoroutine(Area());
                    break;
                case 4:
                    //StartCoroutine(MeleeAtk());
                    break;
            }
        }
        if( _isDie == true)
        {
            FireBall.gameObject.SetActive(false);
        }
    }

    private void StartBattle()
    {
        colliderTrigger._OnTrigger -= StartBattle;
        Sound_Manager.instance.ChangeBGM_boss();
        bossActive = true;
        HealthBar.SetActive(true);
        Nextmove = Time.time + 4f;
        BossHealth.instance._isval = true;
    }

    private void Half()
    {
        bossHealth.halfstage -= Half;
        FireBall.gameObject.SetActive(true);
    }

    IEnumerator Slaming()
    {
        _isAtk = true;
        animator.SetTrigger("foot_atk");
        yield return new WaitForSeconds(0.5f);
        GameObject Slam1 = Instantiate(Slam, Slam_sp1.position, Slam_sp1.rotation * Slam_sp1.rotation);
        Rigidbody2D rb = Slam1.GetComponent<Rigidbody2D>();
        rb.AddForce(Slam_sp1.up * bulletforce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        GameObject Slam2 = Instantiate(Slam, Slam_sp2.position, Slam_sp2.rotation * Slam_sp2.rotation);
        Rigidbody2D rb2 = Slam2.GetComponent<Rigidbody2D>();
        rb2.AddForce(Slam_sp1.up * bulletforce, ForceMode2D.Impulse);
        Nextmove = Time.time + CD;
        _isAtk = false;
    }

    IEnumerator MeleeAtk()
    {
        _isAtk = true;
        animator.SetTrigger("hand_atk");
        yield return new WaitForSeconds(0.5f);
        GameObject Slam2 = Instantiate(Melee, _Boss_pos.position, _Boss_pos.rotation * _Boss_pos.rotation);
        HitBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        HitBox.gameObject.SetActive(false);
        Nextmove = Time.time + CD;
        _isAtk = false;
    }

    IEnumerator Area()
    {
        _isAtk = true;
        animator.SetTrigger("floor_atk");
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject Areahit = Instantiate(Area_hit, _Player_pos.position, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        Nextmove = Time.time + CD;
        _isAtk = false;
    }


    IEnumerator Flash()
    {
        sr.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
    }
}
