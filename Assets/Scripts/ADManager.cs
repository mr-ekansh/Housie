using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class ADManager : MonoBehaviour
{
    public GameObject[] rules;
    int j =0;
    int i = 0;
    public GameObject[] claimrewards;
    public Text pagenumber;
    private InterstitialPlaygame _playgame;
    private InterstitialPlaygame1 _playgame1;
    private InterstitialPlaygame2 _playgame2;
    private InterstitialPlaygame3 _playgame3;
    private InterstitialPlaygame4 _playgame4;
    private RewardedAD _rewarded;

    void Awake()
    {
        MobileAds.Initialize((initStatus) => { Debug.Log("ads Initialize success......................................."); });
    }

    void Start()
    {
        pagenumber.text = "Page 1"; 
        _playgame = GameObject.Find("InterstitialPlayGame").GetComponent<InterstitialPlaygame>();
        _playgame1 = GameObject.Find("InterstitialPlayGame1").GetComponent<InterstitialPlaygame1>();
        _playgame2 = GameObject.Find("InterstitialPlayGame2").GetComponent<InterstitialPlaygame2>();
        _playgame3 = GameObject.Find("InterstitialPlayGame3").GetComponent<InterstitialPlaygame3>();
        _playgame4 = GameObject.Find("InterstitialPlayGame4").GetComponent<InterstitialPlaygame4>();
        _rewarded = GameObject.Find("RewardedAd").GetComponent<RewardedAD>();
    }

    public void LoadRewardedAd()
    {
        _rewarded.LoadAD();
    }

    public void PlayAD()
    {
        _playgame4.ShowAD();
    }
    public void PlayADFullhouse()
    {
        _playgame.ShowAD();
    }
    public void PlayADClaimprize()
    {
        _playgame1.ShowAD();
    }
    public void PlayRewardedAd()
    {
        _rewarded.ShowAD();
    }
    public void PlayAdSettings()
    {
        _playgame2.ShowAD();
    }
    public void PlayAdStore()
    {
        _playgame3.ShowAD();
    }

    public void RightScroll()
    {
        if (i < 4)
        {
            rules[i+1].transform.position = new Vector3(rules[i].transform.position.x, rules[0].transform.position.y, 0);
            rules[i].transform.position = new Vector3(rules[i].transform.position.x + 5000, rules[0].transform.position.y, 0);
            i++;
        }
    }


    public void LeftScroll()
    {
        if(i>0)
        {
            rules[i-1].transform.position = new Vector3(rules[i].transform.position.x, rules[0].transform.position.y, 0);
            rules[i].transform.position = new Vector3(rules[i].transform.position.x + 5000, rules[0].transform.position.y, 0);
            i--;
        }
    }
    public void RightScrollreward()
    {
        if (j < 1)
        {
            claimrewards[j+1].transform.position = new Vector3(claimrewards[j].transform.position.x, claimrewards[0].transform.position.y, 0);
            claimrewards[j].transform.position = new Vector3(claimrewards[j].transform.position.x + 5000, claimrewards[0].transform.position.y, 0);
            j++;
            pagenumber.text = "Page 2";
        }
    }


    public void LeftScrollreward()
    {
        if(j>0)
        {
            claimrewards[j-1].transform.position = new Vector3(claimrewards[j].transform.position.x, claimrewards[0].transform.position.y, 0);
            claimrewards[j].transform.position = new Vector3(claimrewards[j].transform.position.x + 5000, claimrewards[0].transform.position.y, 0);
            j--;
            pagenumber.text = "Page 1";
        }
    }
}
