using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCheckerJaldi5 : MonoBehaviour
{
    private GameCallFreeroom _gamehandler;
    private NetworkGameCheckJaldi5 _networkcheck;
    public Text[] Ticket1;
    public Text[] Ticket2;
    public Text[] Ticket3;
    public Text[] Ticket4;
    public Text[] Ticket5;
    public Text[] Ticket6;
    public RawImage[] image1;
    public RawImage[] image2;
    public RawImage[] image3;
    public RawImage[] image4;
    public RawImage[] image5;
    public RawImage[] image6;
    public bool IsEarly5 = false;
    public int jaldi1 = 0;
    public int jaldi2 = 0;
    public int jaldi3 = 0;
    public int jaldi4 = 0;
    public int jaldi5 = 0;
    public int jaldi6 = 0;
    public Animation _anim;
    public Text _cointext;
    public GameObject COIN;
    private NakamaTest _nakama;

    void Start()
    {
        COIN.SetActive(false);
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _gamehandler = GameObject.FindWithTag("GameHandling").GetComponent<GameCallFreeroom>();
        _networkcheck = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheckJaldi5>();
    }

    public IEnumerator GameCheck()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            COIN.SetActive(true);
            _nakama.Jaldi5StartFreeroom();
            _cointext.text = "";
            _anim.Play();
            if (_networkcheck.checkingnumber == false)
            {
                _gamehandler.Numbercall();
            }
            else
            {
                _networkcheck.checkingnumber = false;
            }
            int k = _gamehandler.finalnumber;
            _cointext.text = k.ToString();
            yield return new WaitForSeconds(3);

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                {
                    image1[i].color = Color.green;
                    jaldi1++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                {
                    image2[i].color = Color.green;
                    jaldi2++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                {
                    image3[i].color = Color.green;
                    jaldi3++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                {
                    image4[i].color = Color.green;
                    jaldi4++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                {
                    image5[i].color = Color.green;
                    jaldi5++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                {
                    image6[i].color = Color.green;
                    jaldi6++;
                }
            }
            if (IsEarly5 == false)
            {
                if (jaldi1 == 5 || jaldi2 == 5 || jaldi3 == 5 || jaldi4 == 5 || jaldi5 == 5 || jaldi6 == 5)
                {
                    if (_networkcheck.networkjaldi5 == false)
                    {
                        StartCoroutine(_networkcheck.checkjaldi5());
                        IsEarly5 = true;
                        yield return new WaitForSeconds(10);
                    }
                    else
                    {
                        IsEarly5 = true;
                        yield return new WaitForSeconds(10);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(10);
                }
            }
            else
            {
                yield return new WaitForSeconds(10);
            }
            COIN.SetActive(false);
        }
    }
}
