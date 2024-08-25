using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleSQL;
using System.IO;

public class SpotCallingfreeroom : MonoBehaviour
{
    public Text _gamenos;
    public int finalnumber = 0;
    public SimpleSQLManager dbManager;
    private NakamaTest _nakama;
    int[] spotgameno_array = new int[50];

    void Start()
    {
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        var sql = "DROP TABLE IF EXISTS SpotNumberCallingfreeroom";
        dbManager.Execute(sql);
        sql = "CREATE TABLE IF NOT EXISTS SpotNumberCallingfreeroom (serialno INTEGER PRIMARY KEY AUTOINCREMENT, gameno INTEGER(50))";
        dbManager.Execute(sql);
        StartCoroutine(GetSpotGameNumbers(_nakama.freematchid));
    }

    public void SpotNumbercall()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT gameno FROM SpotNumberCallingfreeroom WHERE serialno=(SELECT max(serialno) FROM SpotNumberCallingfreeroom)");
        finalnumber = int.Parse(dt.rows[0][0].ToString());
        var sql = "DELETE FROM SpotNumberCallingfreeroom WHERE serialno = (SELECT Max(serialno) FROM SpotNumberCallingfreeroom)";
        dbManager.Execute(sql);
        _gamenos.text = _gamenos.text + finalnumber.ToString() + ",";
        StartCoroutine(UpdatePlaycheck(_nakama.freematchid, _nakama.USERID));
    }

    private IEnumerator UpdatePlaycheck(string matchid, string userid)
    {
        matchid = "m" + matchid;
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);
        form.AddField("matchid", matchid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/UpdatePlaycheckFreeroom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }

    private IEnumerator GetSpotGameNumbers(string matchid)
    {
        WWWForm form = new WWWForm();
        form.AddField("matchid", matchid);
        WWW download = new WWW("http://34.121.136.31/housiekings/ExtractspotCallingnumberfreeroom.php", form);
        yield return download;
        string spotticketnumber = download.text;
        spotgameno_array = System.Array.ConvertAll(spotticketnumber.Split(','), int.Parse);
        for (int i = 0; i < 90; i++)
        {
            var sql = "INSERT INTO SpotNumberCallingfreeroom (gameno) VALUES ('" + spotgameno_array[i] + "')";
            dbManager.Execute(sql);
        }
    }
}

