using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManagerScene : MonoBehaviour
{
    public GameObject TicketSelection;
    public Dropdown drop;
    void Start()
    {
        TicketSelection.SetActive(true);
    }
    public void BuyTicket()
    {
        if (drop.options[drop.value].text == "1")
        {
            PlayerPrefs.SetInt("NoOfTickets", 1);
            TicketSelection.SetActive(false);
        }
        else if (drop.options[drop.value].text == "2")
        {
            PlayerPrefs.SetInt("NoOfTickets", 2);
            TicketSelection.SetActive(false);
        }
        else if (drop.options[drop.value].text == "3")
        {
            PlayerPrefs.SetInt("NoOfTickets", 3);
            TicketSelection.SetActive(false);
        }
        else if (drop.options[drop.value].text == "4")
        {
            PlayerPrefs.SetInt("NoOfTickets", 4);
            TicketSelection.SetActive(false);
        }
        else if (drop.options[drop.value].text == "5")
        {
            PlayerPrefs.SetInt("NoOfTickets", 5);
            TicketSelection.SetActive(false);
        }
        else if (drop.options[drop.value].text == "6")
        {
            PlayerPrefs.SetInt("NoOfTickets", 6);
            TicketSelection.SetActive(false);
        }
    }
}
