using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerManager : MonoBehaviour, GameManager
{
    public ManagerStatus status { get; private set; }
    public PlayerController playerControl;
    public Animator animatorPlayer;
    public int health { get; private set; }
    public int maxHealth { get; private set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");
        health = 50;
        maxHealth = 100;
        status = ManagerStatus.Started;
    }
    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Health: " + health + "/" + maxHealth);
    }

    public void setAnimToPlay(string triggerName)
    {
        animatorPlayer.SetTrigger(triggerName);
    }
}