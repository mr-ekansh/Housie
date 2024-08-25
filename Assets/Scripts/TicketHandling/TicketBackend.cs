using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleSQL;
using System.IO;
using System;

public class TicketBackend : MonoBehaviour
{
    public Text[] ticket_text;
    public Text[] ticket2_text;
    public Text[] ticket3_text;
    public Text[] ticket4_text;
    public Text[] ticket5_text;
    public Text[] ticket6_text;
    public Text[] SpotTicketJaldi5_text;
    public Text[] SpotTickettopline_text;
    public Text[] SpotTicketmiddleline_text;
    public Text[] SpotTicketbottomline_text;
    public Text[] SpotTicketfullhouse_text;
    public SimpleSQLManager dbManager;
    public int val = 1; 

    public IEnumerator RegisterTicket(string ticket)
    {
        WWWForm form = new WWWForm();
        form.AddField("ticket", ticket);

        using (UnityWebRequest www = UnityWebRequest.Post("http://34.121.136.31/housiekings/CreateFreeRoom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
            }
        }
    }


 
    public void ExtractTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 1");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket_array = new int[50];
        ticket_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket_array[i] > 0 && ticket_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket_text[0].text = ticket_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket_text[1].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[2].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 10 && ticket_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket_text[4].text = ticket_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket_text[5].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[3].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 20 && ticket_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket_text[8].text = ticket_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[6].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[7].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket_array[i] >= 30 && ticket_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket_text[9].text = ticket_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket_text[10].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[11].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 40 && ticket_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket_text[13].text = ticket_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket_text[14].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[12].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 50 && ticket_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket_text[17].text = ticket_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[15].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[16].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket_array[i] >= 60 && ticket_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket_text[18].text = ticket_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket_text[19].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[20].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 70 && ticket_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket_text[22].text = ticket_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket_text[23].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[21].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 80 && ticket_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket_text[26].text = ticket_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[24].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[25].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 1)
        {
            ExtractTicket2();
        }
    }



    public void ExtractTicket2()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 2");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket2_array = new int[50];
        ticket2_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket2_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket2_array[i] > 0 && ticket2_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket2_text[0].text = ticket2_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket2_text[1].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[2].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 10 && ticket2_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket2_text[4].text = ticket2_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket2_text[5].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[3].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 20 && ticket2_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket2_text[8].text = ticket2_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[6].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[7].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket2_array[i] >= 30 && ticket2_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket2_text[9].text = ticket2_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket2_text[10].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[11].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 40 && ticket2_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket2_text[13].text = ticket2_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket2_text[14].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[12].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 50 && ticket2_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket2_text[17].text = ticket2_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[15].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[16].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket2_array[i] >= 60 && ticket2_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket2_text[18].text = ticket2_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket2_text[19].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[20].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 70 && ticket2_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket2_text[22].text = ticket2_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket2_text[23].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[21].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 80 && ticket2_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket2_text[26].text = ticket2_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[24].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[25].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 2)
        {
            ExtractTicket3();
        }
    }



    public void ExtractTicket3()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 3");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket3_array = new int[50];
        ticket3_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket3_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket3_array[i] > 0 && ticket3_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket3_text[0].text = ticket3_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket3_text[1].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[2].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 10 && ticket3_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket3_text[4].text = ticket3_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket3_text[5].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[3].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 20 && ticket3_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket3_text[8].text = ticket3_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[6].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[7].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket3_array[i] >= 30 && ticket3_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket3_text[9].text = ticket3_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket3_text[10].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[11].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 40 && ticket3_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket3_text[13].text = ticket3_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket3_text[14].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[12].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 50 && ticket3_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket3_text[17].text = ticket3_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[15].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[16].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket3_array[i] >= 60 && ticket3_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket3_text[18].text = ticket3_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket3_text[19].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[20].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 70 && ticket3_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket3_text[22].text = ticket3_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket3_text[23].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[21].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 80 && ticket3_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket3_text[26].text = ticket3_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[24].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[25].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 3)
        {
            ExtractTicket4();
        }
    }


    public void ExtractTicket4()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 4");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket4_array = new int[50];
        ticket4_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket4_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket4_array[i] > 0 && ticket4_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket4_text[0].text = ticket4_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket4_text[1].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[2].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 10 && ticket4_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket4_text[4].text = ticket4_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket4_text[5].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[3].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 20 && ticket4_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket4_text[8].text = ticket4_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[6].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[7].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket4_array[i] >= 30 && ticket4_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket4_text[9].text = ticket4_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket4_text[10].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[11].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 40 && ticket4_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket4_text[13].text = ticket4_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket4_text[14].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[12].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 50 && ticket4_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket4_text[17].text = ticket4_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[15].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[16].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket4_array[i] >= 60 && ticket4_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket4_text[18].text = ticket4_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket4_text[19].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[20].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 70 && ticket4_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket4_text[22].text = ticket4_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket4_text[23].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[21].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 80 && ticket4_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket4_text[26].text = ticket4_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[24].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[25].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 4)
        {
            ExtractTicket5();
        }
    }


    public void ExtractTicket5()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 5");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket5_array = new int[50];
        ticket5_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket5_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket5_array[i] > 0 && ticket5_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket5_text[0].text = ticket5_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket5_text[1].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[2].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 10 && ticket5_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket5_text[4].text = ticket5_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket5_text[5].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[3].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 20 && ticket5_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket5_text[8].text = ticket5_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[6].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[7].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket5_array[i] >= 30 && ticket5_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket5_text[9].text = ticket5_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket5_text[10].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[11].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 40 && ticket5_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket5_text[13].text = ticket5_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket5_text[14].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[12].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 50 && ticket5_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket5_text[17].text = ticket5_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[15].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[16].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket5_array[i] >= 60 && ticket5_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket5_text[18].text = ticket5_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket5_text[19].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[20].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 70 && ticket5_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket5_text[22].text = ticket5_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket5_text[23].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[21].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 80 && ticket5_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket5_text[26].text = ticket5_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[24].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[25].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 5)
        {
            ExtractTicket6();
        }
    }


    public void ExtractTicket6()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 6");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket6_array = new int[50];
        ticket6_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket6_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket6_array[i] > 0 && ticket6_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket6_text[0].text = ticket6_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket6_text[1].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[2].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 10 && ticket6_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket6_text[4].text = ticket6_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket6_text[5].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[3].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 20 && ticket6_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket6_text[8].text = ticket6_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[6].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[7].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket6_array[i] >= 30 && ticket6_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket6_text[9].text = ticket6_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket6_text[10].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[11].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 40 && ticket6_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket6_text[13].text = ticket6_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket6_text[14].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[12].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 50 && ticket6_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket6_text[17].text = ticket6_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[15].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[16].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket6_array[i] >= 60 && ticket6_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket6_text[18].text = ticket6_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket6_text[19].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[20].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 70 && ticket6_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket6_text[22].text = ticket6_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket6_text[23].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[21].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 80 && ticket6_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket6_text[26].text = ticket6_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[24].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[25].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractjaldiTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 7");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketJaldi5_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketJaldi5_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketJaldi5_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketJaldi5_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketJaldi5_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketJaldi5_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtracttoplineTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 8");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTickettopline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTickettopline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTickettopline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTickettopline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTickettopline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTickettopline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTickettopline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTickettopline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTickettopline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTickettopline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTickettopline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTickettopline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTickettopline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTickettopline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTickettopline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractmiddlelineTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 9");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketmiddleline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketmiddleline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketmiddleline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketmiddleline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketmiddleline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketmiddleline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractbottomlineTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 10");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketbottomline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketbottomline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketbottomline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketbottomline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketbottomline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketbottomline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractfullhouseTicket()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTickets WHERE serialno = 11");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketfullhouse_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketfullhouse_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketfullhouse_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketfullhouse_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketfullhouse_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketfullhouse_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }public void ExtractTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 1");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket_array = new int[50];
        ticket_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket_array[i] > 0 && ticket_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket_text[0].text = ticket_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket_text[1].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[2].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 10 && ticket_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket_text[4].text = ticket_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket_text[5].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[3].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 20 && ticket_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket_text[8].text = ticket_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[6].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[7].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket_array[i] >= 30 && ticket_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket_text[9].text = ticket_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket_text[10].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[11].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 40 && ticket_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket_text[13].text = ticket_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket_text[14].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[12].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 50 && ticket_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket_text[17].text = ticket_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[15].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[16].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket_array[i] >= 60 && ticket_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket_text[18].text = ticket_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket_text[19].text = ticket_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket_text[20].text = ticket_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket_array[i] >= 70 && ticket_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket_text[22].text = ticket_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket_text[23].text = ticket_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket_text[21].text = ticket_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket_array[i] >= 80 && ticket_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket_text[26].text = ticket_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket_text[24].text = ticket_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket_text[25].text = ticket_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 1)
        {
            ExtractTicket2voucher();
        }
    }



    public void ExtractTicket2voucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 2");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket2_array = new int[50];
        ticket2_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket2_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket2_array[i] > 0 && ticket2_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket2_text[0].text = ticket2_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket2_text[1].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[2].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 10 && ticket2_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket2_text[4].text = ticket2_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket2_text[5].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[3].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 20 && ticket2_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket2_text[8].text = ticket2_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[6].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[7].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket2_array[i] >= 30 && ticket2_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket2_text[9].text = ticket2_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket2_text[10].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[11].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 40 && ticket2_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket2_text[13].text = ticket2_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket2_text[14].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[12].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 50 && ticket2_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket2_text[17].text = ticket2_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[15].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[16].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket2_array[i] >= 60 && ticket2_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket2_text[18].text = ticket2_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket2_text[19].text = ticket2_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket2_text[20].text = ticket2_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket2_array[i] >= 70 && ticket2_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket2_text[22].text = ticket2_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket2_text[23].text = ticket2_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket2_text[21].text = ticket2_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket2_array[i] >= 80 && ticket2_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket2_text[26].text = ticket2_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket2_text[24].text = ticket2_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket2_text[25].text = ticket2_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 2)
        {
            ExtractTicket3voucher();
        }
    }



    public void ExtractTicket3voucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 3");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket3_array = new int[50];
        ticket3_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket3_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket3_array[i] > 0 && ticket3_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket3_text[0].text = ticket3_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket3_text[1].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[2].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 10 && ticket3_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket3_text[4].text = ticket3_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket3_text[5].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[3].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 20 && ticket3_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket3_text[8].text = ticket3_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[6].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[7].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket3_array[i] >= 30 && ticket3_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket3_text[9].text = ticket3_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket3_text[10].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[11].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 40 && ticket3_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket3_text[13].text = ticket3_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket3_text[14].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[12].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 50 && ticket3_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket3_text[17].text = ticket3_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[15].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[16].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket3_array[i] >= 60 && ticket3_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket3_text[18].text = ticket3_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket3_text[19].text = ticket3_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket3_text[20].text = ticket3_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket3_array[i] >= 70 && ticket3_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket3_text[22].text = ticket3_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket3_text[23].text = ticket3_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket3_text[21].text = ticket3_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket3_array[i] >= 80 && ticket3_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket3_text[26].text = ticket3_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket3_text[24].text = ticket3_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket3_text[25].text = ticket3_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 3)
        {
            ExtractTicket4voucher();
        }
    }


    public void ExtractTicket4voucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 4");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket4_array = new int[50];
        ticket4_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket4_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket4_array[i] > 0 && ticket4_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket4_text[0].text = ticket4_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket4_text[1].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[2].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 10 && ticket4_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket4_text[4].text = ticket4_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket4_text[5].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[3].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 20 && ticket4_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket4_text[8].text = ticket4_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[6].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[7].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket4_array[i] >= 30 && ticket4_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket4_text[9].text = ticket4_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket4_text[10].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[11].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 40 && ticket4_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket4_text[13].text = ticket4_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket4_text[14].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[12].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 50 && ticket4_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket4_text[17].text = ticket4_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[15].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[16].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket4_array[i] >= 60 && ticket4_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket4_text[18].text = ticket4_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket4_text[19].text = ticket4_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket4_text[20].text = ticket4_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket4_array[i] >= 70 && ticket4_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket4_text[22].text = ticket4_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket4_text[23].text = ticket4_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket4_text[21].text = ticket4_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket4_array[i] >= 80 && ticket4_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket4_text[26].text = ticket4_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket4_text[24].text = ticket4_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket4_text[25].text = ticket4_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 4)
        {
            ExtractTicket5voucher();
        }
    }


    public void ExtractTicket5voucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 5");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket5_array = new int[50];
        ticket5_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket5_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket5_array[i] > 0 && ticket5_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket5_text[0].text = ticket5_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket5_text[1].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[2].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 10 && ticket5_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket5_text[4].text = ticket5_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket5_text[5].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[3].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 20 && ticket5_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket5_text[8].text = ticket5_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[6].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[7].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket5_array[i] >= 30 && ticket5_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket5_text[9].text = ticket5_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket5_text[10].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[11].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 40 && ticket5_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket5_text[13].text = ticket5_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket5_text[14].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[12].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 50 && ticket5_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket5_text[17].text = ticket5_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[15].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[16].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket5_array[i] >= 60 && ticket5_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket5_text[18].text = ticket5_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket5_text[19].text = ticket5_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket5_text[20].text = ticket5_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket5_array[i] >= 70 && ticket5_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket5_text[22].text = ticket5_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket5_text[23].text = ticket5_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket5_text[21].text = ticket5_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket5_array[i] >= 80 && ticket5_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket5_text[26].text = ticket5_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket5_text[24].text = ticket5_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket5_text[25].text = ticket5_array[i].ToString();
                    ++r2;
                }
            }
        }
        if(val > 5)
        {
            ExtractTicket6voucher();
        }
    }


    public void ExtractTicket6voucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 6");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket6_array = new int[50];
        ticket6_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket6_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket6_array[i] > 0 && ticket6_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    ticket6_text[0].text = ticket6_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    ticket6_text[1].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[2].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 10 && ticket6_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    ticket6_text[4].text = ticket6_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    ticket6_text[5].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[3].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 20 && ticket6_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    ticket6_text[8].text = ticket6_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[6].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[7].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket6_array[i] >= 30 && ticket6_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    ticket6_text[9].text = ticket6_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket6_text[10].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[11].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 40 && ticket6_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    ticket6_text[13].text = ticket6_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket6_text[14].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[12].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 50 && ticket6_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    ticket6_text[17].text = ticket6_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[15].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[16].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket6_array[i] >= 60 && ticket6_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    ticket6_text[18].text = ticket6_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    ticket6_text[19].text = ticket6_array[i].ToString();
                    ++r2;
                }
                else
                {
                    ticket6_text[20].text = ticket6_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket6_array[i] >= 70 && ticket6_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    ticket6_text[22].text = ticket6_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    ticket6_text[23].text = ticket6_array[i].ToString();
                    ++r3;
                }
                else
                {
                    ticket6_text[21].text = ticket6_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket6_array[i] >= 80 && ticket6_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    ticket6_text[26].text = ticket6_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    ticket6_text[24].text = ticket6_array[i].ToString();
                    ++r1;
                }
                else
                {
                    ticket6_text[25].text = ticket6_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractjaldiTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 7");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketJaldi5_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketJaldi5_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketJaldi5_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketJaldi5_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketJaldi5_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketJaldi5_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketJaldi5_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketJaldi5_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketJaldi5_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketJaldi5_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketJaldi5_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketJaldi5_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketJaldi5_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtracttoplineTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 8");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTickettopline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTickettopline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTickettopline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTickettopline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTickettopline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTickettopline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTickettopline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTickettopline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTickettopline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTickettopline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTickettopline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTickettopline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTickettopline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTickettopline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTickettopline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTickettopline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTickettopline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTickettopline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTickettopline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractmiddlelineTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 9");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketmiddleline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketmiddleline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketmiddleline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketmiddleline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketmiddleline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketmiddleline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketmiddleline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketmiddleline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketmiddleline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketmiddleline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketmiddleline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketmiddleline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketmiddleline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractbottomlineTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 10");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketbottomline_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketbottomline_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketbottomline_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketbottomline_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketbottomline_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketbottomline_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketbottomline_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketbottomline_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketbottomline_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketbottomline_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketbottomline_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketbottomline_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketbottomline_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }


    public void ExtractfullhouseTicketvoucher()
    {
        SimpleSQL.SimpleDataTable dt = dbManager.QueryGeneric("SELECT ticketno FROM PlayerTicketsvoucher WHERE serialno = 11");
        string ticketnumber = dt.rows[0][0].ToString();
        int[] ticket7_array = new int[50];
        ticket7_array = System.Array.ConvertAll(ticketnumber.Split(','), int.Parse);
        Array.Sort(ticket7_array);
        int a1 = 0,b1 = 0,c1 = 0,d1 = 0,e1 = 0,f1 = 0,g1 = 0,h1 = 0,j1 = 0;
        int r1 = 0, r2 = 0, r3 = 0;
        for (int i = 0; i < 18; i++)
        {
            if (ticket7_array[i] > 0 && ticket7_array[i] <= 9)
            {
                if (a1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[0].text = ticket7_array[i].ToString();
                    ++a1;
                    ++r1;
                }
                else if(r2 < 5)
                {
                    SpotTicketfullhouse_text[1].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[2].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 10 && ticket7_array[i] <= 19)
            {
                if (b1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[4].text = ticket7_array[i].ToString();
                    ++b1;
                    ++r2;
                }
                else if(r3 < 5)
                {
                    SpotTicketfullhouse_text[5].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[3].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 20 && ticket7_array[i] <= 29)
            {
                if (c1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[8].text = ticket7_array[i].ToString();
                    ++c1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[6].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[7].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 30 && ticket7_array[i] <= 39)
            {
                if (d1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[9].text = ticket7_array[i].ToString();
                    ++d1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketfullhouse_text[10].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[11].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 40 && ticket7_array[i] <= 49)
            {
                if (e1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[13].text = ticket7_array[i].ToString();
                    ++e1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketfullhouse_text[14].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[12].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 50 && ticket7_array[i] <= 59)
            {
                if (f1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[17].text = ticket7_array[i].ToString();
                    ++f1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[15].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[16].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
            else if (ticket7_array[i] >= 60 && ticket7_array[i] <= 69)
            {
                if (g1 == 0 && r1<5)
                {
                    SpotTicketfullhouse_text[18].text = ticket7_array[i].ToString();
                    ++g1;
                    ++r1;
                }
                else if(r2<5)
                {
                    SpotTicketfullhouse_text[19].text = ticket7_array[i].ToString();
                    ++r2;
                }
                else
                {
                    SpotTicketfullhouse_text[20].text = ticket7_array[i].ToString();
                    ++r3;
                }
            }
            else if (ticket7_array[i] >= 70 && ticket7_array[i] <= 79)
            {
                if (h1 == 0 && r2<5)
                {
                    SpotTicketfullhouse_text[22].text = ticket7_array[i].ToString();
                    ++h1;
                    ++r2;
                }
                else if(r3<5)
                {
                    SpotTicketfullhouse_text[23].text = ticket7_array[i].ToString();
                    ++r3;
                }
                else
                {
                    SpotTicketfullhouse_text[21].text = ticket7_array[i].ToString();
                    ++r1;
                }
            }
            else if (ticket7_array[i] >= 80 && ticket7_array[i] <= 90)
            {
                if (j1 == 0 && r3<5)
                {
                    SpotTicketfullhouse_text[26].text = ticket7_array[i].ToString();
                    ++j1;
                    ++r3;
                }
                else if(r1<5)
                {
                    SpotTicketfullhouse_text[24].text = ticket7_array[i].ToString();
                    ++r1;
                }
                else
                {
                    SpotTicketfullhouse_text[25].text = ticket7_array[i].ToString();
                    ++r2;
                }
            }
        }
    }
}
