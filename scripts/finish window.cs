using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine;

public class finishwindow : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(10000);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
