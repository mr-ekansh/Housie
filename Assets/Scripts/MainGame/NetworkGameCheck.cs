using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class NetworkGameCheck : MonoBehaviour
{
    public bool networkjaldi5 = false;
    public bool networktopline = false;
    public bool networkmiddleline = false;
    public bool networkbottomline = false;
    public bool networkfullhouse = false;
    public bool checkingnumber = false;
    private NakamaTest _nakama;
    private GameChecker _gamechecker;
    private GameUpdation _gameupdate;
    private GameCall _gamecall;
    public int latestnumber = 0;
    private string userid = "";
    public GameObject _quitPanel;
    public GameObject Manager;

    void Start()
    {
        _quitPanel.SetActive(false);
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
        _gamecall = GameObject.FindWithTag("GameHandling").GetComponent<GameCall>();
    }

    public IEnumerator checkjaldi5()
    {
        var createuser_url = "http://34.121.136.31/housiekings/Jaldi5check.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "no")
        {
            latestnumber = _gamecall.finalnumber;
            StartCoroutine(PushJaldi5Winners(_nakama.USERID));
            networkjaldi5 = true;
            checkingnumber = true;
            _nakama.GameStop();
        }
        else
        {
            networkjaldi5 = true;
        }
    }

    public IEnumerator checktopline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/toplinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "no")
        {
            latestnumber = _gamecall.finalnumber;
            StartCoroutine(PushtoplineWinners(_nakama.USERID));
            networktopline = true;
            _nakama.toplineGameStop();
            checkingnumber = true;
        }
        else
        {
            networktopline = true;
        }
    }

    public IEnumerator checkmiddleline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/middlelinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "no")
        {
            latestnumber = _gamecall.finalnumber;
            StartCoroutine(PushmiddlelineWinners(_nakama.USERID));
            networkmiddleline = true;
            _nakama.middlelineGameStop();
            checkingnumber = true;
        }
        else
        {
            networkmiddleline = true;
        }
    }

    public IEnumerator checkbottomline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/bottomlinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "no")
        {
            latestnumber = _gamecall.finalnumber;
            StartCoroutine(PushbottomlineWinners(_nakama.USERID));
            networkbottomline = true;
            _nakama.bottomlineGameStop();
            checkingnumber = true;
        }
        else
        {
            networkbottomline = true;
        }
    }

    public IEnumerator checkfullhouse()
    {
        var createuser_url = "http://34.121.136.31/housiekings/fullhousecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "no")
        {
            latestnumber = _gamecall.finalnumber;
            StartCoroutine(PushfullhouseWinners(_nakama.USERID));
            networkfullhouse = true;
            _nakama.fullhouseGameStop();
            checkingnumber = true;
        }
        else
        {
            networkfullhouse = true;
        }
    }

    public IEnumerator PushJaldi5Winners(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Jaldi5winners.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator PushtoplineWinners(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/toplinewinners.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator PushmiddlelineWinners(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/middlelinewinners.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator PushbottomlineWinners(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/bottomlinewinners.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator PushfullhouseWinners(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/fullhousewinners.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator CheckUpdateJaldi5()
    {
        var createuser_url = "http://34.121.136.31/housiekings/Jaldi5check.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if (cu_get.text == "no")
        {
            _nakama.ActivateJaldi5();
            StartCoroutine(PushJaldi5Winners(_nakama.USERID));
        }
    }

    public IEnumerator CheckUpdateTopline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/toplinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if (cu_get.text == "no")
        {
            _nakama.ActivateTopline();
            StartCoroutine(PushtoplineWinners(_nakama.USERID));
        }
    }

    public IEnumerator CheckUpdateMiddleline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/middlelinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if (cu_get.text == "no")
        {
            _nakama.ActivateMiddleline();
            StartCoroutine(PushmiddlelineWinners(_nakama.USERID));
        }
    }

    public IEnumerator CheckUpdateBottomline()
    {
        var createuser_url = "http://34.121.136.31/housiekings/bottomlinecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if (cu_get.text == "no")
        {
            _nakama.ActivateBottomline();
            StartCoroutine(PushbottomlineWinners(_nakama.USERID));
        }
    }

    public IEnumerator CheckUpdateFullhouse()
    {
        var createuser_url = "http://34.121.136.31/housiekings/fullhousecheck.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if (cu_get.text == "no")
        {
            _nakama.ActivateFullhouse();
            StartCoroutine(PushfullhouseWinners(_nakama.USERID));
        }
    }

    public void QuitButton()
    {
        _quitPanel.SetActive(true);
    }

    public void Yesbutton()
    {
        _nakama.leavematchmain();
        _nakama.leavematchmain();
        Destroy(Manager);
        SceneManager.LoadScene("Loading");
    }

    public void Nobutton()
    {
        _quitPanel.SetActive(false);
    }
}
