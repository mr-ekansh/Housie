using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    public void scenechange()
    {
        SceneManager.LoadScene("Loading");
    }
}
