using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleSQL;

public class MainMenuManager : MonoBehaviour
{
    public Dropdown m_dropdown;
    public Dropdown f_dropdown;
    public Dropdown v_dropdown;
    public GameObject _roomsPanel;
    public GameObject _shopPanel;
    private TicketsBuy _ticketbuy;
    public GameObject _lobbyPanel;
    public GameObject[] _PurchaseButtons;
    public GameObject[] _PurchaseButtonsvoucher;
    public GameObject[] _PurchaseButtonsfreeroom;
    private NakamaTest _nakama;
    public int coins;
    public int rubies;
    public int gems;
    public Text cointext;
    public Text gemtext;
    public Text rubytext;
    public SimpleSQLManager dbManager;
    public GameObject DisplayNamePanel;
    public InputField nameInnput;
    public GameObject NullError;
    public GameObject NameError;
    public Text DisplayName;
    public GameObject StartButton;
    public GameObject StartButtonvoucher;
    public GameObject Startlock;
    public GameObject Startlockvoucher;
    public Button Startgame;
    public Button Startgamevoucher;
    public Text[] gameTime;
    public Text ticketno;
    public Text ticketnovoucher;
    public GameObject _freeroomLobby;
    public int match;
    public Text roomname;
    public GameObject _coinPanel;
    public GameObject _rubyPanel;
    public GameObject Loading;
    public GameObject LoadText;
    public Animation _loadinganim;
    public GameObject _cancelButton;
    private Coroutine Matchmake;
    public GameObject noroomsPanel;
    public GameObject _settingsPanel;
    private bool toggle;
    public Text[] Prizes; 
    public GameObject tutorial;
    public GameObject RewardedAdsButton;
    private ADManager _adsmanager;
    public Text NoOfPlayers;
    private int players;
    public Text extractprize1;
    public Text extractprize2;
    public Text extractprize3;
    public Text extractprize4;
    public Text extractprize5;
    public Text extractprize6;
    public Text extractprize7;
    public Text extractprize8;
    public Text extractprize9;
    public Text extractprize10;
    public Text extractcost1;
    public Text extractcost2;
    public Text extractcost3;
    public Text extractcost4;
    public Text extractcost5;
    public Text extractcost6;
    public Text extractcost7;
    public Text extractcost8;
    public Text extractcost9;
    public Text extractcost10;
    public GameObject ClaimPrizesPanel;
    int prizecost;
    int prizetype;
    public GameObject _GemShortPanel;
    public GameObject _EmailenterPanel;
    public GameObject _ThanksScreen;
    public InputField emailinput;
    public InputField phoneinput;
    public GameObject emailerror;
    public GameObject phoneerror;
    public GameObject cantstartPanel;
    public GameObject refundButton;
    public GameObject refundButtonvoucher;

    void Start()
    {
        cantstartPanel.SetActive(false);
        emailerror.SetActive(false);
        phoneerror.SetActive(false);
        _GemShortPanel.SetActive(false);
        _EmailenterPanel.SetActive(false);
        _ThanksScreen.SetActive(false);
        tutorial.SetActive(false);
        _settingsPanel.SetActive(false);
        _freeroomLobby.SetActive(false);
        _lobbyPanel.SetActive(false);
        _shopPanel.SetActive(false);
        _cancelButton.SetActive(false);
        _roomsPanel.SetActive(false);
        noroomsPanel.SetActive(false);
        _coinPanel.SetActive(false);
        _rubyPanel.SetActive(false);
        NameError.SetActive(false);
        NullError.SetActive(false);
        DisplayNamePanel.SetActive(false);
        ClaimPrizesPanel.SetActive(false);
        _adsmanager = GameObject.FindWithTag("MainMenuManager").GetComponent<ADManager>();
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _PurchaseButtons[0].SetActive(true);
        _PurchaseButtons[1].SetActive(true);
        _ticketbuy = GameObject.FindWithTag("MainMenuManager").GetComponent<TicketsBuy>();
        StartCoroutine(ExtractGameStatus());
        StartCoroutine(ExtractPrizes());
        StartCoroutine(ExtractClaimPrizes());
    }

