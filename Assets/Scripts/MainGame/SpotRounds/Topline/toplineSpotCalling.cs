using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleSQL;
using System.IO;

public class toplineSpotCalling : MonoBehaviour
{
    public Text _gamenos;
    public int finalnumber = 0;
    public SimpleSQLManager dbManager;
    private NakamaTest _nakama;

    void Start()
    {
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        var sql = "CREATE TABLE IF NOT EXISTS toplineSpotNumberCalling (serialno INTEGER PRIMARY KEY AUTOINCREMENT, gameno INTEGER(50))";
        dbManager.Execute(sql);
        StartCoroutine(GetSpotGameNumbers());
    }

    public void SpotNumbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM toplineSpotNumberCalling WHERE serialno=(SELECT max(serialno) FROM toplineSpotNumberCalling)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM toplineSpotNumberCalling WHERE serialno = (SELECT Max(serialno) FROM toplineSpotNumberCalling)";
        dbManager.Execute(sql);
        _gamenos.text = _gamenos.text + finalnumber.ToString() + ",";
        StartCoroutine(Updatenumber(_nakama.USERID));
    }

    public IEnumerator GetSpotGameNumbers()
    {
        var createuser_url = "http://34.121.136.31/housiekings/toplineExtractSpotGameNumbers.php";
        var cu_spotget = new WWW(createuser_url);
        yield return cu_spotget;
        string spotticketnumber = cu_spotget.text;
        int[] spotgameno_array = new int[50];
        spotgameno_array = System.Array.ConvertAll(spotticketnumber.Split(','), int.Parse);
        for (int i = 0; i < 90; i++)
        {
            var sql = "INSERT INTO toplineSpotNumberCalling (gameno) VALUES ('" + spotgameno_array[i] + "')";
            dbManager.Execute(sql);
        }
    }

    public IEnumerator Updatenumber(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/toplineUpdateSpotNumber.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
        }
    }
}

