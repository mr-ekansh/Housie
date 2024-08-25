using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleSQL;
using System.IO;
using UnityEngine.SceneManagement;

public class GameCallFreeroom : MonoBehaviour
{
    public int finalnumber = 0;

    public GameObject[] gameboard;
    public SimpleSQLManager dbManager;
    public Transform boardposition;
    public GameObject ShowButton;
    public GameObject _board;
    public GameObject _quitPanel;
    private NakamaTest _nakama;
    public GameObject Manager;

    void Start()
    {
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _quitPanel.SetActive(false);
        _board.SetActive(true);
        boardposition.transform.position = new Vector3(boardposition.transform.position.x + 3000, boardposition.transform.position.y, 0);
        var sql = "DROP TABLE IF EXISTS FreeRoomNumberCalling";
        dbManager.Execute(sql);
        sql = "CREATE TABLE IF NOT EXISTS FreeRoomNumberCalling (serialno INTEGER PRIMARY KEY AUTOINCREMENT, gameno INTEGER(50))";
        dbManager.Execute(sql);
        StartCoroutine(GetGameNumbers(_nakama.freematchid));
    }

    public void Numbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM FreeRoomNumberCalling WHERE serialno=(SELECT max(serialno) FROM FreeRoomNumberCalling)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM FreeRoomNumberCalling WHERE serialno = (SELECT Max(serialno) FROM FreeRoomNumberCalling)";
        dbManager.Execute(sql);
        gameboard[finalnumber - 1].SetActive(true);
    }

    public void SpotUpdateNumbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM FreeRoomNumberCalling WHERE serialno=(SELECT max(serialno) FROM FreeRoomNumberCalling)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM FreeRoomNumberCalling WHERE serialno = (SELECT Max(serialno) FROM FreeRoomNumberCalling)";
        dbManager.Execute(sql);
        gameboard[finalnumber - 1].SetActive(true);
    }

    public IEnumerator GetGameNumbers(string matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractCallingnumberfreeroom.php", form);
        yield return download;
        string ticketnumber = download.text;
        int[] gameno_array = new int[50];
        gameno_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        for (int i = 0; i < 90; i++)
        {
            var sql = "INSERT INTO FreeRoomNumberCalling (gameno) VALUES ('" + gameno_array[i] + "')";
            dbManager.Execute(sql);
        }
    }

    public void ShowBoard()
    {
        boardposition.transform.position = new Vector3(boardposition.transform.position.x - 3000, boardposition.transform.position.y, 0);
        ShowButton.SetActive(false);
    }

    public void HideBoard()
    {
        boardposition.transform.position = new Vector3(boardposition.transform.position.x + 3000, boardposition.transform.position.y, 0);
        ShowButton.SetActive(true);
    }

    public void Endgame()
    {
        _nakama.leavematch();
        _nakama.leavematch();
        Destroy(Manager);
        SceneManager.LoadScene("Loading");
    }

    public void QuitButton()
    {
        _quitPanel.SetActive(true);
    }

    public void Yesbutton()
    {        
        _nakama.leavematch();
        _nakama.leavematch();
        Destroy(Manager);
        SceneManager.LoadScene("Loading");
    }

    public void Nobutton()
    {
        _quitPanel.SetActive(false);
    }
}

