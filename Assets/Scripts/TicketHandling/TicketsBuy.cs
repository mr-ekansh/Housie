using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using SimpleSQL;

public class TicketsBuy : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject StartButtonvoucher;
    public GameObject FreegameStart;
    public GameObject Loading;
    public GameObject LoadText;
    private string ticketnumber;
    public SimpleSQLManager dbManager;
    private int x;
    private MainMenuManager _manager;
    public GameObject _freeroomBack;
    void Start()
    {
        _freeroomBack.SetActive(false);
        _manager = GameObject.FindWithTag("MainMenuManager").GetComponent<MainMenuManager>();
        FreegameStart.SetActive(false);
        StartButton.SetActive(false);
        StartButtonvoucher.SetActive(false);
        Loading.SetActive(false);
        var sql = "DROP TABLE IF EXISTS Jaldi5PlayerTickets";
        dbManager.Execute(sql);
    }

    public IEnumerator Ticket1Extraction()
    {
        if(PlayerPrefs.GetInt("NoOfTickets") == 1)
        {
            x = 2;
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 2)
        {
            x = 4;
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 3)
        {
            x = 6;
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 4)
        {
            x = 8;
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 5)
        {
            x = 10;
        }
        else if(PlayerPrefs.GetInt("NoOfTickets") == 6)
        {
            x = 12;
        }
        var sql = "CREATE TABLE IF NOT EXISTS PlayerTickets (serialno INTEGER PRIMARY KEY AUTOINCREMENT, ticketno VARCHAR(5000))";
        dbManager.Execute(sql);
        Loading.SetActive(true);
        LoadText.SetActive(true);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    public IEnumerator Ticket2Extraction()
    {
        yield return new WaitForSeconds(2);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    
    public IEnumerator Ticket3Extraction()
    {
        yield return new WaitForSeconds(4);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    
    
    public IEnumerator Ticket4Extraction()
    {
        yield return new WaitForSeconds(6);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    
    public IEnumerator Ticket5Extraction()
    {
        yield return new WaitForSeconds(8);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    
    public IEnumerator Ticket6Extraction()
    {
        yield return new WaitForSeconds(10);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntry();
    }
    
    public IEnumerator Spot1Extraction()
    {
        yield return new WaitForSeconds(x);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionjaldi5spot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpot();
    }
    
    public IEnumerator Spot2Extraction()
    {
        yield return new WaitForSeconds(x+2);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractiontoplinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpot1();
    }
    
    public IEnumerator Spot3Extraction()
    {
        yield return new WaitForSeconds(x+4);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionmiddlelinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpot2();
    }
    
    public IEnumerator Spot4Extraction()
    {
        yield return new WaitForSeconds(x+6);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionbottomlinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpot3();
    }
    
    public IEnumerator Spot5Extraction()
    {
        yield return new WaitForSeconds(x+8);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionfullhousespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpot4();
        Loading.SetActive(false);
        LoadText.SetActive(false);
        StartButton.SetActive(true);
        StartCoroutine(_manager.ExtractGameStatus());
    }
    
    public IEnumerator Ticket1Extractionvoucher()
    {
        if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 1)
        {
            x = 2;
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 2)
        {
            x = 4;
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 3)
        {
            x = 6;
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 4)
        {
            x = 8;
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 5)
        {
            x = 10;
        }
        else if(PlayerPrefs.GetInt("NoOfTicketsvoucher") == 6)
        {
            x = 12;
        }
        var sql = "CREATE TABLE IF NOT EXISTS PlayerTicketsvoucher (serialno INTEGER PRIMARY KEY AUTOINCREMENT, ticketno VARCHAR(5000))";
        dbManager.Execute(sql);
        Loading.SetActive(true);
        LoadText.SetActive(true);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    public IEnumerator Ticket2Extractionvoucher()
    {
        yield return new WaitForSeconds(2);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    
    public IEnumerator Ticket3Extractionvoucher()
    {
        yield return new WaitForSeconds(4);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    
    
    public IEnumerator Ticket4Extractionvoucher()
    {
        yield return new WaitForSeconds(6);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    
    public IEnumerator Ticket5Extractionvoucher()
    {
        yield return new WaitForSeconds(8);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    
    public IEnumerator Ticket6Extractionvoucher()
    {
        yield return new WaitForSeconds(10);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionlootroom.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucher();
    }
    
    public IEnumerator Spot1Extractionvoucher()
    {
        yield return new WaitForSeconds(x);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionjaldi5spot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucherSpot();
    }
    
    public IEnumerator Spot2Extractionvoucher()
    {
        yield return new WaitForSeconds(x+2);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractiontoplinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucherSpot1();
    }
    
    public IEnumerator Spot3Extractionvoucher()
    {
        yield return new WaitForSeconds(x+4);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionmiddlelinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucherSpot2();
    }
    
    public IEnumerator Spot4Extractionvoucher()
    {
        yield return new WaitForSeconds(x+6);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionbottomlinespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucherSpot3();
    }
    
    public IEnumerator Spot5Extractionvoucher()
    {
        yield return new WaitForSeconds(x+8);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionfullhousespot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryvoucherSpot4();
        Loading.SetActive(false);
        LoadText.SetActive(false);
        StartButtonvoucher.SetActive(true);
        StartCoroutine(_manager.ExtractGameStatus());
    }

    

    public void DataEntryvoucher()
    {
        var sql = "INSERT INTO PlayerTicketsvoucher (ticketno) VALUES ('" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntryvoucherSpot()
    {        
        int val = 7;
        var sql = "INSERT INTO PlayerTicketsvoucher (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntryvoucherSpot1()
    {
        int val = 8;
        var sql = "INSERT INTO PlayerTicketsvoucher (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntryvoucherSpot2()
    {
        int val = 9;
        var sql = "INSERT INTO PlayerTicketsvoucher (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntryvoucherSpot3()
    {
        int val = 10;
        var sql = "INSERT INTO PlayerTicketsvoucher (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntryvoucherSpot4()
    {
        int val = 11;
        var sql = "INSERT INTO PlayerTicketsvoucher (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    public void DataEntry()
    {
        var sql = "INSERT INTO PlayerTickets (ticketno) VALUES ('" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntrySpot()
    {        
        int val = 7;
        var sql = "INSERT INTO PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntrySpot1()
    {
        int val = 8;
        var sql = "INSERT INTO PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntrySpot2()
    {
        int val = 9;
        var sql = "INSERT INTO PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntrySpot3()
    {
        int val = 10;
        var sql = "INSERT INTO PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }
    
    public void DataEntrySpot4()
    {
        int val = 11;
        var sql = "INSERT INTO PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }




    public IEnumerator Ticket1Extractionfreeroom()
    {
        Debug.Log("run this");
        if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 1)
        {
            x = 2;
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 2)
        {
            x = 4;
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 3)
        {
            x = 6;
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 4)
        {
            x = 8;
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 5)
        {
            x = 10;
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 6)
        {
            x = 12;
        }
        var sql = "CREATE TABLE IF NOT EXISTS Jaldi5PlayerTickets (serialno INTEGER PRIMARY KEY AUTOINCREMENT, ticketno VARCHAR(5000))";
        dbManager.Execute(sql);
        Loading.SetActive(true);
        LoadText.SetActive(true);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Ticket2Extractionfreeroom()
    {
        yield return new WaitForSeconds(2);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Ticket3Extractionfreeroom()
    {
        yield return new WaitForSeconds(4);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Ticket4Extractionfreeroom()
    {
        yield return new WaitForSeconds(6);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Ticket5Extractionfreeroom()
    {
        yield return new WaitForSeconds(8);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Ticket6Extractionfreeroom()
    {
        yield return new WaitForSeconds(10);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtraction.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntryfreeroom();
    }

    public IEnumerator Spot1Extractionfreeroom()
    {
        Debug.Log("Run this as well");
        yield return new WaitForSeconds(x);
        var createuser_url = "http://34.121.136.31/housiekings/TicketExtractionspot.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        ticketnumber = cu_get.text;
        DataEntrySpotfreeroom();
        StartCoroutine(UpdateUserCount(_manager.match));
        FreegameStart.SetActive(true);
        Loading.SetActive(false);
        LoadText.SetActive(false);
    }


    public void DataEntryfreeroom()
    {
        var sql = "INSERT INTO Jaldi5PlayerTickets (ticketno) VALUES ('" + ticketnumber + "')";
        dbManager.Execute(sql);
    }

    public void DataEntrySpotfreeroom()
    {
        int val = 7;
        var sql = "INSERT INTO Jaldi5PlayerTickets (serialno ,ticketno) VALUES ( '" + val + "','" + ticketnumber + "')";
        dbManager.Execute(sql);
    }

    private IEnumerator UpdateUserCount(int matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdateUserCount.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    public void FreeroomBackButton()
    {
        _freeroomBack.SetActive(true);
    }

    public void YestoBack()
    {
        var sql = "DROP TABLE IF EXISTS Jaldi5PlayerTickets";
        dbManager.Execute(sql);
        _manager._PurchaseButtonsfreeroom[0].SetActive(true);
        _manager._PurchaseButtonsfreeroom[1].SetActive(true);
        _manager._freeroomLobby.SetActive(false);
        FreegameStart.SetActive(false);
        _freeroomBack.SetActive(false);
    }

    public void NotoBack()
    {
        _freeroomBack.SetActive(false);
    }
}
