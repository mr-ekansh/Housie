using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Text;
using Facebook.Unity;
using UnityEngine.UI;
using UnityEngine.Networking;
using Nakama;
using UnityEngine.SceneManagement;

public class GoogleFacebookLogin : MonoBehaviour
{
    private string Scheme = "http";

    private string Host = "34.122.88.220";

    private int Port = 7350;

    private string ServerKey = "defaultkey";

    private IClient client;

    private ISession session;

    private ISocket Socket;

    private string token = "";

    private NakamaTest _nakama;

    public GameObject unabletoconnect;

    public GameObject connectingPanel;

    void Start()
    {
        connectingPanel.SetActive(false);
        unabletoconnect.SetActive(false);
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
    }
    public async void GoogleLoginButton()
    {
        connectingPanel.SetActive(true);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesClientConfiguration ClientConfiguration =
        new PlayGamesClientConfiguration.Builder()
        .RequestEmail()
        .RequestServerAuthCode(false)
        .RequestIdToken()
        .Build();
        GooglePlayGames.PlayGamesPlatform.InitializeInstance(ClientConfiguration);
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                token = PlayGamesPlatform.Instance.GetIdToken();
                _nakama.email =  ((PlayGamesLocalUser)Social.localUser).Email;
                _nakama.GoogleNakama(token);
                connectingPanel.SetActive(false);
            }
            else
            {
                connectingPanel.SetActive(false);
                unabletoconnect.SetActive(true);
            }
        });
    }

    public void unableok()
    {
        unabletoconnect.SetActive(false);
    }

    public void FacebookLoginButton()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
        var permissions = new List<string>() { "public_profile", "email", "user_friends" };
        FB.LogInWithReadPermissions(permissions);
        FetchFBProfile();
        FBNakama();
    }
    public void OnLogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
    }
    private void FetchFBProfile()
    {
        FB.API("/me?fields=first_name,last_name,email", HttpMethod.GET, FetchProfileCallback, new Dictionary<string, string>() { });
    }

    private void FetchProfileCallback(IGraphResult result)
    {
        var FBUserDetails = (Dictionary<string, object>)result.ResultDictionary;
    }

    private async void FBNakama()
    {
    }
}
