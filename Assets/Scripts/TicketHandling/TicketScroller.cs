using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketScroller : MonoBehaviour
{
    public GameObject[] Ticket;
    int i = 0;
    public Text ticketno;

    void Start()
    {
        Ticket[0].transform.position = new Vector3(Ticket[0].transform.position.x, Ticket[0].transform.position.y, 0);
        Ticket[1].transform.position = new Vector3(Ticket[0].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
        Ticket[2].transform.position = new Vector3(Ticket[0].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
        Ticket[3].transform.position = new Vector3(Ticket[0].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
        Ticket[4].transform.position = new Vector3(Ticket[0].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
        Ticket[5].transform.position = new Vector3(Ticket[0].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
    }

    public void RightScroll()
    {
        if (i < 5 && Ticket[i+1].activeSelf == true)
        {
            Ticket[i+1].transform.position = new Vector3(Ticket[i].transform.position.x, Ticket[0].transform.position.y, 0);
            Ticket[i].transform.position = new Vector3(Ticket[i].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
            i++;
            ticketno.text = (i + 1).ToString();
        }
    }


    public void LeftScroll()
    {
        if(i>0)
        {
            Ticket[i-1].transform.position = new Vector3(Ticket[i].transform.position.x, Ticket[0].transform.position.y, 0);
            Ticket[i].transform.position = new Vector3(Ticket[i].transform.position.x + 5000, Ticket[0].transform.position.y, 0);
            ticketno.text = (i).ToString();
            i--;
        }
    }
}
