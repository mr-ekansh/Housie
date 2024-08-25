using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Nakama;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class NakamaTest : MonoBehaviour
{
    private string Scheme = "http";

    private string Host = "34.121.136.31";

    private int Port = 7350;

    private string ServerKey = "defaultkey";

    private IClient Client;

    private ISession Session;

    private ISocket Socket;
    private IUserPresence localUser;
    private GameObject localPlayer;
    private IMatch currentmatch;

    private const string SessionPrefName = "nakama.session";
    private const string DeviceIdentifierPrefName = "nakama.deviceUniqueIdentifier";

    public GameObject _maingamePanel;

    public GameObject _freeroomPanel;

    private Image _player;

    private GameChecker _gamechecker;
    
    private GameCheckerJaldi5 _gamecheckerjaldi5;

    public string USERID = "";

    private string mymatchid;

    public string freematchid = "";

    public GameObject[] _Spotitems;
    
    public GameObject[] _freeroomSpotitems;

    private SpotChecker _spotchecker;
    
    private SpotCheckerfreeroom _spotcheckerfreeroom;
    
    public GameObject[] _toplineSpotitems;

    private toplineSpotChecker _toplinespotchecker;
    
    public GameObject[] _middlelineSpotitems;

    private middlelineSpotChecker _middlelinespotchecker;
    
    public GameObject[] _bottomlineSpotitems;

    private bottomlineSpotChecker _bottomlinespotchecker;
    
    public GameObject[] _fullhouseSpotitems;

    private fullhouseSpotChecker _fullhousespotchecker;

    private TicketBackend _ticketbackend;
    
    private TicketBackendJaldi5 _ticketbackendfreeroom;

    private NetworkGameCheck _networkgame;
    
    private NetworkGameCheckJaldi5 _networkgamejaldi5;

    int jaldi5Opcode = 2134;
    int toplineOpcode = 8927;
    int middlelineOpcode = 2848;
    int bottomlineOpcode = 4582;
    int fullhouseOpcode = 8195;
    int jaldi5Opcodefreeroom = 548515;
    int gamestartOpcode = 844816;
    int jaldi5gamestartOpcode = 24862;
    int jaldi5SpotOpcode = 63257;
    int toplineSpotOpcode = 54121;
    int middlelineSpotOpcode = 89216;
    int bottomlineSpotOpcode = 76124;
    int fullhouseSpotOpcode = 5156;
    int jaldi5SpotOpcodefreeroom = 23165;
    int SpotCheckOpcodefreeroom = 847851;
    int SpotCheckJaldi5Opcode = 54562;
    int SpotCheckToplineOpcode = 56455;
    int SpotCheckMiddlelineOpcode = 59812;
    int SpotCheckBottomlineOpcode = 9849;
    int SpotCheckFullhouseOpcode = 84562;

    bool sock = true;

    public GameObject _jaldi5Text; 
    public GameObject _toplineText; 
    public GameObject _middlelineText; 
    public GameObject _bottomlineText; 
    public GameObject _fullhouseText; 
    public GameObject _endgameButton;
    public GameObject _ClaimPrizeButton;
    public GameObject _freeroomendgameButton;
    public GameObject _reconnectText;
    public GameObject _LoginPanel;

    Coroutine spotcall;
    Coroutine toplinespotcall;
    Coroutine middlelinespotcall;
    Coroutine bottomlinespotcall;
    Coroutine fullhousespotcall;
    public Coroutine maingamechecker;
    string finalgamecheck = "";
    private bool jaldi5started = false;
    private bool toplinestarted = false;
    private bool middlelinestarted = false;
    private bool bottomlinestarted = false;
    private bool fullhousestarted = false;
    private MainMenuManager _mainmanager;
    public GameObject InGameText;
    public GameObject WinnerPanel;
    public GameObject FreeRoomText;
    public GameObject WinnerPanelfreeroom;
    private bool gamerunning = false;
    public Text Jaldi5Winner;
    public Text Winnerfreeroom;
    public Text ToplineWinner;
    public Text MiddlelineWinner;
    public Text BottomlineWinner;
    public Text FullhouseWinner;
    public GameObject[] GameHandlingOptions;
    private bool matchrunning;
    private SpotCallingfreeroom _spotcall;
    private ADManager _adsmanager;
    public Text winLoosetext;
    public Animation _winloose;
    public Text winLoosetextfreeroom;
    public Animation _winloosefreeroom;
    public GameObject _winloosefree;
    public GameObject _winloosemain;
    public AudioSource _audio;
    public AudioClip _clip;
    public GameObject ManagerGame;
    private bool gamewin = false;
    public string email = "";
    private GameUpdation _gameupdate;
    private bool jaldi5playerwin = false;
    private bool toplineplayerwin = false;
    private bool middlelineplayerwin = false;
    private bool bottomlineplayerwin = false;
    private bool fullhouseplayerwin = false;
    private bool freeroomplayerwin = false;
    private bool updationrunning = true;
    private UpdateStatus _updatestatus;
    private bool spotstop = false;
    public AudioSource _source;
    public int jaldi5prize;
    public int lineprize;
    public int houseprize;
    Coroutine usersjaldi5;
    Coroutine userstopline;
    Coroutine usersmiddleline;
    Coroutine usersbottomline;
    Coroutine usersfullhouse;
    private fetchwinnersJaldi5 fetchjaldi5wins;
    private fetchwinnersTopline fetchtoplinewins;
    private fetchwinnersMiddleline fetchmiddlelinewins;
    private fetchwinnersBottomline fetchbottomlinewins;
    private fetchwinnersFullhouse fetchfullhousewins;
    public bool isvoucher;
    private int winneralert;


    void Awake()
    {
        Caching.ClearCache();
    }
    async void Start()
    {
        winneralert = 0;
        isvoucher = false;
        updationrunning = true;
        _winloosefree.SetActive(false);
        _winloosemain.SetActive(false);
        _adsmanager = GameObject.FindWithTag("MainMenuManager").GetComponent<ADManager>();
        matchrunning = false; 
        _mainmanager = GameObject.FindWithTag("MainMenuManager").GetComponent< MainMenuManager>();
        _updatestatus = GameObject.FindWithTag("MainMenuManager").GetComponent< UpdateStatus>();
        _LoginPanel.SetActive(true);
        _reconnectText.SetActive(false);
        _maingamePanel.SetActive(false);
        _freeroomPanel.SetActive(false);
        Client = new Nakama.Client(Scheme, Host, Port, ServerKey, UnityWebRequestAdapter.Instance);
        Socket = Client.NewSocket();
        var authToken = PlayerPrefs.GetString(SessionPrefName);
        if (!string.IsNullOrEmpty(authToken))
        {
            var session = Nakama.Session.Restore(authToken);
            if (!session.IsExpired)
            {
                Session = session;
                await Socket.ConnectAsync(Session, true);
                _LoginPanel.SetActive(false);
                var account = await Client.GetAccountAsync(Session);
                var user = account.User;
                USERID = user.GoogleId;
                PlayerPrefs.SetString("NakamaUserid", USERID);
                StartCoroutine(_updatestatus.CheckForUpdate());
                StartCoroutine(GetUserID(user.GoogleId));
                StartCoroutine(_mainmanager.ExtractCoins(USERID));
                StartCoroutine(_mainmanager.ExtractRubies(USERID));
                StartCoroutine(_mainmanager.ExtractGems(USERID));
                StartCoroutine(_mainmanager.ExtractTicketStatus(USERID));
                StartCoroutine(_mainmanager.ExtractTicketStatusvoucher(USERID));
                StartCoroutine(_mainmanager.ExtractDisplayName(USERID));
                StartCoroutine(_mainmanager.ExtractAdlimit(USERID));
            }
        }
        Socket.ReceivedMatchState += OnReceivedmatchState;
        _freeroomSpotitems[0].SetActive(false);
        _freeroomSpotitems[1].SetActive(false);
        _freeroomSpotitems[2].SetActive(false);
        _Spotitems[0].SetActive(false);
        _Spotitems[1].SetActive(false);
        _Spotitems[2].SetActive(false);
        _toplineSpotitems[0].SetActive(false);
        _toplineSpotitems[1].SetActive(false);
        _toplineSpotitems[2].SetActive(false);
        _middlelineSpotitems[0].SetActive(false);
        _middlelineSpotitems[1].SetActive(false);
        _middlelineSpotitems[2].SetActive(false);
        _bottomlineSpotitems[0].SetActive(false);
        _bottomlineSpotitems[1].SetActive(false);
        _bottomlineSpotitems[2].SetActive(false);
        _fullhouseSpotitems[0].SetActive(false);
        _fullhouseSpotitems[1].SetActive(false);
        _fullhouseSpotitems[2].SetActive(false);
        _jaldi5Text.SetActive(false);
        _toplineText.SetActive(false);
        _middlelineText.SetActive(false);
        _bottomlineText.SetActive(false);
        _fullhouseText.SetActive(false);
        _endgameButton.SetActive(false);
        _ClaimPrizeButton.SetActive(false);
        _freeroomendgameButton.SetActive(false);
    }

    public async void AuthenticateWithDevice()
    {
        var deviceId = PlayerPrefs.GetString("deviceId", SystemInfo.deviceUniqueIdentifier);

        if (deviceId == SystemInfo.unsupportedIdentifier)
        {
            deviceId = System.Guid.NewGuid().ToString();
        }

        PlayerPrefs.SetString("deviceId", deviceId);

        try
        {
            Session = await Client.AuthenticateDeviceAsync(deviceId);
            Debug.Log("Authenticated with Device ID");
            await Socket.ConnectAsync(Session, true);
            _LoginPanel.SetActive(false);
            USERID = deviceId;
            StartCoroutine(_updatestatus.CheckForUpdate());
            StartCoroutine(GetUserID(deviceId));
            StartCoroutine(_mainmanager.ExtractCoins(USERID));
            StartCoroutine(_mainmanager.ExtractRubies(USERID));
            StartCoroutine(_mainmanager.ExtractGems(USERID));
            StartCoroutine(_mainmanager.ExtractTicketStatus(USERID));
            StartCoroutine(_mainmanager.ExtractTicketStatusvoucher(USERID));
            StartCoroutine(_mainmanager.ExtractDisplayName(USERID));
            StartCoroutine(_mainmanager.ExtractAdlimit(USERID));

        }
        catch(ApiResponseException ex)
        {
            Debug.LogFormat("Error authenticating with Device ID: {0}", ex.Message);
        }
    }

    public async void GoogleNakama(string playerid)
    {
        Session = await Client.AuthenticateGoogleAsync(playerid);
        await Socket.ConnectAsync(Session, true);
        _LoginPanel.SetActive(false);
        var account = await Client.GetAccountAsync(Session);
        var user = account.User;
        StartCoroutine(GetUserID(user.GoogleId));
        StartCoroutine(RegisterEmail(email, user.GoogleId));
        USERID = user.GoogleId;
        PlayerPrefs.SetString("NakamaUserid", USERID);
        PlayerPrefs.SetString(SessionPrefName, Session.AuthToken); 
        StartCoroutine(_updatestatus.CheckForUpdate());
        StartCoroutine(_mainmanager.ExtractCoins(USERID));
        StartCoroutine(_mainmanager.ExtractRubies(USERID));
        StartCoroutine(_mainmanager.ExtractGems(USERID));
        StartCoroutine(_mainmanager.ExtractTicketStatus(USERID));
        StartCoroutine(_mainmanager.ExtractTicketStatusvoucher(USERID));
        StartCoroutine(_mainmanager.ExtractDisplayName(USERID));
        StartCoroutine(_mainmanager.ExtractAdlimit(USERID));
    }

    public async void JoinMatch(string newmatch)
    {
        var matchId = newmatch;
        var match = await Socket.JoinMatchAsync(matchId);
        foreach (var presence in match.Presences)
        {
            _maingamePanel.SetActive(true);
            WinnerPanel.SetActive(false);
            InGameText.SetActive(true);
            _player = GameObject.FindWithTag("Player").GetComponent<Image>();
            _audio.Stop();
            mymatchid = match.Id;
            if(presence.UserId == match.Self.UserId)
            {
                matchrunning  = false;
                _player.raycastTarget = true;
                _adsmanager.PlayAD();
                _source.Play();
                StartCoroutine(RecieveWinnerName("Jaldi5"));
                StartCoroutine(RecieveWinnerName("Topline"));
                StartCoroutine(RecieveWinnerName("Middleline"));
                StartCoroutine(RecieveWinnerName("Bottomline"));
                StartCoroutine(RecieveWinnerName("Fullhouse"));
            }
            else
            {
                _player.raycastTarget = false;
            }
        }
    }


    public async void JoinMatchvoucher(string newmatch)
    {
        var matchId = newmatch;
        var match = await Socket.JoinMatchAsync(matchId);
        foreach (var presence in match.Presences)
        {
            _maingamePanel.SetActive(true);
            WinnerPanel.SetActive(false);
            InGameText.SetActive(true);
            _player = GameObject.FindWithTag("Player").GetComponent<Image>();
            _audio.Stop();
            mymatchid = match.Id;
            if(presence.UserId == match.Self.UserId)
            {
                isvoucher = true;
                matchrunning  = false;
                _player.raycastTarget = true;
                _adsmanager.PlayAD();
                _source.Play();
                StartCoroutine(RecieveWinnerName("Jaldi5"));
                StartCoroutine(RecieveWinnerName("Topline"));
                StartCoroutine(RecieveWinnerName("Middleline"));
                StartCoroutine(RecieveWinnerName("Bottomline"));
                StartCoroutine(RecieveWinnerName("Fullhouse"));
            }
            else
            {
                _player.raycastTarget = false;
            }
        }
    }

    public async void JoinFreeMatchJaldi5(string newmatch)
    {
        var matchId = newmatch;
        var match = await Socket.JoinMatchAsync(matchId);
        foreach (var presence in match.Presences)
        {
            _freeroomPanel.SetActive(true);
            _mainmanager.PlayerCount();
            WinnerPanelfreeroom.SetActive(false);
            FreeRoomText.SetActive(true);
            GameHandlingOptions[0].SetActive(true);
            _player = GameObject.FindWithTag("Player").GetComponent<Image>();
            freematchid = match.Id;
            _audio.Stop();
            if (presence.UserId == match.Self.UserId)
            {
                matchrunning  = false;
                _player.raycastTarget = true;
                _adsmanager.PlayAD();
            }
            else
            {
                _player.raycastTarget = false;
            }
            _audio.clip = _clip;
            _audio.Play();
        }
    }


    public async void GameStop()
    {
        StartCoroutine(ResetGameStatus());
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        StopCoroutine(maingamechecker);
        gamerunning = false;
        string latest = _networkgame.latestnumber.ToString();
        _Spotitems[0].SetActive(true);
        _Spotitems[1].SetActive(true);
        _Spotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractjaldiTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractjaldiTicket();
        }
        await Socket.SendMatchStateAsync(mymatchid,jaldi5Opcode,latest,null);
    }

    public IEnumerator Jaldi5SpotOpcode()
    {
        yield return new WaitForSeconds(10);
        Socket.SendMatchStateAsync(mymatchid, jaldi5SpotOpcode, "", null);
        yield return new WaitForSeconds(5f);
        StartCoroutine(Recievespotcheck("Jaldi5"));
        yield return new WaitForSeconds(200.0f);
        StartCoroutine(Recievespotendcheck("Jaldi5"));
    }

    public async void toplineGameStop()
    {
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        StopCoroutine(maingamechecker);
        gamerunning = false;
        string latest = _networkgame.latestnumber.ToString();
        _toplineSpotitems[0].SetActive(true);
        _toplineSpotitems[1].SetActive(true);
        _toplineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtracttoplineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtracttoplineTicket();
        }
        await Socket.SendMatchStateAsync(mymatchid,toplineOpcode, latest, null);
    }

    public IEnumerator ToplineSpotOpcode()
    {
        yield return new WaitForSeconds(10);
        Socket.SendMatchStateAsync(mymatchid, toplineSpotOpcode, "", null);
        yield return new WaitForSeconds(5f);
        StartCoroutine(Recievespotcheck("TopLine"));
        yield return new WaitForSeconds(200.0f);
        StartCoroutine(Recievespotendcheck("TopLine"));
    }

    public async void middlelineGameStop()
    {
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        StopCoroutine(maingamechecker);
        gamerunning = false;
        string latest = _networkgame.latestnumber.ToString();
        _middlelineSpotitems[0].SetActive(true);
        _middlelineSpotitems[1].SetActive(true);
        _middlelineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractmiddlelineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractmiddlelineTicket();
        }
        await Socket.SendMatchStateAsync(mymatchid,middlelineOpcode, latest, null);
    }

    public IEnumerator MiddlelineSpotOpcode()
    {
        yield return new WaitForSeconds(10);
        Socket.SendMatchStateAsync(mymatchid, middlelineSpotOpcode, "", null);
        yield return new WaitForSeconds(5f);
        StartCoroutine(Recievespotcheck("MiddleLine"));
        yield return new WaitForSeconds(200.0f);
        StartCoroutine(Recievespotendcheck("MiddleLine"));
    }

    public async void bottomlineGameStop()
    {
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        StopCoroutine(maingamechecker);
        gamerunning = false;
        string latest = _networkgame.latestnumber.ToString();
        _bottomlineSpotitems[0].SetActive(true);
        _bottomlineSpotitems[1].SetActive(true);
        _bottomlineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractbottomlineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractbottomlineTicket();
        }
        await Socket.SendMatchStateAsync(mymatchid,bottomlineOpcode, latest, null);
    }

    public IEnumerator BottomlineSpotOpcode()
    {
        yield return new WaitForSeconds(10);
        Socket.SendMatchStateAsync(mymatchid, bottomlineSpotOpcode, "", null);
        yield return new WaitForSeconds(5f);
        StartCoroutine(Recievespotcheck("BottomLine"));
        yield return new WaitForSeconds(200.0f);
        StartCoroutine(Recievespotendcheck("BottomLine"));
    }

    public async void fullhouseGameStop()
    {
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
        StopCoroutine(maingamechecker);
        gamerunning = false;
        string latest = _networkgame.latestnumber.ToString();
        _fullhouseSpotitems[0].SetActive(true);
        _fullhouseSpotitems[1].SetActive(true);
        _fullhouseSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractfullhouseTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractfullhouseTicket();
        }
        await Socket.SendMatchStateAsync(mymatchid,fullhouseOpcode,latest, null);
    }

    public IEnumerator FullhouseSpotOpcode()
    {
        yield return new WaitForSeconds(10);
        Socket.SendMatchStateAsync(mymatchid, fullhouseSpotOpcode, "", null);
        yield return new WaitForSeconds(5f);
        StartCoroutine(Recievespotcheck("FullHouse"));
        yield return new WaitForSeconds(200.0f);
        StartCoroutine(Recievespotendcheck("FullHouse"));
    }

    private IEnumerator Recievespotcheck(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        WWW download = new WWW("http://34.121.136.31/housiekings/Recievespotcheck.php", form);
        yield return download;
        if(download.text == "no" && name == "Jaldi5")
        {
            Socket.SendMatchStateAsync(mymatchid,2214,"", null); 
        }
        else if(download.text == "no" && name == "TopLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2215,"", null); 
        }
        else if(download.text == "no" && name == "MiddleLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2216,"", null); 
        }
        else if(download.text == "no" && name == "BottomLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2217,"", null); 
        }
        else if(download.text == "no" && name == "FullHouse")
        {
            Socket.SendMatchStateAsync(mymatchid,2218,"", null); 
        }
    }


    private IEnumerator Recievespotendcheck(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        WWW download = new WWW("http://34.121.136.31/housiekings/Recievespotendcheck.php", form);
        yield return download;
        if(download.text == "no" && name == "Jaldi5")
        {
            Socket.SendMatchStateAsync(mymatchid,2214,"", null); 
        }
        else if(download.text == "no" && name == "TopLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2215,"", null); 
        }
        else if(download.text == "no" && name == "MiddleLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2216,"", null); 
        }
        else if(download.text == "no" && name == "BottomLine")
        {
            Socket.SendMatchStateAsync(mymatchid,2217,"", null); 
        }
        else if(download.text == "no" && name == "FullHouse")
        {
            Socket.SendMatchStateAsync(mymatchid,2218,"", null); 
        }
    }

    private async void OnReceivedmatchState(IMatchState matchState)
    {
        if (matchState.OpCode == gamestartOpcode)
        {
            if(matchrunning == false)
            {
                if(isvoucher == true)
                {
                    StartCoroutine(ResetTicketStatusvoucher(USERID));
                }
                else
                {
                    StartCoroutine(ResetTicketStatus(USERID));
                }
                InGameText.SetActive(false);
                WinnerPanel.SetActive(true);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                gamerunning = true;
                _source.Stop();
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
            }
        }
        if (matchState.OpCode == jaldi5Opcode)
        {
            if(updationrunning == true)
            {
                StartCoroutine(ResetGameStatus());
                spotstop = false;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
                string jaldi5number = Encoding.UTF8.GetString(matchState.State);
                _networkgame.latestnumber = int.Parse(jaldi5number);
                _networkgame.checkingnumber = true;
                if (gamerunning == true)
                {
                    StopCoroutine(maingamechecker);
                }
                gamerunning = false;
                _Spotitems[0].SetActive(true);
                _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
                _gameupdate.GameUpdateJaldi5();
                _source.Play();
                updationrunning = false;
            }
        }
        
        if(matchState.OpCode == toplineOpcode)
        {
            if(updationrunning == true)
            {
                spotstop = false;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
                string toplinenumber = Encoding.UTF8.GetString(matchState.State);
                _networkgame.latestnumber = int.Parse(toplinenumber);
                _networkgame.checkingnumber = true;
                if (gamerunning == true)
                {
                    StopCoroutine(maingamechecker);
                }
                gamerunning = false;
                _toplineSpotitems[0].SetActive(true);
                _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
                _gameupdate.GameUpdateTopline();
                _source.Play();
                updationrunning = false;
            }
        }
        
        if(matchState.OpCode == middlelineOpcode)
        {
            if(updationrunning == true)
            {
                spotstop = false;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
                string middlelinenumber = Encoding.UTF8.GetString(matchState.State);
                _networkgame.latestnumber = int.Parse(middlelinenumber);
                _networkgame.checkingnumber = true;
                if (gamerunning == true)
                {
                    StopCoroutine(maingamechecker);
                }
                gamerunning = false;
                _middlelineSpotitems[0].SetActive(true);
                _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
                _gameupdate.GameUpdateMiddleline();
                _source.Play();
                updationrunning = false;
            }
        }
        
        if(matchState.OpCode == bottomlineOpcode)
        {
            if(updationrunning == true)
            {
                spotstop = false;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
                string bottomlinenumber = Encoding.UTF8.GetString(matchState.State);
                _networkgame.latestnumber = int.Parse(bottomlinenumber);
                _networkgame.checkingnumber = true;
                if (gamerunning == true)
                {
                    StopCoroutine(maingamechecker);
                }
                gamerunning = false;
                _bottomlineSpotitems[0].SetActive(true);
                _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
                _gameupdate.GameUpdateBottomline();
                _source.Play();
                updationrunning = false;
            }
        }
        
        if(matchState.OpCode == fullhouseOpcode)
        {
            if(updationrunning == true)
            {
                spotstop = false;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _networkgame = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheck>();
                string fullhousenumber = Encoding.UTF8.GetString(matchState.State);
                _networkgame.latestnumber = int.Parse(fullhousenumber);
                _networkgame.checkingnumber = true;
                if (gamerunning == true)
                {
                    StopCoroutine(maingamechecker);
                }
                gamerunning = false;
                _fullhouseSpotitems[0].SetActive(true);
                _gameupdate = GameObject.FindWithTag("GameChecking").GetComponent<GameUpdation>();
                _gameupdate.GameUpdateFullhouse();
                _source.Play();
                updationrunning = false;
            }
        }

        if(matchState.OpCode == 2214)
        {
            if(spotstop == false)
            {
                jaldi5started = false;
                updationrunning = true;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _Spotitems[0].SetActive(false);
                _Spotitems[1].SetActive(false);
                _Spotitems[2].SetActive(false);
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
                gamerunning = true;
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "Winner left the game !!";
                _winloose.Play();
                spotstop = true;
                _source.Stop();
            }
        }
        
        if(matchState.OpCode == 2215)
        {
            if(spotstop == false)
            {
                toplinestarted = false;
                updationrunning = true;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _toplineSpotitems[0].SetActive(false);
                _toplineSpotitems[1].SetActive(false);
                _toplineSpotitems[2].SetActive(false);
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
                gamerunning = true;
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "Winner left the game !!";
                _winloose.Play();
                spotstop = true;
                _source.Stop();
            }
        }
        
        if(matchState.OpCode == 2216)
        {
            if(spotstop == false)
            {
                middlelinestarted = false;
                updationrunning = true;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _middlelineSpotitems[0].SetActive(false);
                _middlelineSpotitems[1].SetActive(false);
                _middlelineSpotitems[2].SetActive(false);
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
                gamerunning = true;
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "Winner left the game !!";
                _winloose.Play();
                spotstop = true;
                _source.Stop();
            }
        }
        
        if(matchState.OpCode == 2217)
        {
            if(spotstop == false)
            {
                bottomlinestarted = false;
                updationrunning = true;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _bottomlineSpotitems[0].SetActive(false);
                _bottomlineSpotitems[1].SetActive(false);
                _bottomlineSpotitems[2].SetActive(false);
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
                gamerunning = true;
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "Winner left the game !!";
                _winloose.Play();
                spotstop = true;
                _source.Stop();
            }
        }
        
        if(matchState.OpCode == 2218)
        {
            if(spotstop == false)
            {
                fullhousestarted = false;
                updationrunning = true;
                WinnerPanel.SetActive(true);
                InGameText.SetActive(false);
                _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
                _fullhouseSpotitems[0].SetActive(false);
                _fullhouseSpotitems[1].SetActive(false);
                _fullhouseSpotitems[2].SetActive(false);
                maingamechecker = StartCoroutine(_gamechecker.GameCheck());
                matchrunning = true;
                gamerunning = true;
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "Winner left the game !!";
                _winloose.Play();
                spotstop = true;
                _source.Stop();
            }
        }
        
        if((matchState.OpCode == 3214))
        {
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
            _Spotitems[0].SetActive(false);
            maingamechecker = StartCoroutine(_gamechecker.GameCheck());
            matchrunning = true;
            _jaldi5Text.SetActive(true);
            gamerunning = true;
            if(jaldi5playerwin == false)
            {
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "You lost Jaldi5 !!";
                _winloose.Play();
            }
            StartCoroutine(RecieveWinnerName("Jaldi5"));
            updationrunning = true;
            _source.Stop();
        }
        
        if((matchState.OpCode == 3215))
        {
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
            _toplineSpotitems[0].SetActive(false);
            maingamechecker = StartCoroutine(_gamechecker.GameCheck());
            matchrunning = true;
            gamerunning = true;
            if(toplineplayerwin == false)
            {
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "You lost Topline !!";
                _winloose.Play();
            }
            _toplineText.SetActive(true);
            StartCoroutine(RecieveWinnerName("Topline"));
            updationrunning = true;
            _source.Stop();
        }
        
        if((matchState.OpCode == 3216))
        {
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
            _middlelineSpotitems[0].SetActive(false);
            maingamechecker = StartCoroutine(_gamechecker.GameCheck());
            matchrunning = true;
            gamerunning = true;
            if(middlelineplayerwin == false)
            {
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "You lost Middleline !!";
                _winloose.Play();
            }
            _middlelineText.SetActive(true);
            StartCoroutine(RecieveWinnerName("Middleline"));
            updationrunning = true;
            _source.Stop();
        }
        
        if((matchState.OpCode == 3217))
        {
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
            _bottomlineSpotitems[0].SetActive(false);
            maingamechecker = StartCoroutine(_gamechecker.GameCheck());
            matchrunning = true;
            gamerunning = true;
            if(bottomlineplayerwin == false)
            {
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "You lost Bottomline !!";
                _winloose.Play();
            }
            _bottomlineText.SetActive(true);
            StartCoroutine(RecieveWinnerName("Bottomline"));
            updationrunning = true;
            _source.Stop();
        }
        
        if((matchState.OpCode == 3218))
        {
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            _fullhouseSpotitems[0].SetActive(false);
            _fullhouseText.SetActive(true);
            gamerunning = true;
            if(fullhouseplayerwin == false)
            {
                _winloosemain.SetActive(false);
                _winloosemain.SetActive(true);
                winLoosetext.text = "You lost Fullhouse !!";
                _winloose.Play();
            }
            if(isvoucher == true && winneralert ==1)
            {
                _ClaimPrizeButton.SetActive(true);
            }
            else
            {
                _endgameButton.SetActive(true);
            }
            StartCoroutine(RecieveWinnerName("Fullhouse"));
            updationrunning = true;
        }

        if(matchState.OpCode == jaldi5SpotOpcode)
        {
            if(_Spotitems[1].activeSelf && _Spotitems[2].activeSelf)
            {
                fetchjaldi5wins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersJaldi5>();
                usersjaldi5 = StartCoroutine(fetchjaldi5wins.fetchwinners());
                if (jaldi5started == false)
                {
                    _spotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<SpotChecker>();
                    spotcall = StartCoroutine(_spotchecker.checkSpot());
                    usersjaldi5 = StartCoroutine(fetchjaldi5wins.fetchwinners());
                    jaldi5started = true;
                }
            }
        }
        
        if(matchState.OpCode == toplineSpotOpcode)
        {
            fetchtoplinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersTopline>();
            userstopline = StartCoroutine(fetchtoplinewins.fetchwinners());
            if(_toplineSpotitems[1].activeSelf && _toplineSpotitems[2].activeSelf)
            {
                if (toplinestarted == false)
                {
                    _toplinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<toplineSpotChecker>();
                    toplinespotcall = StartCoroutine(_toplinespotchecker.checkSpot());
                    toplinestarted = true;
                }
            }
        }
        
        if(matchState.OpCode == middlelineSpotOpcode)
        {
            fetchmiddlelinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersMiddleline>();
            usersmiddleline = StartCoroutine(fetchmiddlelinewins.fetchwinners());
            if(_middlelineSpotitems[1].activeSelf && _middlelineSpotitems[2].activeSelf)
            {
                if (middlelinestarted == false)
                {
                    _middlelinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<middlelineSpotChecker>();
                    middlelinespotcall = StartCoroutine(_middlelinespotchecker.checkSpot());
                    middlelinestarted = true;
                }
            }
        }

        if(matchState.OpCode == bottomlineSpotOpcode)
        {
            fetchbottomlinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersBottomline>();
            usersbottomline = StartCoroutine(fetchbottomlinewins.fetchwinners());
            if(_bottomlineSpotitems[1].activeSelf && _bottomlineSpotitems[2].activeSelf)
            {
                if (bottomlinestarted == false)
                {
                    _bottomlinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<bottomlineSpotChecker>();
                    bottomlinespotcall = StartCoroutine(_bottomlinespotchecker.checkSpot());
                    bottomlinestarted = true;
                }
            }
        }

        if (matchState.OpCode == fullhouseSpotOpcode)
        {
            fetchfullhousewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersFullhouse>();
            usersfullhouse = StartCoroutine(fetchfullhousewins.fetchwinners());
            if(_fullhouseSpotitems[1].activeSelf && _fullhouseSpotitems[2].activeSelf)
            {
                if (fullhousestarted == false)
                {
                    _fullhousespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<fullhouseSpotChecker>();
                    fullhousespotcall = StartCoroutine(_fullhousespotchecker.checkSpot());
                    fullhousestarted = true;
                }
            }
        }

        if (matchState.OpCode == SpotCheckJaldi5Opcode)
        {
            fetchjaldi5wins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersJaldi5>();
            StopCoroutine(usersjaldi5);
            _spotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<SpotChecker>();
            if(_spotchecker.checkspotno == "no")
            {
                StopCoroutine(spotcall);
                SpotLooser();
            }
        }

        if (matchState.OpCode == SpotCheckToplineOpcode)
        {
            fetchtoplinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersTopline>();
            StopCoroutine(userstopline);
            _toplinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<toplineSpotChecker>();
            if(_toplinespotchecker.checkspotno == "no")
            {
                StopCoroutine(toplinespotcall);
                toplineSpotLooser();
            }
        }

        if (matchState.OpCode == SpotCheckMiddlelineOpcode)
        {
            fetchmiddlelinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersMiddleline>();
            StopCoroutine(usersmiddleline);
            _middlelinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<middlelineSpotChecker>();
            if(_middlelinespotchecker.checkspotno == "no")
            {
                StopCoroutine(middlelinespotcall);
                middlelineSpotLooser();
            }
        }

        if (matchState.OpCode == SpotCheckBottomlineOpcode)
        {
            fetchbottomlinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersBottomline>();
            StopCoroutine(usersbottomline);
            _bottomlinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<bottomlineSpotChecker>();
            if(_bottomlinespotchecker.checkspotno == "no")
            {
                StopCoroutine(bottomlinespotcall);
                bottomlineSpotLooser();
            }
        }

        if (matchState.OpCode == SpotCheckFullhouseOpcode)
        {
            fetchfullhousewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersFullhouse>();
            StopCoroutine(usersfullhouse);
            _fullhousespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<fullhouseSpotChecker>();
            if(_fullhousespotchecker.checkspotno == "no")
            {
                StopCoroutine(fullhousespotcall);
                fullhouseSpotLooser();
            }
        }

        //freeroom opcodes


        if (matchState.OpCode == jaldi5gamestartOpcode && _mainmanager.roomname.text == "Jaldi5")
        {
            if (matchrunning == false)
            {
                StartCoroutine(FreeroomStartgame(freematchid));
                FreeRoomText.SetActive(false);
                WinnerPanelfreeroom.SetActive(true);
                _gamecheckerjaldi5 = GameObject.FindWithTag("GameChecking").GetComponent<GameCheckerJaldi5>();
                gamerunning = true;
                maingamechecker = StartCoroutine(_gamecheckerjaldi5.GameCheck());
                matchrunning = true;
            }
        }

        if (matchState.OpCode == jaldi5Opcodefreeroom)
        {
            WinnerPanelfreeroom.SetActive(true);
            FreeRoomText.SetActive(false);
            _gamecheckerjaldi5 = GameObject.FindWithTag("GameChecking").GetComponent<GameCheckerJaldi5>();
            _networkgamejaldi5 = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheckJaldi5>();
            string numberjaldi5 = Encoding.UTF8.GetString(matchState.State);
            _networkgamejaldi5.latestnumber = int.Parse(numberjaldi5);
            _networkgamejaldi5.checkingnumber = true;
            if (gamerunning == true)
            {
                StopCoroutine(maingamechecker);
            }
            gamerunning = true;
            _freeroomSpotitems[0].SetActive(true);
            _networkgamejaldi5.GetLatestNumber();
        }

        if (matchState.OpCode == jaldi5SpotOpcodefreeroom)
        {
            if (_freeroomSpotitems[1].activeSelf && _freeroomSpotitems[2].activeSelf)
            {
                if (jaldi5started == false)
                {
                    jaldi5started = true;
                    _spotcheckerfreeroom = GameObject.FindWithTag("SpotCheck").GetComponent<SpotCheckerfreeroom>();
                    spotcall = StartCoroutine(_spotcheckerfreeroom.checkSpot());
                }
            }
        }

        if (matchState.OpCode == 6512)
        {
            StartCoroutine(FreeroomEndgame(freematchid));
            string winnerjaldi5 = Encoding.UTF8.GetString(matchState.State);
            WinnerPanel.SetActive(true);
            InGameText.SetActive(false);
            Winnerfreeroom.text = winnerjaldi5;
            _freeroomSpotitems[0].SetActive(false);
            _freeroomendgameButton.SetActive(true);
            if(freeroomplayerwin == false)
            {
                _winloosefree.SetActive(true);
                winLoosetextfreeroom.text = "You lost the game";
                _winloosefreeroom.Play();
            }
        }

        if (matchState.OpCode == SpotCheckOpcodefreeroom)
        {
            _spotcheckerfreeroom = GameObject.FindWithTag("SpotCheck").GetComponent<SpotCheckerfreeroom>();
            if(_spotcheckerfreeroom.checkspotno == "no")
            {
                StopCoroutine(spotcall);
                SpotLooserfreeroom();
            }
        }
    }

    private IEnumerator GetUserID(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Getuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    private IEnumerator RegisterEmail(string email, string userid)
    {

        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/RegisterEmail.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public void SpotLooserfreeroom()
    {
        StartCoroutine(DeleteUserFreeroom(USERID, freematchid));
        _freeroomSpotitems[1].SetActive(false);
        _freeroomSpotitems[2].SetActive(false);
    }

    public void SpotLooser()
    {
        fetchjaldi5wins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersJaldi5>();
        StopCoroutine(usersjaldi5);
        StartCoroutine(DeleteUser(USERID));
        _spotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<SpotChecker>();
        StopCoroutine(spotcall);
        _Spotitems[1].SetActive(false);
        _Spotitems[2].SetActive(false);
    }

    public void toplineSpotLooser()
    {
        fetchtoplinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersTopline>();
        StopCoroutine(userstopline);
        StartCoroutine(toplineDeleteUser(USERID));
        _toplinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<toplineSpotChecker>();
        StopCoroutine(toplinespotcall);
        _toplineSpotitems[1].SetActive(false);
        _toplineSpotitems[2].SetActive(false);
    }

    public void middlelineSpotLooser()
    {
        fetchmiddlelinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersMiddleline>();
        StopCoroutine(usersmiddleline);
        StartCoroutine(middlelineDeleteUser(USERID));
        _middlelinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<middlelineSpotChecker>();
        StopCoroutine(middlelinespotcall);
        _middlelineSpotitems[1].SetActive(false);
        _middlelineSpotitems[2].SetActive(false);
    }

    public void bottomlineSpotLooser()
    {
        fetchbottomlinewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersBottomline>();
        StopCoroutine(usersbottomline);
        StartCoroutine(bottomlineDeleteUser(USERID));
        _bottomlinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<bottomlineSpotChecker>();
        StopCoroutine(bottomlinespotcall);
        _bottomlineSpotitems[1].SetActive(false);
        _bottomlineSpotitems[2].SetActive(false);
    }

    public void fullhouseSpotLooser()
    {
        fetchfullhousewins = GameObject.FindWithTag("SpotRound").GetComponent<fetchwinnersFullhouse>();
        StopCoroutine(usersfullhouse);
        StartCoroutine(fullhouseDeleteUser(USERID));
        _fullhousespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<fullhouseSpotChecker>();
        StopCoroutine(fullhousespotcall);
        _fullhouseSpotitems[1].SetActive(false);
        _fullhouseSpotitems[2].SetActive(false);
    }

    public async void GameContfreeroom()
    {
        freeroomplayerwin = true;
        Winnerfreeroom.text = _mainmanager.DisplayName.text;
        string wintext = Winnerfreeroom.text.ToString();
        await Socket.SendMatchStateAsync(freematchid, 6512, wintext, null);
        _mainmanager.coins = _mainmanager.coins + 100;
        _mainmanager.cointext.text = _mainmanager.coins.ToString();
        StartCoroutine(_mainmanager.UpdateCurrency(USERID, _mainmanager.coins));
        _winloosefree.SetActive(true);
        winLoosetextfreeroom.text = "You won the game";
        _winloosefreeroom.Play();
        _spotcheckerfreeroom = GameObject.FindWithTag("SpotCheck").GetComponent<SpotCheckerfreeroom>();
        StopCoroutine(spotcall);
        _freeroomendgameButton.SetActive(true);
        _freeroomSpotitems[0].SetActive(false);
        _freeroomSpotitems[1].SetActive(false);
        _freeroomSpotitems[2].SetActive(false);
        StartCoroutine(FreeroomEndgame(freematchid));
    }

    public async void leavematch()
    {
        await Socket.LeaveMatchAsync(freematchid);
    }

    public async void leavematchmain()
    {
        await Socket.LeaveMatchAsync(mymatchid);
    }

    private IEnumerator FreeroomEndgame(string matchid)
    {
        string spotmatchid = "m" + matchid;
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        form.AddField("spotmatchid", spotmatchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/endgamefreeroom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    private IEnumerator FreeroomStartgame(string matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/startgamefreeroom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public async void GameCont()
    {
        StartCoroutine(Enablespotendcheck("Jaldi5"));
        jaldi5playerwin = true;
        StartCoroutine(_mainmanager.SendWinnerName(_mainmanager.DisplayName.text, "Jaldi5"));
        if(isvoucher == true)
        {
            winneralert = 1;
        }
        else
        {
            _mainmanager.gems = _mainmanager.gems + jaldi5prize;
            StartCoroutine(_mainmanager.UpdateGemCurrency(USERID, _mainmanager.gems));
        }
        Jaldi5Winner.text = _mainmanager.DisplayName.text;
        await Socket.SendMatchStateAsync(mymatchid, 3214, "", null);
        _spotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<SpotChecker>();
        StopCoroutine(spotcall);

        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _Spotitems[0].SetActive(false);
        _Spotitems[1].SetActive(false);
        _Spotitems[2].SetActive(false);
        finalgamecheck = "Jaldi5";
        StartCoroutine(UpdateFinalGamecheck(finalgamecheck));
        _jaldi5Text.SetActive(true);
        _winloosemain.SetActive(false);
        _winloosemain.SetActive(true);
        winLoosetext.text = "You won Jaldi5 !!";
        _winloose.Play();
        gamewin = true;
        gamerunning = true;
    }

    public async void toplineGameCont()
    {
        StartCoroutine(Enablespotendcheck("TopLine"));
        toplineplayerwin = true;
        StartCoroutine(_mainmanager.SendWinnerName(_mainmanager.DisplayName.text, "Topline"));
        if(isvoucher == true)
        {
            winneralert = 1;
        }
        else
        {
            _mainmanager.gems = _mainmanager.gems + lineprize;
            StartCoroutine(_mainmanager.UpdateGemCurrency(USERID, _mainmanager.gems));
        }
        ToplineWinner.text = _mainmanager.DisplayName.text;
        await Socket.SendMatchStateAsync(mymatchid, 3215, "", null);
        _toplinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<toplineSpotChecker>();
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        
        if(isvoucher == true)
        {
            _ticketbackend.ExtracttoplineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtracttoplineTicket();
        }
        StopCoroutine(toplinespotcall);

        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _toplineSpotitems[0].SetActive(false);
        _toplineSpotitems[1].SetActive(false);
        _toplineSpotitems[2].SetActive(false);
        finalgamecheck = "TopLine";
        StartCoroutine(UpdateFinalGamecheck(finalgamecheck));
        _toplineText.SetActive(true);
        _winloosemain.SetActive(false);
        _winloosemain.SetActive(true);
        winLoosetext.text = "You won Topline !!";
        _winloose.Play();
        gamewin = true;
        gamerunning = true;
    }

    public async void middlelineGameCont()
    {
        StartCoroutine(Enablespotendcheck("MiddleLine"));
        middlelineplayerwin = true;
        StartCoroutine(_mainmanager.SendWinnerName(_mainmanager.DisplayName.text, "Middleline"));
        if(isvoucher == true)
        {
            winneralert = 1;
        }
        else
        {
            _mainmanager.gems = _mainmanager.gems + lineprize;
            StartCoroutine(_mainmanager.UpdateGemCurrency(USERID, _mainmanager.gems));
        }
        MiddlelineWinner.text = _mainmanager.DisplayName.text;
        await Socket.SendMatchStateAsync(mymatchid, 3216, "", null);
        _middlelinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<middlelineSpotChecker>();
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractmiddlelineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractmiddlelineTicket();
        }
        StopCoroutine(middlelinespotcall);

        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _middlelineSpotitems[0].SetActive(false);
        _middlelineSpotitems[1].SetActive(false);
        _middlelineSpotitems[2].SetActive(false);
        finalgamecheck = "MiddleLine";
        StartCoroutine(UpdateFinalGamecheck(finalgamecheck));
        _middlelineText.SetActive(true);
        _winloosemain.SetActive(false);
        _winloosemain.SetActive(true);
        winLoosetext.text = "You won Middleline !!";
        _winloose.Play();
        gamewin  = true;
        gamerunning = true;
    }

    public async void bottomlineGameCont()
    {
        StartCoroutine(Enablespotendcheck("BottomLine"));
        bottomlineplayerwin = true;
        StartCoroutine(_mainmanager.SendWinnerName(_mainmanager.DisplayName.text, "Bottomline"));
        if(isvoucher == true)
        {
            winneralert = 1;
        }
        else
        {
            _mainmanager.gems = _mainmanager.gems + lineprize;
            StartCoroutine(_mainmanager.UpdateGemCurrency(USERID, _mainmanager.gems));
        }
        BottomlineWinner.text = _mainmanager.DisplayName.text;
        await Socket.SendMatchStateAsync(mymatchid, 3217, "", null);
        _bottomlinespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<bottomlineSpotChecker>();
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractbottomlineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractbottomlineTicket();
        }
        StopCoroutine(bottomlinespotcall);

        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
        _bottomlineSpotitems[0].SetActive(false);
        _bottomlineSpotitems[1].SetActive(false);
        _bottomlineSpotitems[2].SetActive(false);
        finalgamecheck = "BottomLine";
        StartCoroutine(UpdateFinalGamecheck(finalgamecheck));
        _bottomlineText.SetActive(true);
        _winloosemain.SetActive(false);
        _winloosemain.SetActive(true);
        winLoosetext.text = "You won Bottomline !!";
        _winloose.Play();
        gamewin = true;
        gamerunning = true;
    }

    public async void fullhouseGameCont()
    {
        StartCoroutine(Enablespotendcheck("FullHouse"));
        fullhouseplayerwin = true;
        StartCoroutine(_mainmanager.SendWinnerName(_mainmanager.DisplayName.text, "Fullhouse"));
        if(isvoucher == true)
        {
            winneralert = 1;
        }
        else
        {
            _mainmanager.gems = _mainmanager.gems + houseprize;
            StartCoroutine(_mainmanager.UpdateGemCurrency(USERID, _mainmanager.gems));
        }
        FullhouseWinner.text = _mainmanager.DisplayName.text;
        await Socket.SendMatchStateAsync(mymatchid, 3218, "", null);
        _fullhousespotchecker = GameObject.FindWithTag("SpotCheck").GetComponent<fullhouseSpotChecker>();
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractfullhouseTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractfullhouseTicket();
        }
        StopCoroutine(fullhousespotcall);
        _fullhouseSpotitems[0].SetActive(false);
        _fullhouseSpotitems[1].SetActive(false);
        _fullhouseSpotitems[2].SetActive(false);
        finalgamecheck = "FullHouse";
        StartCoroutine(UpdateFinalGamecheck(finalgamecheck));
        _fullhouseText.SetActive(true);
        _winloosemain.SetActive(false);
        _winloosemain.SetActive(true);
        winLoosetext.text = "You won Fullhouse !!";
        _winloose.Play();
        gamewin  = true;
        _endgameButton.SetActive(true);
    }

    private IEnumerator Enablespotendcheck(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Enablespotendcheck.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator DeleteUserFreeroom(string userid, string matchid)
    {
        WWWForm form = new WWWForm();
        matchid = "m" + matchid;
        form.AddField("userid", userid);
        form.AddField("matchid", matchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/DeleteuseridFreeroom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator DeleteUser(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Deleteuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator toplineDeleteUser(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/toplineDeleteuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator middlelineDeleteUser(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/middlelineDeleteuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator bottomlineDeleteUser(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/bottomlineDeleteuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator fullhouseDeleteUser(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/fullhouseDeleteuserid.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }


    public IEnumerator UpdateFinalGamecheck(string update)
    {
        WWWForm form = new WWWForm();
        form.AddField("update", update);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateFinalGame.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public void ActivateFreeroomSpot()
    {
        _freeroomSpotitems[1].SetActive(true);
        _freeroomSpotitems[2].SetActive(true);
        _ticketbackendfreeroom = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackendJaldi5>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractjaldiTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractjaldiTicket();
        }
    }

    public void ActivateJaldi5()
    {
        _Spotitems[1].SetActive(true);
        _Spotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractjaldiTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractjaldiTicket();
        }
    }

    public void ActivateTopline()
    {
        _toplineSpotitems[1].SetActive(true);
        _toplineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtracttoplineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtracttoplineTicket();
        }
    }

    public void ActivateMiddleline()
    {
        _middlelineSpotitems[1].SetActive(true);
        _middlelineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractmiddlelineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractmiddlelineTicket();
        }
    }

    public void ActivateBottomline()
    {
        _bottomlineSpotitems[1].SetActive(true);
        _bottomlineSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractbottomlineTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractbottomlineTicket();
        }
    }

    public void ActivateFullhouse()
    {
        _fullhouseSpotitems[1].SetActive(true);
        _fullhouseSpotitems[2].SetActive(true);
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        if(isvoucher == true)
        {
            _ticketbackend.ExtractfullhouseTicketvoucher();
        }
        else
        {
            _ticketbackend.ExtractfullhouseTicket();
        }
    }

    public async void endgame()
    {
        leavematchmain();
        leavematchmain();
        Destroy(ManagerGame);
        SceneManager.LoadScene("Loading");
    }

    public async void ClaimPrize()
    {
        _ClaimPrizeButton.SetActive(false);
        _endgameButton.SetActive(true);
        Application.OpenURL("https://housiekings.com/prize-win/");
    }

    public IEnumerator RecieveWinnerName(string game)
    {
        WWWForm form = new WWWForm();
        form.AddField("game", game);
        WWW download = new WWW("http://34.121.136.31/housiekings/RecieveWinnerName.php", form);
        yield return download;
        string name = download.text.ToString();
        if(game == "Jaldi5" && name != "")
        {
            Jaldi5Winner.text = name;
            _jaldi5Text.SetActive(true);
        }
        else if(game == "Topline" && name != "")
        {
            ToplineWinner.text = name;
            _toplineText.SetActive(true);
        }
        else if(game == "Middleline" && name != "")
        {
            MiddlelineWinner.text = name;
            _middlelineText.SetActive(true);
        }
        else if(game == "Bottomline" && name != "")
        {
            BottomlineWinner.text = name;
            _bottomlineText.SetActive(true);
        }
        else if(game == "Fullhouse" && name != "")
        {
            FullhouseWinner.text = name;
            _fullhouseText.SetActive(true);
        }
    }

    public async void GameStopfreeroom()
    {
        _freeroomSpotitems[0].SetActive(true);
        _freeroomSpotitems[1].SetActive(true);
        _freeroomSpotitems[2].SetActive(true);
        Invoke("freeroomjaldi5", 10);
        _ticketbackendfreeroom = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackendJaldi5>();
        _ticketbackendfreeroom.ExtractjaldiTicket();
        _networkgamejaldi5 = GameObject.FindWithTag("GameChecking").GetComponent<NetworkGameCheckJaldi5>();
        string latest = _networkgamejaldi5.latestnumber.ToString();
        await Socket.SendMatchStateAsync(freematchid, jaldi5Opcodefreeroom, latest, null);
    }

    private async void freeroomjaldi5()
    {
        await Socket.SendMatchStateAsync(freematchid, jaldi5SpotOpcodefreeroom, "", null);
    }

    public IEnumerator ResetTicketStatus(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/ResetTicketStatus.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator ResetTicketStatusvoucher(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/ResetTicketStatusvoucher.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator ResetGameStatus()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/ResetGamestatus.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }



    public async void SendSpotMatchfreeroom()
    {
        await Socket.SendMatchStateAsync(freematchid, SpotCheckOpcodefreeroom, "", null);
    }

    public async void SendJaldi5Match()
    {
        await Socket.SendMatchStateAsync(mymatchid, SpotCheckJaldi5Opcode, "", null);
    }

    public async void SendToplineMatch()
    {
        await Socket.SendMatchStateAsync(mymatchid, SpotCheckToplineOpcode, "", null);
    }

    public async void SendMiddlelineMatch()
    {
        await Socket.SendMatchStateAsync(mymatchid, SpotCheckMiddlelineOpcode, "", null);
    }

    public async void SendBottomlineMatch()
    {
        await Socket.SendMatchStateAsync(mymatchid, SpotCheckBottomlineOpcode, "", null);
    }

    public async void SendFullhouseMatch()
    {
        await Socket.SendMatchStateAsync(mymatchid, SpotCheckFullhouseOpcode, "", null);
    }

    public async void Jaldi5StartFreeroom()
    {
        await Socket.SendMatchStateAsync(freematchid, jaldi5gamestartOpcode, "", null);
    }

    public async void StartLootroomGame()
    {
        await Socket.SendMatchStateAsync(mymatchid, gamestartOpcode, "", null);
    }
}
