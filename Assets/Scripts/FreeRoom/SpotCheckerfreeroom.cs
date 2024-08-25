using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SpotCheckerfreeroom : MonoBehaviour
{
    private SpotCallingfreeroom _spotcall;
    public Text[] Ticket;
    public RawImage[] image;
    private string gamecheck = "";
    private NakamaTest _nakama;
    public string checkspotno = "no";
    public GameObject clockanim;
    public GameObject updateText;

    void Start()
    {
        updateText.SetActive(true);
        clockanim.SetActive(true);
        checkspotno = "no";
        _spotcall = GameObject.FindWithTag("GameHandling").GetComponent<SpotCallingfreeroom>();
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
    }

    public IEnumerator checkSpot()
    {
        StartCoroutine(CheckJaldi5Winners(_nakama.freematchid));
        yield return new WaitForSeconds(3);
        while (true)
        {
            updateText.SetActive(false);
            clockanim.SetActive(false);
            checkspotno = "no";
            StartCoroutine(CheckJaldi5Winners(_nakama.freematchid));
            yield return new WaitForSeconds(3);
            _spotcall.SpotNumbercall();
            yield return new WaitForSeconds(1);
            int e = 0;
            int k = _spotcall.finalnumber;
            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket[i].text)
                {
                    checkspotno = "yes";
                    image[i].color = Color.green;
                    yield return new WaitForSeconds(3);
                    _nakama.SendSpotMatchfreeroom();
                    e = 1;
                    yield return new WaitForSeconds(3);
                }
            }
            if (e == 0)
            {
                yield return new WaitForSeconds(6);
            }
        }
    }

    public IEnumerator CheckJaldi5Winners(string matchid)
    {
        matchid = "m" + matchid;
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        WWW download = new WWW("http://34.121.136.31/housiekings/CheckWinnersfreeroom.php", form);
        yield return download;
        if (download.text == "1")
        {
            StopCoroutine(checkSpot());
            _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
            _nakama.GameContfreeroom();
        }
    }
}
