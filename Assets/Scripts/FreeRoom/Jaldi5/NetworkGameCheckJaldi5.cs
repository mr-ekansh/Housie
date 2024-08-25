using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class NetworkGameCheckJaldi5 : MonoBehaviour
{
    public bool networkjaldi5 = false;
    public bool checkingnumber = false;
    private NakamaTest _nakama;
    private GameCheckerJaldi5 _gamechecker;
    private GameUpdationJaldi5 _gameupdate;
    private GameCallFreeroom _gamecall;
    public int latestnumber = 0;

    void Start()
    {
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameCheckerJaldi5>();
        _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdationJaldi5>();
        _gamecall = GameObject.FindWithTag("GameHandling").GetComponent<GameCallFreeroom>();
    }

    public IEnumerator checkjaldi5()
    {
        latestnumber = _gamecall.finalnumber;       
        StartCoroutine(PushJaldi5Winners(_nakama.USERID, _nakama.freematchid));
        StopCoroutine(_nakama.maingamechecker);
        yield return new WaitForSeconds(2);
        _nakama.GameStopfreeroom();
        networkjaldi5 = true;
        checkingnumber = true;
    }

    private IEnumerator PushJaldi5Winners(string userid,string matchid)
    {
        matchid = "m" + matchid;
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("matchid", matchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/CreateTable.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public void GetLatestNumber()
    {
        _gameupdate.GameUpdateJaldi5();
    }

    public void CheckUpdateJaldi5()
    {
        _nakama.ActivateFreeroomSpot();
        StartCoroutine(PushJaldi5Winners(_nakama.USERID,_nakama.freematchid));
    }
}
