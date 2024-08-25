using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleSQL;
using System.IO;

public class GameCall : MonoBehaviour
{
    public AudioClip[] _audios;
    public AudioSource _source;
    public int finalnumber = 0;
    private GameChecker _gamechecker;
    public GameObject[] gameboard;
    public SimpleSQLManager dbManager;
    public Transform boardposition;
    public GameObject ShowButton;
    public GameObject _board;
    void Start()
    {
        _board.SetActive(true);
        boardposition.transform.position = new Vector3(boardposition.transform.position.x + 3000, boardposition.transform.position.y, 0);
        var sql = "CREATE TABLE IF NOT EXISTS NumberCalling (serialno INTEGER PRIMARY KEY AUTOINCREMENT, gameno INTEGER(50))";
        dbManager.Execute(sql);
        StartCoroutine(GetGameNumbers());
        _gamechecker = GameObject.FindWithTag("GameChecking").GetComponent<GameChecker>();
    }

    public void Numbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM NumberCalling WHERE serialno=(SELECT max(serialno) FROM NumberCalling)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM NumberCalling WHERE serialno = (SELECT Max(serialno) FROM NumberCalling)";
        dbManager.Execute(sql);
        _source.clip = _audios[finalnumber - 1];
        _source.Play();
        gameboard[finalnumber - 1].SetActive(true);
    }
    
    public void SpotUpdateNumbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM NumberCalling WHERE serialno=(SELECT max(serialno) FROM NumberCalling)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM NumberCalling WHERE serialno = (SELECT Max(serialno) FROM NumberCalling)";
        dbManager.Execute(sql);
        gameboard[finalnumber - 1].SetActive(true);
    }

    public IEnumerator GetGameNumbers()
    {
        var createuser_url = "http://34.121.136.31/housiekings/Extractgamecallno.php";
        var cu_get = new WWW(createuser_url);
        yield return cu_get;
        string ticketnumber = cu_get.text;
        int[] gameno_array = new int[50];
        gameno_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        for (int i = 0; i < 90; i++)
        {
            var sql = "INSERT INTO NumberCalling (gameno) VALUES ('" + gameno_array[i] + "')";
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
}

