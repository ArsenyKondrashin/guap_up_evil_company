using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
public class turret : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private AudioSource fireSound;

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
        if (DataHolder.GetHpInfo() > 0)
        {
            Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position + transform.up * 0.2f, transform.position + transform.right * direction.x * (-9f) + transform.up * (-0.1f));
            if (colliders.Length > 0)
            {
                foreach (Collider2D collider in colliders)
                {
                    if (DataHolder.GetHpInfo() > 0)
                    {
                        if (collider.GetComponent<Hero>() == Hero.Instance)
                        {
                            await Task.Delay(1800);
                            if (collider.GetComponent<Hero>() == Hero.Instance)
                            {
                                fireSound.Play();
                            }
                            await Task.Delay(700);
                            if (collider.GetComponent<Hero>() == Hero.Instance)
                            {
                                Fire();
                            }

                        }
                    }
                }
            }


        }
        void Fire()
        {
            if (DataHolder.GetHpInfo() > 0)
            {

                State = States.fire;
                Collider2D[] colliders = Physics2D.OverlapAreaAll(transform.position + transform.up * 0.2f + transform.right * direction.x * (-0.3f), transform.position + transform.right * direction.x * (-9f) + transform.up * (-0.1f));
                if (colliders.Length > 0)
                {
                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.GetComponent<Hero>() == Hero.Instance)
                        {
                            DataHolder.MinusHp(1);
                            Hero.Instance.GetDamage();
                        }
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
