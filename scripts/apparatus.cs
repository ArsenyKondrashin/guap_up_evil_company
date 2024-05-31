using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class apparatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        if (colliders.Length > 0)
        {
            if (colliders[0].GetComponent<Hero>() == Hero.Instance)
            {
                Hero.Instance.AddScrap(100);
                Hero.Instance.toggleApparatus();
                Destroy(this.gameObject);

            }
        }
    }
}
