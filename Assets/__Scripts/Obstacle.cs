using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int DamageValue
    {
        get { return damageValue; }
        set { damageValue = value; }
    }
    private int damageValue;
    //public int Hits { get { return hit; } }

    public delegate void HitObstacle(Obstacle obstacle);
    public static HitObstacle HitObstacleEvent;

    private LifeCounter lc;
    private GameController gc;
    //private int hit = 0;
    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        lc = FindObjectOfType<LifeCounter>();
    }
    private void OnTriggerEnter(Collider hitMe)
    {
        var player = hitMe.GetComponent<Player>();

        if (player)
        {
            Debug.Log("Hit obstacle!");
            //hit++;
            gc.LoseOneLife();
            lc.updateLives();
            PublishHitObstacleEvent();
        }
    }
    private void PublishHitObstacleEvent()
    {
        if(HitObstacleEvent != null)
        {
            HitObstacleEvent(this);
        }
    }
}