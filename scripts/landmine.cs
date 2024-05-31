using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Lanmine : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource explode;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }

    }
    private async void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == Hero.Instance.gameObject)
        {
            State = States.explode;
            explode.Play();
            DataHolder.MinusHp(5);
            await Task.Delay(1000);
            Hero.Instance.GetDamage();
            Hero.Instance.GetDamage();
            Hero.Instance.GetDamage();
            Hero.Instance.GetDamage();
            Hero.Instance.GetDamage();
        }


    }
    public enum States
    {
        idle,
        explode,
        exit
    }
}
