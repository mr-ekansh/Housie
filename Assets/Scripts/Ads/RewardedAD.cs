using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class RewardedAD : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private MainMenuManager _manager;
    void Start()
    {
        _manager = GameObject.FindWithTag("MainMenuManager").GetComponent<MainMenuManager>();
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-7793518066908406/9949029988";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-7793518066908406/9949029988";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);   
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void LoadAD()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-7793518066908406/9949029988";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-7793518066908406/9949029988";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void ShowAD()
    {
        if (this.rewardedAd.IsLoaded()) 
        {
            this.rewardedAd.Show();
        }
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        _manager.Reward();
    }
    
}
