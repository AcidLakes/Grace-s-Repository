using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myObstacles : MonoBehaviour
{
    public int ScoreValue { get { return ScoreValue; } }
    [SerializeField] private int obValue = 5;

    public delegate void HitObstacle(myObstacles obstacle);
    public static HitObstacle HitObstacleEvent;

    private GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider hitMe)
    {
        var player = hitMe.GetComponent<Player>();

        if (player)
        {
            Debug.Log("Hit obstacle!");
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
