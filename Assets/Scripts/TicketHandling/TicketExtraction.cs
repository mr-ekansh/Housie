using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketExtraction : MonoBehaviour
{
    private TicketBackend _ticketbackend;
    public GameObject[] Tickets;
    public NakamaTest nakama;
    void Start()
    {
        _ticketbackend = GameObject.FindWithTag("TicketHandling").GetComponent<TicketBackend>();
        Tickets[0].SetActive(false);
        Tickets[1].SetActive(false);
        Tickets[2].SetActive(false);
        Tickets[3].SetActive(false);
        Tickets[4].SetActive(false);
        Tickets[5].SetActive(false);
        _ticketbackend.val = 1;
        Debug.Log(nakama.isvoucher.ToString());
        if(nakama.isvoucher==true)
        {
            Ticketdisplayvoucher();
        }
        else
        {
            Ticketdisplay();
        }
    }
    private void Ticketdisplay()
    {
        if (PlayerPrefs.GetInt("NoOfTickets") == 1)
        {
            Tickets[0].SetActive(true);
            _ticketbackend.val = 1;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("NoOfTickets") == 2)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            _ticketbackend.val = 2;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("NoOfTickets") == 3)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            _ticketbackend.val = 3;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("NoOfTickets") == 4)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            _ticketbackend.val = 4;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("NoOfTickets") == 5)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            Tickets[4].SetActive(true);
            _ticketbackend.val = 5;
            _ticketbackend.ExtractTicket();
        }
        else if (PlayerPrefs.GetInt("NoOfTickets") == 6)
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

    private void Ticketdisplayvoucher()
    {
        if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 1)
        {
            Tickets[0].SetActive(true);
            _ticketbackend.val = 1;
            _ticketbackend.ExtractTicketvoucher();
        }
        else if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 2)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            _ticketbackend.val = 2;
            _ticketbackend.ExtractTicketvoucher();
        }
        else if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 3)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            _ticketbackend.val = 3;
            _ticketbackend.ExtractTicketvoucher();
        }
        else if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 4)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            _ticketbackend.val = 4;
            _ticketbackend.ExtractTicketvoucher();
        }
        else if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 5)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            Tickets[4].SetActive(true);
            _ticketbackend.val = 5;
            _ticketbackend.ExtractTicketvoucher();
        }
        else if (PlayerPrefs.GetInt("NoOfTicketsvoucher") == 6)
        {
            Tickets[0].SetActive(true);
            Tickets[1].SetActive(true);
            Tickets[2].SetActive(true);
            Tickets[3].SetActive(true);
            Tickets[4].SetActive(true);
            Tickets[5].SetActive(true);
            _ticketbackend.val = 6;
            _ticketbackend.ExtractTicketvoucher();
        }
    }
}
