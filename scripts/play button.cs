using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class playbutton : MonoBehaviour
{
    public void Play(int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }
}
