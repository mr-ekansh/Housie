using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Messaging;
using UnityEngine;

public class Notifications : MonoBehaviour 
{

    void Start () 
    {
        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
    }

    public void OnTokenReceived (object sender, Firebase.Messaging.TokenReceivedEventArgs token) 
    {
    }
    public void OnMessageReceived (object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
    }

}