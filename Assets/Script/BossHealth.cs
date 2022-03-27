using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    [SerializeField] private float maxHP = 600f;
    [SerializeField] private float HP = 600f;
    [SerializeField] private GameObject FireBall;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject box;

    [SerializeField] private Slider _bossHP_slider;
    public static BossHealth instance;
    private Animator animator;

    public bool isDie = false;
    public bool _isval = false;

    public delegate void _stage2();
    public _stage2 halfstage;
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        _bossHP_slider.maxValue = maxHP;
        _bossHP_slider.value = HP;

    }

    void Update()
    {
        if (HP / maxHP < 0.5f)
        {
            if(halfstage != null)
            {
                halfstage.Invoke();
            }
        }
    }

    public void _GetDamage(float Dmg)
    {
        if (_isval == true)
        {
            HP -= Dmg;
            if (HP > 0)
            {
                _bossHP_slider.value = HP;
            }
            else if (HP < 1)
            {
                _bossHP_slider.gameObject.SetActive(false);
                isDie = true;
                animator.SetBool("isDie", true);
            }
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
        Sound_Manager.instance.playItem();
        GameObject _effect = Instantiate(effect, spawnpoint.position, spawnpoint.rotation);
        GameObject _box = Instantiate(box, spawnpoint.position, spawnpoint.rotation);
        Sound_Manager.instance.ChangeBGM_normal();
    }
}
