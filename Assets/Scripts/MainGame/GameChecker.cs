using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameChecker : MonoBehaviour
{
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
    public bool IsEarly5 = false;
    public bool IsTopLine = false;
    public bool IsBottomLine = false;
    public bool IsMiddleLine = false;
    public bool IsFullHouse = false;
    public int jaldi1 = 0;
    public int jaldi2 = 0;
    public int jaldi3 = 0;
    public int jaldi4 = 0;
    public int jaldi5 = 0;
    public int jaldi6 = 0;
    public int topline1 = 0;
    public int midline1 = 0;
    public int bottomline1 = 0;
    public int topline2 = 0;
    public int midline2 = 0;
    public int bottomline2 = 0;
    public int topline3 = 0;
    public int midline3 = 0;
    public int bottomline3 = 0;
    public int topline4 = 0;
    public int midline4 = 0;
    public int bottomline4 = 0;
    public int topline5 = 0;
    public int midline5 = 0;
    public int bottomline5 = 0;
    public int topline6 = 0;
    public int midline6 = 0;
    public int bottomline6 = 0;
    public Animation _coinmove;
    public Animator _anim;
    public Transform coin;
    public Text _coinText;
    private NakamaTest _nakama;

    void Start()
    {
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _gamehandler = GameObject.FindWithTag("GameHandling").GetComponent<GameCall>();
        _networkcheck = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
    }

    public IEnumerator GameCheck()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            _nakama.StartLootroomGame();
            if (_networkcheck.checkingnumber == false)
            {
                _gamehandler.Numbercall();
                _anim.enabled = true;
                _coinmove.Play();
                _coinText.text = "";
            }
            else
            {
                _networkcheck.checkingnumber = false;
            }
            yield return new WaitForSeconds(3);
            int k = _gamehandler.finalnumber;

            if (IsTopLine == false)
            {
                if (topline1 == 5 || topline2 == 5 || topline3 == 5 || topline4 == 5 || topline5 == 5 || topline6 == 5)
                {
                    if (_networkcheck.networktopline == false)
                    {
                        StartCoroutine(_networkcheck.checktopline());
                        IsTopLine = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsTopLine = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }


            if (IsMiddleLine == false)
            {
                if (midline1 == 5 || midline2 == 5 || midline3 == 5 || midline4 == 5 || midline5 == 5 || midline6 == 5)
                {
                    if (_networkcheck.networkmiddleline == false)
                    {
                        StartCoroutine(_networkcheck.checkmiddleline());
                        IsMiddleLine = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsMiddleLine = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }

            if (IsBottomLine == false)
            {
                if (bottomline1 == 5 || bottomline2 == 5 || bottomline3 == 5 || bottomline4 == 5 || bottomline5 == 5 || bottomline6 == 5)
                {
                    if (_networkcheck.networkbottomline == false)
                    {
                        StartCoroutine(_networkcheck.checkbottomline());
                        IsBottomLine = true;
                        yield return new WaitForSeconds(2);
                        _anim.enabled = false;
                        _coinText.text = k.ToString();
                        coin.rotation = Quaternion.Euler(0,0,0);
                    }
                    else
                    {
                        IsBottomLine = true;
                        yield return new WaitForSeconds(2);
                        _anim.enabled = false;
                        _coinText.text = k.ToString();
                        coin.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                    _anim.enabled = false;
                    _coinText.text = k.ToString();
                    coin.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
                _anim.enabled = false;
                _coinText.text = k.ToString();
                coin.rotation = Quaternion.Euler(0, 0, 0);
            }
            
            if (IsFullHouse == false)
            {
                if (jaldi1 == 15 || jaldi2 == 15 || jaldi3 == 15 || jaldi4 == 15 || jaldi5 == 15 || jaldi6 == 15)
                {
                    if (_networkcheck.networkfullhouse == false)
                    {
                        StartCoroutine(_networkcheck.checkfullhouse());
                        IsFullHouse = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsFullHouse = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }

            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket1[i].text && image1[i].color != Color.green)
                {   
                    image1[i].color = Color.green;
                    if((i==0||i==3||i==6||i==9||i==12||i==15||i==18||i==21||i==24) && topline1<5)
                    {
                        topline1++;
                    }
                    else if((i==1||i==4||i==7||i==10||i==13||i==16||i==19||i==22||i==25) && midline1<5)
                    {
                        midline1++;
                    }
                    else if((i==2||i==5||i==8||i==11||i==14||i==17||i==20||i==23||i==26) && bottomline1<5)
                    {
                        bottomline1++;
                    }
                    jaldi1++;
                }
            }

            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket2[i].text && image2[i].color != Color.green)
                {   
                    image2[i].color = Color.green;
                    if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && topline2 < 5)
                    {
                        topline2++;
                    }
                    else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && midline2 < 5)
                    {
                        midline2++;
                    }
                    else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && bottomline2 < 5)
                    {
                        bottomline2++;
                    }
                    jaldi2++;
                }
            }

            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket3[i].text && image3[i].color != Color.green)
                {   
                    image3[i].color = Color.green;
                    if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && topline3 < 5)
                    {
                        topline3++;
                    }
                    else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && midline3 < 5)
                    {
                        midline3++;
                    }
                    else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && bottomline3 < 5)
                    {
                        bottomline3++;
                    }
                    jaldi3++;
                }
            }
            
            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket4[i].text && image4[i].color != Color.green)
                {   
                    image4[i].color = Color.green;
                    if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && topline4 < 5)
                    {
                        topline4++;
                    }
                    else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && midline4 < 5)
                    {
                        midline4++;
                    }
                    else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && bottomline4 < 5)
                    {
                        bottomline4++;
                    }
                    jaldi4++;
                }
            }
            
            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket5[i].text && image5[i].color != Color.green)
                {    
                    image5[i].color = Color.green;
                    if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && topline5 < 5)
                    {
                        topline5++;
                    }
                    else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && midline5 < 5)
                    {
                        midline5++;
                    }
                    else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && bottomline5 < 5)
                    {
                        bottomline5++;
                    }
                    jaldi5++;
                }
            }
            
            for (int i=0; i<27; i++)
            {
                if(k.ToString()==Ticket6[i].text && image6[i].color != Color.green)
                {
                    image6[i].color = Color.green;
                    if ((i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18 || i == 21 || i == 24) && topline6 < 5)
                    {
                        topline6++;
                    }
                    else if ((i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19 || i == 22 || i == 25) && midline6 < 5)
                    {
                        midline6++;
                    }
                    else if ((i == 2 || i == 5 || i == 8 || i == 11 || i == 14 || i == 17 || i == 20 || i == 23 || i == 26) && bottomline6 < 5)
                    {
                        bottomline6++;
                    }
                    jaldi6++;
                }
            }
            if (IsEarly5 == false)
            {
                if (jaldi1 == 5 || jaldi2 == 5 || jaldi3 == 5 || jaldi4 == 5 || jaldi5 == 5 || jaldi6 == 5)
                {
                    if(_networkcheck.networkjaldi5 == false)
                    {
                        StartCoroutine(_networkcheck.checkjaldi5());
                        IsEarly5 = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsEarly5 = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }


            if (IsTopLine == false)
            {
                if(topline1 == 5 || topline2 ==5 || topline3 == 5 || topline4 == 5 || topline5 == 5 || topline6 == 5)
                {
                    if (_networkcheck.networktopline == false)
                    {
                        StartCoroutine(_networkcheck.checktopline());
                        IsTopLine = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsTopLine = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }

            if (IsMiddleLine == false)
            {
                if(midline1 == 5 || midline2 ==5 || midline3 == 5 || midline4 == 5 || midline5 == 5 || midline6 == 5)
                {
                    if (_networkcheck.networkmiddleline == false)
                    {
                        StartCoroutine(_networkcheck.checkmiddleline());
                        IsMiddleLine = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsMiddleLine = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }

            if (IsBottomLine == false)
            {
                if(bottomline1 == 5 || bottomline2 ==5 || bottomline3 == 5 || bottomline4 == 5 || bottomline5 == 5 || bottomline6 == 5)
                {
                    if (_networkcheck.networkbottomline == false)
                    {
                        StartCoroutine(_networkcheck.checkbottomline());
                        IsBottomLine = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsBottomLine = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }

            if (IsFullHouse == false)
            {
                if (jaldi1 == 15 || jaldi2 == 15 || jaldi3 == 15 || jaldi4 == 15 || jaldi5 == 15 || jaldi6 == 15)
                {
                    if (_networkcheck.networkfullhouse == false)
                    {
                        StartCoroutine(_networkcheck.checkfullhouse());
                        IsFullHouse = true;
                        yield return new WaitForSeconds(2);
                    }
                    else
                    {
                        IsFullHouse = true;
                        yield return new WaitForSeconds(2);
                    }
                }
                else
                {
                    yield return new WaitForSeconds(2);
                }
            }
            else
            {
                yield return new WaitForSeconds(2);
            }
        }
    }
}
