using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
public class turret : MonoBehaviour
{
    private Vector3 direction;

    private Animator anim;
    // Start is called before the first frame update
    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }

    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        direction = transform.right;
    }
    // Update is called once per frame
    async void Update()
    {
        State = States.idle;
        Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position + transform.up * 0.2f, transform.position + transform.right * direction.x * (-9f) + transform.up * (-0.1f));
        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Hero>() == Hero.Instance)
                {
                    await Task.Delay(2500);
                    Fire();
                }
            }
        }
    }
    void Fire()
    {
        if (Hero.Instance.GetHp() > 0)
        {
            State = States.fire;
            Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position + transform.up * 0.2f + transform.right * direction.x * (-0.3f), transform.position + transform.right * direction.x * (-9f) + transform.up * (-0.1f));
            if (colliders.Length > 0)
            {
                foreach (Collider2D collider in colliders)
                {
                    if (collider.GetComponent<Hero>() == Hero.Instance)
                    {
                        Hero.Instance.GetDamage();
                    }
                }
            }
        }

    }
    public enum States
    {
        idle,
        fire
    }
}
