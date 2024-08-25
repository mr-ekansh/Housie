using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class fetchwinnersMiddleline : MonoBehaviour
{
    public Text usernames;
    public IEnumerator fetchwinners()
    {
        while(true)
        {
            WWWForm form = new WWWForm();
            WWW download = new WWW("http://34.121.136.31/housiekings/usernamemiddleline.php", form);
            yield return download;
            string winners = download.text.ToString();
            winners = Regex.Replace(winners, "<br />", "");
            usernames.text = winners;
            yield return new WaitForSeconds(3);
        }
    }
}
