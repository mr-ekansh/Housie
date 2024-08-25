using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketExtractionJaldi5 : MonoBehaviour
{
    private TicketBackendJaldi5 _ticketbackend;
    public GameObject[] Tickets;
    void Start()
    {
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackendJaldi5>();
        Tickets[0].SetActive(false);
        Tickets[1].SetActive(false);
        Tickets[2].SetActive(false);
        Tickets[3].SetActive(false);
        Tickets[4].SetActive(false);
        Tickets[5].SetActive(false);
        _ticketbackend.val = 1;
        Ticketdisplay();
    }
    private void Ticketdisplay()
    {
        if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 1)
        {
            Tickets[0].SetActive(true);
            _ticketbackend.val = 1;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 2)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            _ticketbackend.val = 2;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 3)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            _ticketbackend.val = 3;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 4)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            _ticketbackend.val = 4;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 5)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            Tickets[4].SetActive(true);
            _ticketbackend.val = 5;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("Jaldi5NoOfTickets") == 6)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            Tickets[4].SetActive(true);
            Tickets[5].SetActive(true);
            _ticketbackend.val = 6;
            _ticketbackend.ExtractTicket();
        }
    }
}
