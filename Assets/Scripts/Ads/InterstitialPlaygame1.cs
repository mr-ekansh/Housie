using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstitialPlaygame1 : MonoBehaviour
{
    private InterstitialAd interstitial;

    void Start()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-7793518066908406/3469012424";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-7793518066908406/3469012424";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void ShowAD()
    {
        if (this.interstitial.IsLoaded()) 
        {
            this.interstitial.Show();
        }
    }
}
