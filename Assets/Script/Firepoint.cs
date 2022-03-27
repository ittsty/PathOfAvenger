using UnityEngine;

public class Firepoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firepoint;
    [SerializeField] private float bulletforce = 20f;
    [SerializeField] private float _cooldown = 1.5f;

    private float _NextFire;
    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 lookdir = (Vector2)target.position - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (Time.time > _NextFire)
        {
            shootplayer();
            _NextFire = Time.time + _cooldown;
        }
    }

    private void shootplayer()
    {
        Sound_Manager.instance.playBossFB();
        GameObject bull = Instantiate(bullet, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bull.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
