using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class bug : MonoBehaviour
{
    private float speed = 1.5f;
    private Vector3 direction;
    private SpriteRenderer sprite;

    private void Awake() // Метод, который вызывается при создании объекта
    {
        sprite = GetComponentInChildren<SpriteRenderer>(); // Присваивает переменной sprite компонент SpriteRenderer, который находится в дочернем объекте
    }

    private void Start() // Метод, который вызывается при запуске сцены
    {
        direction = transform.right; // Присваивает переменной direction значение вектора, указывающего вправо относительно объекта
    }

    private void Move() // Метод, который отвечает за перемещение врага
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.3f + transform.right * direction.x * 0.8f, 0.1f);
        if (colliders.Length > 0)
        {
            if (colliders[0].GetComponent<Hero>() != Hero.Instance)
            {
                direction *= -1f;
            }
        }
        // Если массив colliders не пустой, то меняет направление врага на противоположное
        transform.Translate(direction * speed * Time.deltaTime); // Перемещает объект на заданное расстояние в заданном направлении с учетом скорости и времени кадра
        sprite.flipX = direction.x > 0.0f; // Отражает спрайт по горизонтали в зависимости от направления

    }

    private void Update() // Метод, который вызывается каждый кадр
    {

        Move(); // Вызывает метод Move

    }


    private void OnCollisionEnter2D(Collision2D collision) // Метод, который вызывается при столкновении с другим коллайдером
    {

        if (collision.gameObject == Hero.Instance.gameObject) // Если объект столкновения является героем
        {
            DataHolder.MinusHp(1);
            Hero.Instance.GetDamage(); // Вызывает метод GetDamage у героя
        }


    }
}
