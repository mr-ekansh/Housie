using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleSQL;

public class GameUpdation : MonoBehaviour
{
    private GameChecker _maingamechecker;
    private GameCall _gamehandler;
    private NetworkGameCheck _networkcheck;
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
    public SimpleSQLManager dbManager;
    private NakamaTest _nakama;

    void Start()
    {
        _gamehandler = GameObject.FindWithTag("GameHandling").GetComponent<GameCall>();
        _networkcheck = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        _maingamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
    }

    public void GameUpdateJaldi5()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT * FROM NumberCalling WHERE gameno = '"+ _networkcheck.latestnumber +"'");
        int totalrows = dt.rows.Count;
        Debug.Log("rows are......." + totalrows.ToString());
        if(totalrows<=0 && _gamehandler.finalnumber != _networkcheck.latestnumber)
        {
            return;
        }
        else
        {
            int check = 0;
            for(int up = 0; up < 90; up++)
            {
                if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
                {
                    _gamehandler.SpotUpdateNumbercall();
                }
                check++;
                int k = _gamehandler.finalnumber;
                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                    {
                        image1[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline1 < 5)
                        {
                        _maingamechecker.topline1++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline1 < 5)
                        {
                        _maingamechecker.midline1++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline1 < 5)
                        {
                            _maingamechecker.bottomline1++;
                        }
                        _maingamechecker.jaldi1++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                    {
                        image2[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline2 < 5)
                        {
                        _maingamechecker.topline2++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline2 < 5)
                        {
                        _maingamechecker.midline2++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline2 < 5)
                        {
                            _maingamechecker.bottomline2++;
                        }
                        _maingamechecker.jaldi2++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                    {
                        image3[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline3 < 5)
                        {
                            _maingamechecker.topline3++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline3 < 5)
                        {
                            _maingamechecker.midline3++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline3 < 5)
                        {
                            _maingamechecker.bottomline3++;
                        }
                        _maingamechecker.jaldi3++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                    {
                        image4[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline4 < 5)
                        {
                            _maingamechecker.topline4++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline4 < 5)
                        {
                            _maingamechecker.midline4++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline4 < 5)
                        {
                            _maingamechecker.bottomline4++;
                        }
                        _maingamechecker.jaldi4++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                    {
                        image5[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline5 < 5)
                        {
                            _maingamechecker.topline5++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline5 < 5)
                        {
                            _maingamechecker.midline5++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline5 < 5)
                        {
                            _maingamechecker.bottomline5++;
                        }
                        _maingamechecker.jaldi5++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                    {
                        image6[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline6 < 5)
                        {
                            _maingamechecker.topline6++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline6 < 5)
                        {
                            _maingamechecker.midline6++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline6 < 5)
                        {
                            _maingamechecker.bottomline6++;
                        }
                        _maingamechecker.jaldi6++;
                    }
                }

                if ((_maingamechecker.jaldi1 == 5 || _maingamechecker.jaldi2 == 5 || _maingamechecker.jaldi3 == 5 || _maingamechecker.jaldi4 == 5 || _maingamechecker.jaldi5 == 5 || _maingamechecker.jaldi6 == 5) && _networkcheck.networkjaldi5 == false)
                {
                    _networkcheck.networkjaldi5 = true;
                    StartCoroutine(_networkcheck.CheckUpdateJaldi5());
                    StartCoroutine(_nakama.Jaldi5SpotOpcode());
                    return;
                }
                if (_gamehandler.finalnumber == _networkcheck.latestnumber)
                {
                    StartCoroutine(_nakama.Jaldi5SpotOpcode());
                    return;
                }
            }
        }
    }

    public void GameUpdateTopline()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT * FROM NumberCalling WHERE gameno = '"+ _networkcheck.latestnumber +"'");
        int totalrows = dt.rows.Count;
        Debug.Log(totalrows.ToString());
        if(totalrows<=0 && _gamehandler.finalnumber != _networkcheck.latestnumber)
        {
            return;
        }
        else
        {
            int check = 0;
            while(true)
            {
                if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
                {
                    _gamehandler.SpotUpdateNumbercall();
                }
                check++;
                int k = _gamehandler.finalnumber;
                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                    {
                        image1[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline1 < 5)
                        {
                        _maingamechecker.topline1++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline1 < 5)
                        {
                        _maingamechecker.midline1++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline1 < 5)
                        {
                            _maingamechecker.bottomline1++;
                        }
                        _maingamechecker.jaldi1++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                    {
                        image2[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline2 < 5)
                        {
                        _maingamechecker.topline2++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline2 < 5)
                        {
                        _maingamechecker.midline2++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline2 < 5)
                        {
                            _maingamechecker.bottomline2++;
                        }
                        _maingamechecker.jaldi2++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                    {
                        image3[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline3 < 5)
                        {
                            _maingamechecker.topline3++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline3 < 5)
                        {
                            _maingamechecker.midline3++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline3 < 5)
                        {
                            _maingamechecker.bottomline3++;
                        }
                        _maingamechecker.jaldi3++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                    {
                        image4[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline4 < 5)
                        {
                            _maingamechecker.topline4++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline4 < 5)
                        {
                            _maingamechecker.midline4++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline4 < 5)
                        {
                            _maingamechecker.bottomline4++;
                        }
                        _maingamechecker.jaldi4++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                    {
                        image5[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline5 < 5)
                        {
                            _maingamechecker.topline5++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline5 < 5)
                        {
                            _maingamechecker.midline5++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline5 < 5)
                        {
                            _maingamechecker.bottomline5++;
                        }
                        _maingamechecker.jaldi5++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                    {
                        image6[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline6 < 5)
                        {
                            _maingamechecker.topline6++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline6 < 5)
                        {
                            _maingamechecker.midline6++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline6 < 5)
                        {
                            _maingamechecker.bottomline6++;
                        }
                        _maingamechecker.jaldi6++;
                    }
                }

                if ((_maingamechecker.topline1 == 5 || _maingamechecker.topline2 == 5 || _maingamechecker.topline3 == 5 || _maingamechecker.topline4 == 5 || _maingamechecker.topline5 == 5 || _maingamechecker.topline6 == 5) && _networkcheck.networktopline == false)
                {
                    _networkcheck.networktopline = true;
                    StartCoroutine(_networkcheck.CheckUpdateTopline());
                    StartCoroutine(_nakama.ToplineSpotOpcode());
                    return;
                }
                if (_gamehandler.finalnumber == _networkcheck.latestnumber)
                {
                    StartCoroutine(_nakama.ToplineSpotOpcode());
                    return;
                }
            }
        }
    }

    public void GameUpdateMiddleline()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT * FROM NumberCalling WHERE gameno = '"+ _networkcheck.latestnumber +"'");
        int totalrows = dt.rows.Count;
        Debug.Log(totalrows.ToString());
        if(totalrows<=0 && _gamehandler.finalnumber != _networkcheck.latestnumber)
        {
            return;
        }
        else
        {
            int check = 0;
            while(true)
            {
                if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
                {
                    _gamehandler.SpotUpdateNumbercall();
                }
                check++;
                int k = _gamehandler.finalnumber;
                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                    {
                        image1[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline1 < 5)
                        {
                        _maingamechecker.topline1++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline1 < 5)
                        {
                        _maingamechecker.midline1++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline1 < 5)
                        {
                            _maingamechecker.bottomline1++;
                        }
                        _maingamechecker.jaldi1++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                    {
                        image2[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline2 < 5)
                        {
                        _maingamechecker.topline2++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline2 < 5)
                        {
                        _maingamechecker.midline2++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline2 < 5)
                        {
                            _maingamechecker.bottomline2++;
                        }
                        _maingamechecker.jaldi2++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                    {
                        image3[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline3 < 5)
                        {
                            _maingamechecker.topline3++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline3 < 5)
                        {
                            _maingamechecker.midline3++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline3 < 5)
                        {
                            _maingamechecker.bottomline3++;
                        }
                        _maingamechecker.jaldi3++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                    {
                        image4[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline4 < 5)
                        {
                            _maingamechecker.topline4++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline4 < 5)
                        {
                            _maingamechecker.midline4++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline4 < 5)
                        {
                            _maingamechecker.bottomline4++;
                        }
                        _maingamechecker.jaldi4++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                    {
                        image5[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline5 < 5)
                        {
                            _maingamechecker.topline5++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline5 < 5)
                        {
                            _maingamechecker.midline5++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline5 < 5)
                        {
                            _maingamechecker.bottomline5++;
                        }
                        _maingamechecker.jaldi5++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                    {
                        image6[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline6 < 5)
                        {
                            _maingamechecker.topline6++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline6 < 5)
                        {
                            _maingamechecker.midline6++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline6 < 5)
                        {
                            _maingamechecker.bottomline6++;
                        }
                        _maingamechecker.jaldi6++;
                    }
                }

                if ((_maingamechecker.midline1 == 5 || _maingamechecker.midline2 == 5 || _maingamechecker.midline3 == 5 || _maingamechecker.midline4 == 5 || _maingamechecker.midline5 == 5 || _maingamechecker.midline6 == 5) && _networkcheck.networkmiddleline == false)
                {
                    _networkcheck.networkmiddleline = true;
                    StartCoroutine(_networkcheck.CheckUpdateMiddleline());
                    StartCoroutine(_nakama.MiddlelineSpotOpcode());
                    return;
                }
                if (_gamehandler.finalnumber == _networkcheck.latestnumber)
                {
                    StartCoroutine(_nakama.MiddlelineSpotOpcode());
                    return;
                }
            }
        }
    }

    public void GameUpdateBottomline()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT * FROM NumberCalling WHERE gameno = '"+ _networkcheck.latestnumber +"'");
        int totalrows = dt.rows.Count;
        Debug.Log(totalrows.ToString());
        if(totalrows<=0 && _gamehandler.finalnumber != _networkcheck.latestnumber)
        {
            return;
        }
        else
        {
            int check = 0;
            while(true)
            {
                if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
                {
                    _gamehandler.SpotUpdateNumbercall();
                }
                check++;
                int k = _gamehandler.finalnumber;
                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                    {
                        image1[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline1 < 5)
                        {
                        _maingamechecker.topline1++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline1 < 5)
                        {
                        _maingamechecker.midline1++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline1 < 5)
                        {
                            _maingamechecker.bottomline1++;
                        }
                        _maingamechecker.jaldi1++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                    {
                        image2[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline2 < 5)
                        {
                        _maingamechecker.topline2++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline2 < 5)
                        {
                        _maingamechecker.midline2++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline2 < 5)
                        {
                            _maingamechecker.bottomline2++;
                        }
                        _maingamechecker.jaldi2++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                    {
                        image3[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline3 < 5)
                        {
                            _maingamechecker.topline3++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline3 < 5)
                        {
                            _maingamechecker.midline3++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline3 < 5)
                        {
                            _maingamechecker.bottomline3++;
                        }
                        _maingamechecker.jaldi3++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                    {
                        image4[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline4 < 5)
                        {
                            _maingamechecker.topline4++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline4 < 5)
                        {
                            _maingamechecker.midline4++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline4 < 5)
                        {
                            _maingamechecker.bottomline4++;
                        }
                        _maingamechecker.jaldi4++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                    {
                        image5[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline5 < 5)
                        {
                            _maingamechecker.topline5++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline5 < 5)
                        {
                            _maingamechecker.midline5++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline5 < 5)
                        {
                            _maingamechecker.bottomline5++;
                        }
                        _maingamechecker.jaldi5++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                    {
                        image6[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline6 < 5)
                        {
                            _maingamechecker.topline6++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline6 < 5)
                        {
                            _maingamechecker.midline6++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline6 < 5)
                        {
                            _maingamechecker.bottomline6++;
                        }
                        _maingamechecker.jaldi6++;
                    }
                }

                if ((_maingamechecker.bottomline1 == 5 || _maingamechecker.bottomline2 == 5 || _maingamechecker.bottomline3 == 5 || _maingamechecker.bottomline4 == 5 || _maingamechecker.bottomline5 == 5 || _maingamechecker.bottomline6 == 5) && _networkcheck.networkbottomline == false)
                {
                    _networkcheck.networkbottomline = true;
                    StartCoroutine(_networkcheck.CheckUpdateBottomline());
                    StartCoroutine(_nakama.BottomlineSpotOpcode());
                    return;
                }
                else if (_gamehandler.finalnumber == _networkcheck.latestnumber)
                {
                    StartCoroutine(_nakama.BottomlineSpotOpcode());
                    return;
                }
            }
        }
    }

    public void GameUpdateFullhouse()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT * FROM NumberCalling WHERE gameno = '"+ _networkcheck.latestnumber +"'");
        int totalrows = dt.rows.Count;
        Debug.Log(totalrows.ToString());
        if(totalrows<=0 && _gamehandler.finalnumber != _networkcheck.latestnumber)
        {
            return;
        }
        else
        {
            int check = 0;
            while(true)
            {
                if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
                {
                    _gamehandler.SpotUpdateNumbercall();
                }
                check++;
                int k = _gamehandler.finalnumber;
                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket1[i].text && image1[i].color != Color.green)
                    {
                        image1[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline1 < 5)
                        {
                        _maingamechecker.topline1++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline1 < 5)
                        {
                        _maingamechecker.midline1++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline1 < 5)
                        {
                            _maingamechecker.bottomline1++;
                        }
                        _maingamechecker.jaldi1++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket2[i].text && image2[i].color != Color.green)
                    {
                        image2[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline2 < 5)
                        {
                        _maingamechecker.topline2++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline2 < 5)
                        {
                        _maingamechecker.midline2++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline2 < 5)
                        {
                            _maingamechecker.bottomline2++;
                        }
                        _maingamechecker.jaldi2++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket3[i].text && image3[i].color != Color.green)
                    {
                        image3[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline3 < 5)
                        {
                            _maingamechecker.topline3++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline3 < 5)
                        {
                            _maingamechecker.midline3++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline3 < 5)
                        {
                            _maingamechecker.bottomline3++;
                        }
                        _maingamechecker.jaldi3++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket4[i].text && image4[i].color != Color.green)
                    {
                        image4[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline4 < 5)
                        {
                            _maingamechecker.topline4++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline4 < 5)
                        {
                            _maingamechecker.midline4++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline4 < 5)
                        {
                            _maingamechecker.bottomline4++;
                        }
                        _maingamechecker.jaldi4++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket5[i].text && image5[i].color != Color.green)
                    {
                        image5[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline5 < 5)
                        {
                            _maingamechecker.topline5++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline5 < 5)
                        {
                            _maingamechecker.midline5++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline5 < 5)
                        {
                            _maingamechecker.bottomline5++;
                        }
                        _maingamechecker.jaldi5++;
                    }
                }

                for (int i = 0; i < 27; i++)
                {
                    if (k.ToString() == Ticket6[i].text && image6[i].color != Color.green)
                    {
                        image6[i].color = Color.green;
                        if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && _maingamechecker.topline6 < 5)
                        {
                            _maingamechecker.topline6++;
                        }
                        else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && _maingamechecker.midline6 < 5)
                        {
                            _maingamechecker.midline6++;
                        }
                        else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && _maingamechecker.bottomline6 < 5)
                        {
                            _maingamechecker.bottomline6++;
                        }
                        _maingamechecker.jaldi6++;
                    }
                }

                if ((_maingamechecker.jaldi1 == 15 || _maingamechecker.jaldi2 == 15 || _maingamechecker.jaldi3 == 15 || _maingamechecker.jaldi4 == 15 || _maingamechecker.jaldi5 == 15 || _maingamechecker.jaldi6 == 15) && _networkcheck.networkfullhouse == false)
                {
                    _networkcheck.networkfullhouse = true;
                    StartCoroutine(_networkcheck.CheckUpdateFullhouse());
                    StartCoroutine(_nakama.FullhouseSpotOpcode());
                    return;
                }
                if (_gamehandler.finalnumber == _networkcheck.latestnumber)
                {
                    StartCoroutine(_nakama.FullhouseSpotOpcode());
                    return;
                }
            }
        }
    }
}
