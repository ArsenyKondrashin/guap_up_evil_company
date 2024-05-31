using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine;

public class ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    async void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        if (colliders.Length > 0)
        {
            if (colliders[0].GetComponent<Hero>() == Hero.Instance)
            {
                if (Hero.Instance.GetApparatusInfo())
                {
                    await Task.Delay(2000);
                    SceneManager.LoadScene(2);
                }

            }
        }
    }
}
