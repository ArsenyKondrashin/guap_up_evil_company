using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor.SearchService;
using System.Threading;


public class Hero : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    [SerializeField] private int scrap = 0;
    [SerializeField] private bool apparatus = false;
    [SerializeField] private SpriteRenderer apparatusSpriteRenderer;
    [SerializeField] private Sprite apparatusSprite1;
    [SerializeField] private Sprite apparatusSprite2;


    [SerializeField] private float speed = 3f;
    [SerializeField] private float jump_force = 6f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float GroundedRadius = 0.01f;
    [SerializeField] private SpriteRenderer[] health;
    [SerializeField] private Sprite hpDead;

    private bool apparatusWindow;
    private bool stopMove;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public static Hero Instance { get; set; }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }

    }
    private void Awake()
    {
        stopMove = false;
        apparatusWindow = true;
        hp = 5;
        Instance = this;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    async private void Update()
    {

        if (isGrounded)
        {
            State = States.idle;
        }
        else
        {
            State = States.jump;
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        for (int i = 0; i < health.Length; i++)
        {
            if (i + 1 > hp)
            {
                health[i].sprite = hpDead;
            }
        }
        if (apparatus && apparatusWindow)
        {
            apparatusWindow = false;
            stopMove = true;
            apparatusSpriteRenderer.sprite = apparatusSprite2;
            await Task.Delay(5000);
            apparatusSpriteRenderer.sprite = apparatusSprite1;
            stopMove = false;
        }
        if (hp <= 0)
        {
            Death();
        }
    }
    private void Run()
    {
        if (!stopMove)
        {
            if (isGrounded) State = States.run;
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

            sprite.flipX = dir.x < 0.0f;
        }

    }
    private void Jump()
    {
        if (!stopMove)
        {
            rb.AddForce(transform.up * jump_force, ForceMode2D.Impulse);
        }

    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + transform.up * (-0.3f), GroundedRadius);
        // Debug.Log(transform.position);
        isGrounded = collider.Length > 1;
    }
    public void GetDamage()
    {
        hp -= 1;
        Debug.Log(hp);
    }
    public void Death()
    {
        State = States.dead;

        SceneManager.LoadScene(3);
    }
    public void AddScrap(int value)
    {
        scrap += value;
        DataHolder.AddScrap(value);
    }
    public void toggleApparatus()
    {
        apparatus = true;
    }
    public bool GetApparatusInfo()
    {
        return apparatus;
    }
    public int GetScrapInfo()
    {
        return scrap;
    }
    public int GetHp()
    {
        return hp;
    }
}



public enum States
{
    idle,
    run,
    jump,
    dead
}