using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SpotChecker : MonoBehaviour
{
    private SpotCalling _spotcall;
    public Text[] Ticket;
    public RawImage[] image;
    private TicketBackend _ticketbackend;
    private string gamecheck = "";
    private NakamaTest _nakama;
    public GameObject updateText;
    public GameObject clockanim;
    public string checkspotno = "no";

    void Start()
    {
        updateText.SetActive(true);
        clockanim.SetActive(true);
        checkspotno = "no";
        _spotcall = GameObject.FindWithTag("GameHandling").GetComponent<SpotCalling>();
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
    }

    public IEnumerator checkSpot()
    {
        StartCoroutine(Enablespotcheck("Jaldi5"));
        StartCoroutine(CheckJaldi5Winners());
        yield return new WaitForSeconds(2);
        while(true)
        {
            checkspotno = "no";
            updateText.SetActive(false);
            clockanim.SetActive(false);
            StartCoroutine(CheckJaldi5Winners());
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
                    _nakama.SendJaldi5Match();
                    e = 1;
                    yield return new WaitForSeconds(3);
                }
            }
            if(e == 0)
            {
                yield return new WaitForSeconds(6);
            }
            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator Enablespotcheck(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Enablespotcheck.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }
    
    public IEnumerator CheckJaldi5Winners()
    {
        var createuser_url = "http://34.121.136.31/housiekings/CheckJaldi5Winners.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        if(cu_get.text == "1")
        {
            StopCoroutine(checkSpot());
            _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
            _nakama.GameCont();
        }
    }
}