    public IEnumerator ExtractCoins(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/UpdateCoins.php", form);
        yield return download;
        string coinstring = download.text.ToString();
        coins = int.Parse(coinstring);
        cointext.text = coins.ToString();
    }

    public IEnumerator ExtractRubies(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/UpdateRubies.php", form);
        yield return download;
        string coinstring = download.text.ToString();
        rubies = int.Parse(coinstring);
        rubytext.text = rubies.ToString();
    }

    public IEnumerator ExtractGems(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/UpdateGems.php", form);
        yield return download;
        string gemstring = download.text.ToString();
        gems = int.Parse(gemstring);
        gemtext.text = gems.ToString();
    }

    public void PlayGame()
    {
        _adsmanager.PlayADFullhouse();
        _roomsPanel.SetActive(true);
    }

    public void EnterFreeroomPanel()
    {
        StartCoroutine(SelectmatchJaldi5());
    }

    public void OpenShop()
    {
        _roomsPanel.SetActive(false);
        ClaimPrizesPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _freeroomLobby.SetActive(false);
        _lobbyPanel.SetActive(false);
        _shopPanel.SetActive(true);
        tutorial.SetActive(false);
        _adsmanager.PlayAdStore();
    }

    public void OpenClaimPrizes()
    {
        _adsmanager.PlayADClaimprize();
        _roomsPanel.SetActive(false);
        ClaimPrizesPanel.SetActive(true);
        _settingsPanel.SetActive(false);
        _freeroomLobby.SetActive(false);
        _lobbyPanel.SetActive(false);
        _shopPanel.SetActive(false);
        tutorial.SetActive(false);
        StartCoroutine(ExtractClaimPrizes());
    }

