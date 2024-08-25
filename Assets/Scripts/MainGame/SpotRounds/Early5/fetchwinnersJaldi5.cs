using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class fetchwinnersJaldi5 : MonoBehaviour
{
    public Text usernames;
    public IEnumerator fetchwinners()
    {
        while(true)
        {
            WWWForm form = new WWWForm();
            WWW download = new WWW("http://34.121.136.31/housiekings/usernamesjaldi5.php", form);
            yield return download;
            string winners = download.text.ToString();
            winners = Regex.Replace(winners, "<br />", "");
            usernames.text = winners;
            yield return new WaitForSeconds(3);
        }
    }
}
