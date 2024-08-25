using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    private Image _progressbar;
    private int selection;

    void Start()
    {
        StartCoroutine(LoadAsyncOperationMainGame());
    }

    IEnumerator LoadAsyncOperationMainGame()
    {
        AsyncOperation gamelevel = SceneManager.LoadSceneAsync("MainMenu");
        while (gamelevel.progress < 1)
        {
            _progressbar.fillAmount = gamelevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
