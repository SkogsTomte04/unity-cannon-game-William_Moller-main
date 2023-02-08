using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Player> players = new List<Player>();
    int currentPlayer = 0;

    void Start()
    {
        players.AddRange(FindObjectsOfType<Player>());
        for (int i = 0; i < players.Count; i++)
        {
            SetTankState(false, i);
        }
        SetTankState(true, currentPlayer);
    }

    private void SetTankState(bool state, int tank)
    {
        players[tank].enabled = state;
        players[tank].playerCamera.gameObject.SetActive(state);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SetTankState(false, currentPlayer);
            currentPlayer += 1;
            if (currentPlayer >= players.Count)
            {
                currentPlayer = 0;
            }
            SetTankState(true, currentPlayer);

        }
        checkHealth();
    }

    void checkHealth()
    {
        foreach (Player player in players)
        {
            player.healthBar.UpdateHealth(player.maxHealth, player.currentHealth);
            
            
            if(player != null)
            {
                if (player.currentHealth <= 0)
                {
                    Destroy(player.gameObject);
                    players.Remove(player);
                }
            }
        }
    }
}