    public void BuyTicket()
    {
        if (m_dropdown.options[m_dropdown.value].text == "1" && coins >= 50)
        {
            PlayerPrefs.SetInt("NoOfTickets", 1);
            coins = coins - 50;
            cointext.text = coins.ToString(); 
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(1,_nakama.USERID));
            ticketno.text = "1";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else if (m_dropdown.options[m_dropdown.value].text == "2" && coins >= 100)
        {
            PlayerPrefs.SetInt("NoOfTickets", 2);
            coins = coins - 100;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Ticket2Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(2,_nakama.USERID));
            ticketno.text = "2";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else if (m_dropdown.options[m_dropdown.value].text == "3" && coins >= 150)
        {
            PlayerPrefs.SetInt("NoOfTickets", 3);
            coins = coins - 150;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Ticket2Extraction());
            StartCoroutine(_ticketbuy.Ticket3Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(3,_nakama.USERID));
            ticketno.text = "3";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else if (m_dropdown.options[m_dropdown.value].text == "4" && coins >= 200)
        {
            PlayerPrefs.SetInt("NoOfTickets", 4);
            coins = coins - 200;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Ticket2Extraction());
            StartCoroutine(_ticketbuy.Ticket3Extraction()); 
            StartCoroutine(_ticketbuy.Ticket4Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(4,_nakama.USERID));
            ticketno.text = "4";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else if (m_dropdown.options[m_dropdown.value].text == "5" && coins >= 250)
        {
            PlayerPrefs.SetInt("NoOfTickets", 5);
            coins = coins - 250;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Ticket2Extraction());
            StartCoroutine(_ticketbuy.Ticket3Extraction());
            StartCoroutine(_ticketbuy.Ticket4Extraction());
            StartCoroutine(_ticketbuy.Ticket5Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(5,_nakama.USERID));
            ticketno.text = "5";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else if (m_dropdown.options[m_dropdown.value].text == "6" && coins >= 300)
        {
            PlayerPrefs.SetInt("NoOfTickets", 6);
            coins = coins - 300;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extraction());
            StartCoroutine(_ticketbuy.Ticket2Extraction());
            StartCoroutine(_ticketbuy.Ticket3Extraction());
            StartCoroutine(_ticketbuy.Ticket4Extraction());
            StartCoroutine(_ticketbuy.Ticket5Extraction());
            StartCoroutine(_ticketbuy.Ticket6Extraction());
            StartCoroutine(_ticketbuy.Spot1Extraction());
            StartCoroutine(_ticketbuy.Spot2Extraction());
            StartCoroutine(_ticketbuy.Spot3Extraction());
            StartCoroutine(_ticketbuy.Spot4Extraction());
            StartCoroutine(_ticketbuy.Spot5Extraction());
            StartCoroutine(UpdateTicketStatus(6,_nakama.USERID));
            ticketno.text = "6";
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            refundButton.SetActive(true);
        }
        else
        {
            _coinPanel.SetActive(true);
        }
    }
    
    public void BuyTicketVoucher()
    {
        if (v_dropdown.options[v_dropdown.value].text == "1" && rubies >= 20)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 1);
            rubies = rubies - 20;
            rubytext.text = rubies.ToString(); 
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(1,_nakama.USERID));
            ticketnovoucher.text = "1";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else if (v_dropdown.options[v_dropdown.value].text == "2" && rubies >= 40)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 2);
            rubies = rubies - 40;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(2,_nakama.USERID));
            ticketnovoucher.text = "2";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else if (v_dropdown.options[v_dropdown.value].text == "3" && rubies >= 60)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 3);
            rubies = rubies - 60;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket2Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(3,_nakama.USERID));
            ticketnovoucher.text = "3";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else if (v_dropdown.options[v_dropdown.value].text == "4" && rubies >= 80)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 4);
            rubies = rubies - 80;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket2Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket3Extractionvoucher()); 
            StartCoroutine(_ticketbuy.Ticket4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(4,_nakama.USERID));
            ticketnovoucher.text = "4";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else if (v_dropdown.options[v_dropdown.value].text == "5" && rubies >= 100)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 5);
            rubies = rubies - 100;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket2Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket3Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket4Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket5Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(5,_nakama.USERID));
            ticketnovoucher.text = "5";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else if (v_dropdown.options[v_dropdown.value].text == "6" && rubies >= 120)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 6);
            rubies = rubies - 120;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
            StartCoroutine(_ticketbuy.Ticket1Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket2Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket3Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket4Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket5Extractionvoucher());
            StartCoroutine(_ticketbuy.Ticket6Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot1Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot2Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot3Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot4Extractionvoucher());
            StartCoroutine(_ticketbuy.Spot5Extractionvoucher());
            StartCoroutine(UpdateTicketStatusruby(6,_nakama.USERID));
            ticketnovoucher.text = "6";
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            refundButtonvoucher.SetActive(true);
        }
        else
        {
            _rubyPanel.SetActive(true);
        }
    }

    public void BuyTicketFreeroom()
    {
        if (f_dropdown.options[f_dropdown.value].text == "1" && coins >= 10)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 1);
            coins = coins - 10;
            cointext.text = coins.ToString(); 
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else if (f_dropdown.options[f_dropdown.value].text == "2" && coins >= 20)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 2);
            coins = coins - 20;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket2Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else if (f_dropdown.options[f_dropdown.value].text == "3" && coins >= 30)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 3);
            coins = coins - 30;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket2Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket3Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else if (f_dropdown.options[f_dropdown.value].text == "4" && coins >= 40)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 4);
            coins = coins - 40;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket2Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket3Extractionfreeroom()); 
            StartCoroutine(_ticketbuy.Ticket4Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else if (f_dropdown.options[f_dropdown.value].text == "5" && coins >= 50)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 5);
            coins = coins - 50;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket2Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket3Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket4Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket5Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else if (f_dropdown.options[f_dropdown.value].text == "6" && coins >= 60)
        {
            PlayerPrefs.SetInt("Jaldi5NoOfTickets", 6);
            coins = coins - 60;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
            StartCoroutine(_ticketbuy.Ticket1Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket2Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket3Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket4Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket5Extractionfreeroom());
            StartCoroutine(_ticketbuy.Ticket6Extractionfreeroom());
            StartCoroutine(_ticketbuy.Spot1Extractionfreeroom());
            _PurchaseButtonsfreeroom[0].SetActive(false);
            _PurchaseButtonsfreeroom[1].SetActive(false);
        }
        else
        {
            _coinPanel.SetActive(true);
        }
    }

    public void CloseCoinPanel()
    {
        _coinPanel.SetActive(false);
    }

    public IEnumerator UpdateCurrency(string userid, int Coins)
    {
        WWWForm form = new WWWForm();
        form.AddField("Userid", userid);
        form.AddField("coins", Coins);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateCurrency.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator UpdateRubyCurrency(string userid, int Coins)
    {
        WWWForm form = new WWWForm();
        form.AddField("Userid", userid);
        form.AddField("coins", Coins);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateRubyCurrency.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator UpdateGemCurrency(string userid, int Gems)
    {
        WWWForm form = new WWWForm();
        form.AddField("Userid", userid);
        form.AddField("gems", Gems);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateGemCurrency.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator UpdateTicketStatus(int number, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("number", number);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateTicketStatus.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }
    public IEnumerator UpdateTicketStatusruby(int number, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("number", number);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateTicketStatusruby.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator UpdateAdlimit(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateAdlimit.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator ExtractTicketStatus(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractTicketStatus.php", form);
        yield return download;
        string check = download.text.ToString();
        if(check == "yes")
        {
            _PurchaseButtons[0].SetActive(false);
            _PurchaseButtons[1].SetActive(false);
            StartButton.SetActive(true);
            refundButton.SetActive(true);
        }
        else if(check == "no")
        {
            _PurchaseButtons[0].SetActive(true);
            _PurchaseButtons[1].SetActive(true);
            refundButton.SetActive(false);
            ResetGame();
        }
    }

    public IEnumerator ExtractTicketStatusvoucher(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractTicketStatusvoucher.php", form);
        yield return download;
        string check = download.text.ToString();
        if(check == "yes")
        {
            _PurchaseButtonsvoucher[0].SetActive(false);
            _PurchaseButtonsvoucher[1].SetActive(false);
            StartButtonvoucher.SetActive(true);
            refundButtonvoucher.SetActive(true);
        }
        else if(check == "no")
        {
            _PurchaseButtonsvoucher[0].SetActive(true);
            _PurchaseButtonsvoucher[1].SetActive(true);
            refundButtonvoucher.SetActive(false);
            ResetGamevoucher();
        }
    }

    public IEnumerator ExtractDisplayName(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractDisplayName.php", form);
        yield return download;
        string name = download.text.ToString();
        if(name == "" || name == null)
        {
            DisplayNamePanel.SetActive(true);
            StartCoroutine(ExtractCoins(_nakama.USERID));
            StartCoroutine(ExtractRubies(_nakama.USERID));
            StartCoroutine(ExtractGems(_nakama.USERID));
        }
        else
        {
            DisplayName.text = name;
        }
    }

    public void OKButton()
    {
        if(nameInnput.text == "" || nameInnput.text == null)
        {
            NullError.SetActive(true);
        }
        else
        {
            NullError.SetActive(false);
            StartCoroutine(ChooseName(nameInnput.text, _nakama.USERID));
        }
    }

    public IEnumerator SendWinnerName(string name, string game)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("game", game);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/SendWinnerName.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public IEnumerator ChooseName(string name, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateDisplayName.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
            else
            {
                if (www.downloadHandler.text.Contains("Duplicate name"))
                {
                    NameError.SetActive(true);
                }
                else if (www.downloadHandler.text.Contains("ticket registered"))
                {
                    NameError.SetActive(false);
                    DisplayName.text = nameInnput.text;
                    DisplayNamePanel.SetActive(false);
                }
            }
        }
    }

    public IEnumerator ExtractGameStatus()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractGameStatus.php", form);
        yield return download;
        string gamestatus = download.text.ToString();
        if (gamestatus == "Started")
        {       
            Startlock.SetActive(false);
            Startlockvoucher.SetActive(true);
            Startgame.interactable = true;
            Startgamevoucher.interactable = false;
        }
        else if (gamestatus == "Voucher")
        {       
            Startlock.SetActive(true);
            Startlockvoucher.SetActive(false);
            Startgame.interactable = false;
            Startgamevoucher.interactable = true;
        }

        else
        {
            Startlock.SetActive(true);
            Startlockvoucher.SetActive(true);
            Startgame.interactable = false;
            Startgamevoucher.interactable = false;
        }
    }

    private IEnumerator ExtractTicketnumber(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractTicketNumber.php", form);
        yield return download;
        string ticketnumber = download.text.ToString();
        ticketno.text = ticketnumber;
    }
    public IEnumerator ExtractAdlimit(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractAdlimit.php", form);
        yield return download;
        int limit = int.Parse(download.text.ToString());
        if(limit<=0)
        {
            RewardedAdsButton.SetActive(false);
        }
        else
        {
            RewardedAdsButton.SetActive(true);
        }
    }
    public void ResetGame()
    {
        var sql = "DROP TABLE IF EXISTS PlayerTickets";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS NumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS toplineSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS middlelineSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS fullhouseSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS SpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS bottomlineSpotNumberCalling";
        dbManager.Execute(sql);
    }
    
    public void ResetGamevoucher()
    {
        var sql = "DROP TABLE IF EXISTS PlayerTicketsvoucher";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS NumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS toplineSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS middlelineSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS fullhouseSpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS SpotNumberCalling";
        dbManager.Execute(sql);
        sql = "DROP TABLE IF EXISTS bottomlineSpotNumberCalling";
        dbManager.Execute(sql);
    }

    public void EnterLobby()
    { 
        StartCoroutine(ExtractTicketStatus(_nakama.USERID));
        StartCoroutine(ExtractTicketStatusvoucher(_nakama.USERID));
        StartCoroutine(ExtractTicketnumber(_nakama.USERID));
        StartCoroutine(ExtractGameStatus());
        StartCoroutine(ExtractPrizes());
        _roomsPanel.SetActive(false);
    }

    public void openSettings()
    {
        _settingsPanel.SetActive(true);
        ClaimPrizesPanel.SetActive(false);
        _roomsPanel.SetActive(false);
        _freeroomLobby.SetActive(false);
        _lobbyPanel.SetActive(false);
        _shopPanel.SetActive(false);
        tutorial.SetActive(false);
        _adsmanager.PlayAdSettings();
    }

    public void LobbyExit()
    {
        ClaimPrizesPanel.SetActive(false);
        _roomsPanel.SetActive(false);
        _freeroomLobby.SetActive(false);
        _lobbyPanel.SetActive(false);
        _shopPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        tutorial.SetActive(false);
    }

    public void ToggleSound()
    {
        toggle = !toggle;
        if (toggle)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
    }

    public void closenoroomsPanel()
    {
        noroomsPanel.SetActive(false);
    }

    public IEnumerator SelectmatchJaldi5()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/SelectmatchJaldi5.php", form);
        yield return download;
        if (download.text == null || download.text == "")
        {
            noroomsPanel.SetActive(true);
        }
        else
        {
            match = int.Parse(download.text.ToString());
            PlayerPrefs.SetInt("FreeMatch", 1);
            roomname.text = "Jaldi5";
            _roomsPanel.SetActive(false);
            _freeroomLobby.SetActive(true);
        }
    }


    public void StartFreeGameButton()
    {
        Matchmake = StartCoroutine(StartFreeGame());
    }
    private IEnumerator StartFreeGame()
    {
        Loading.SetActive(true);
        LoadText.SetActive(true);
        _loadinganim.Play();
        _cancelButton.SetActive(true);
        while (true)
        {
            yield return new WaitForSeconds(3);
            StartCoroutine(StartFreeMatch(match));
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator StartFreeMatch(int matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractUsercount.php", form);
        yield return download;
        string users = download.text.ToString();
        int usercount = int.Parse(users);
        if (usercount >= 4)
        {
            StartCoroutine(JoinMatchJaldi5(match));
            StopCoroutine(Matchmake);
            players = usercount;
        }
    }

    private IEnumerator JoinMatchJaldi5(int matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractMatchid.php", form);
        yield return download;
        string newmatchid = download.text.ToString();
        if(roomname.text == "Jaldi5")
        {
            _nakama.JoinFreeMatchJaldi5(newmatchid);
            _nakama.JoinFreeMatchJaldi5(newmatchid);
        }
        yield return new WaitForSeconds(1);
        Loading.SetActive(false);
        LoadText.SetActive(false);
        _loadinganim.Stop();
    }

    public void CancelButton()
    {
        StopCoroutine(Matchmake);
        Loading.SetActive(false);
        LoadText.SetActive(false);
        _loadinganim.Stop();
        _cancelButton.SetActive(false);
        _ticketbuy.FreegameStart.SetActive(true);
    }

    private IEnumerator FetchLootroomMatchid()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/Fetchmatchid.php", form);
        yield return download;
        string newmatchid = download.text.ToString();
        if(newmatchid != null || newmatchid != "")
        {
            _nakama.JoinMatch(newmatchid);
            _nakama.JoinMatch(newmatchid);
        }
        else
        {
            noroomsPanel.SetActive(true);
        }
    }

    private IEnumerator FetchLootroomMatchidvoucher()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/Fetchmatchid.php", form);
        yield return download;
        string newmatchid = download.text.ToString();
        if(newmatchid != null || newmatchid != "")
        {
            _nakama.JoinMatchvoucher(newmatchid);
            _nakama.JoinMatchvoucher(newmatchid);
        }
        else
        {
            noroomsPanel.SetActive(true);
        }
    }

    public void StartLootRoom()
    {
        StartCoroutine(ExtractGameStartStatus());
    }

    public void StartVoucherRoom()
    {
        StartCoroutine(ExtractGameStartStatusvoucher());
    }

    private IEnumerator ExtractGameStartStatus()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractGameStatus.php", form);
        yield return download;
        string gamestatus = download.text.ToString();
        if (gamestatus == "Started")
        {       
            StartCoroutine(FetchLootroomMatchid());
        }

        else
        {
            cantstartPanel.SetActive(true);
        }
    }

    private IEnumerator ExtractGameStartStatusvoucher()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractGameStatus.php", form);
        yield return download;
        string gamestatus = download.text.ToString();
        if (gamestatus == "Voucher")
        {       
            StartCoroutine(FetchLootroomMatchidvoucher());
        }

        else
        {
            cantstartPanel.SetActive(true);
        }
    }

    public void cantstartOkButton()
    {
        cantstartPanel.SetActive(false);
    }

    public void Support()
    {
        Application.OpenURL("http://housiekings.com/customer-form/");
    }

    private IEnumerator ExtractPrizes()
    {
        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractJaldi5Prize.php", form);
        yield return download;
        Prizes[0].text = download.text;
        _nakama.jaldi5prize = int.Parse(download.text);
        
        WWWForm form1 = new WWWForm();
        WWW download1 = new WWW("http://34.121.136.31/housiekings/ExtractLinesPrize.php", form1);
        yield return download1;
        Prizes[1].text = download1.text;
        _nakama.lineprize = int.Parse(download1.text);

        WWWForm form2 = new WWWForm();
        WWW download2 = new WWW("http://34.121.136.31/housiekings/ExtractHousePrize.php", form2);
        yield return download2;
        Prizes[2].text = download2.text;
        _nakama.houseprize = int.Parse(download2.text);

        form2 = new WWWForm();
        download2 = new WWW("http://34.121.136.31/housiekings/ExtractVJaldi5Prize.php", form2);
        yield return download2;
        Prizes[3].text = download2.text;

        form2 = new WWWForm();
        download2 = new WWW("http://34.121.136.31/housiekings/ExtractVLinesPrize.php", form2);
        yield return download2;
        Prizes[4].text = download2.text;

        form2 = new WWWForm();
        download2 = new WWW("http://34.121.136.31/housiekings/ExtractVHousePrize.php", form2);
        yield return download2;
        Prizes[5].text = download2.text;

        form2 = new WWWForm();
        download2 = new WWW("http://34.121.136.31/housiekings/GameTimings.php", form2);
        yield return download2;
        Prizes[6].text = download2.text;
    }

    
    private IEnumerator ExtractClaimPrizes()
    {

        WWWForm form = new WWWForm();
        WWW download = new WWW("http://34.121.136.31/housiekings/extractprize1.php", form);
        yield return download;
        extractprize1.text = download.text;

        WWWForm form1 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize2.php", form1);
        yield return download;
        extractprize2.text = download.text;
        
        WWWForm form2 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize3.php", form2);
        yield return download;
        extractprize3.text = download.text;
        
        WWWForm form3 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize4.php", form3);
        yield return download;
        extractprize4.text = download.text;
        
        WWWForm form4 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize5.php", form4);
        yield return download;
        extractprize5.text = download.text;
        
        WWWForm form10 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize6.php", form10);
        yield return download;
        extractprize6.text = download.text;
        
        WWWForm form11 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize7.php", form11);
        yield return download;
        extractprize7.text = download.text;
        
        WWWForm form12 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize8.php", form12);
        yield return download;
        extractprize8.text = download.text;
        
        WWWForm form13 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize9.php", form13);
        yield return download;
        extractprize9.text = download.text;
        
        WWWForm form14 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractprize10.php", form14);
        yield return download;
        extractprize10.text = download.text;
        
        WWWForm form5 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost1.php", form5);
        yield return download;
        extractcost1.text = download.text;
        
        WWWForm form6 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost2.php", form6);
        yield return download;
        extractcost2.text = download.text;
        
        WWWForm form7 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost3.php", form7);
        yield return download;
        extractcost3.text = download.text;
        
        WWWForm form8 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost4.php", form8);
        yield return download;
        extractcost4.text = download.text;
        
        WWWForm form9 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost5.php", form9);
        yield return download;
        extractcost5.text = download.text;
        
        WWWForm form15 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost6.php", form15);
        yield return download;
        extractcost6.text = download.text;
        
        WWWForm form16 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost7.php", form16);
        yield return download;
        extractcost7.text = download.text;
        
        WWWForm form17 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost8.php", form17);
        yield return download;
        extractcost8.text = download.text;
        
        WWWForm form18 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost9.php", form18);
        yield return download;
        extractcost9.text = download.text;
        
        WWWForm form19 = new WWWForm();
        download = new WWW("http://34.121.136.31/housiekings/extractcost10.php", form19);
        yield return download;
        extractcost10.text = download.text;
    }

    public void Reward()
    {
        coins = coins + 100;
        cointext.text = coins.ToString();
        StartCoroutine(UpdateCurrency(_nakama.USERID,coins));
        StartCoroutine(UpdateAdlimit(_nakama.USERID));
        StartCoroutine(ExtractAdlimit(_nakama.USERID));
        _adsmanager.LoadRewardedAd();
    }

    public void OpenTutorial()
    {
        tutorial.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CoinShortStore()
    {
        _shopPanel.SetActive(true);
        _coinPanel.SetActive(false);
    }

    public void PlayerCount()
    {
        NoOfPlayers.text = "Players = " + players.ToString();
    }

    public void ClaimPrize1()
    {
        prizecost = int.Parse(extractcost1.text);
        prizetype = 1;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize2()
    {
        prizecost = int.Parse(extractcost2.text);
        prizetype = 2;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize3()
    {
        prizecost = int.Parse(extractcost3.text);
        prizetype = 3;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize4()
    {
        prizecost = int.Parse(extractcost4.text);
        prizetype = 4;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize5()
    {
        prizecost = int.Parse(extractcost5.text);
        prizetype = 5;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize6()
    {
        prizecost = int.Parse(extractcost6.text);
        prizetype = 6;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void ClaimPrize7()
    {
        prizecost = int.Parse(extractcost7.text);
        prizetype = 7;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }
    public void ClaimPrize8()
    {
        prizecost = int.Parse(extractcost8.text);
        prizetype = 8;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }
    public void ClaimPrize9()
    {
        prizecost = int.Parse(extractcost9.text);
        prizetype = 9;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }
    public void ClaimPrize10()
    {
        prizecost = int.Parse(extractcost10.text);
        prizetype = 10;
        if(prizecost <= gems)
        {
            _EmailenterPanel.SetActive(true);
        }
        else
        {
            _GemShortPanel.SetActive(true);
        }
    }

    public void GemshortOKButton()
    {
        _GemShortPanel.SetActive(false);
    }

    public void emailOKButton()
    {
        if((emailinput.text == null) || (emailinput.text == ""))
        {
            phoneerror.SetActive(false);
            emailerror.SetActive(true);
        }
        else if((phoneinput.text == null) || (phoneinput.text == ""))
        {
            phoneerror.SetActive(true);
            emailerror.SetActive(false);
        }
        else
        {
            phoneerror.SetActive(false);
            emailerror.SetActive(false);
            StartCoroutine(GetEmailPhone(_nakama.USERID , emailinput.text, phoneinput.text, prizetype.ToString()));
        }
    }

    private IEnumerator GetEmailPhone(string userid , string email, string phone, string prizetype)
    {
        WWWForm form = new WWWForm();
        form.AddField("Userid", userid);
        form.AddField("email", email);
        form.AddField("phone", phone);
        form.AddField("prizetype", prizetype);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/Claimprizeentry.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                gems = gems - prizecost;
                StartCoroutine(UpdateGemCurrency(_nakama.USERID,gems));
                gemtext.text = gems.ToString();
                _EmailenterPanel.SetActive(false);
                _ThanksScreen.SetActive(true);
            }
        }
    }

    public void emailBackbutton()
    {
        phoneerror.SetActive(false);
        emailerror.SetActive(false);
        _EmailenterPanel.SetActive(false);
    }

    public void thanksscreenOKButton()
    {
        _ThanksScreen.SetActive(false);
    }

    public void refundTicket()
    {
        StartButtonvoucher.SetActive(false);
        refundButton.SetActive(false);
        _PurchaseButtons[0].SetActive(true);
        _PurchaseButtons[1].SetActive(true);
        ticketno.text = "0";
        if(PlayerPrefs.GetInt("NoOfTickets") == 1)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 50;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));

        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 2)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 100;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));  
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 3)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 150;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));  
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 4)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 200;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 5)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 250;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 6)
        {
            PlayerPrefs.SetInt("NoOfTickets", 0);
            coins = coins + 300;
            cointext.text = coins.ToString();
            StartCoroutine(UpdateCurrency(_nakama.USERID, coins));           
        }
        StartCoroutine(UpdateTicketStatusNil(0,_nakama.USERID));
        ResetGame();
    }

    public void refundTicketvoucher()
    {
        ticketnovoucher.text = "0";
        if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 1)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 20;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));

        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 2)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 40;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));  
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 3)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 60;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));  
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 4)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 80;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 5)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 100;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 6)
        {
            PlayerPrefs.SetInt("NoOfTicketsvoucher", 0);
            rubies = rubies + 120;
            rubytext.text = rubies.ToString();
            StartCoroutine(UpdateRubyCurrency(_nakama.USERID, rubies));           
        }
        StartCoroutine(UpdateTicketStatusNilvoucher(0,_nakama.USERID));
        ResetGamevoucher();
        StartButtonvoucher.SetActive(false);
        refundButtonvoucher.SetActive(false);
        _PurchaseButtonsvoucher[0].SetActive(true);
        _PurchaseButtonsvoucher[1].SetActive(true);
    }
    
    public IEnumerator UpdateTicketStatusNil(int number, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("number", number);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateTicketStatusNil.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }
    
    public IEnumerator UpdateTicketStatusNilvoucher(int number, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("number", number);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateTicketStatusNilvoucher.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }
}
