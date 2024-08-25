using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpdationJaldi5 : MonoBehaviour
{
    private GameCheckerJaldi5 _maingamechecker;
    private GameCallFreeroom _gamehandler;
    private NetworkGameCheckJaldi5 _networkcheck;

    void Start()
    {
        _gamehandler = GameObject.FindWithTag("GameHandling").GetComponent<GameCallFreeroom>();
        _networkcheck = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheckJaldi5>();
        _maingamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameCheckerJaldi5>();
    }

    public void GameUpdateJaldi5()
    {
        int check = 0;
        while (true)
        {
            if ((_gamehandler.finalnumber != _networkcheck.latestnumber) && check>0)
            {
                _gamehandler.SpotUpdateNumbercall();
            }
            check++;
            int k = _gamehandler.finalnumber;
            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket1[i].text && _maingamechecker.image1[i].color != Color.green)
                {
                    _maingamechecker.image1[i].color = Color.green;
                    _maingamechecker.jaldi1++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket2[i].text && _maingamechecker.image2[i].color != Color.green)
                {
                    _maingamechecker.image2[i].color = Color.green;
                    _maingamechecker.jaldi2++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket3[i].text && _maingamechecker.image3[i].color != Color.green)
                {
                    _maingamechecker.image3[i].color = Color.green;
                    _maingamechecker.jaldi3++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket4[i].text && _maingamechecker.image4[i].color != Color.green)
                {
                    _maingamechecker.image4[i].color = Color.green;
                    _maingamechecker.jaldi4++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket5[i].text && _maingamechecker.image5[i].color != Color.green)
                {
                    _maingamechecker.image5[i].color = Color.green;
                    _maingamechecker.jaldi5++;
                }
            }

            for (int i = 0; i < 27; i++)
            {
                if (k.ToString() == _maingamechecker.Ticket6[i].text && _maingamechecker.image6[i].color != Color.green)
                {
                    _maingamechecker.image6[i].color = Color.green;
                    _maingamechecker.jaldi6++;
                }
            }

            if ((_maingamechecker.jaldi1 == 5 || _maingamechecker.jaldi2 == 5 || _maingamechecker.jaldi3 == 5 || _maingamechecker.jaldi4 == 5 || _maingamechecker.jaldi5 == 5 || _maingamechecker.jaldi6 == 5) && _networkcheck.networkjaldi5 == false)
            {
                _networkcheck.networkjaldi5 = true;
                _networkcheck.CheckUpdateJaldi5();
                return;
            }
            if (_gamehandler.finalnumber == _networkcheck.latestnumber)
            {
                return;
            }
        }
    }
}
