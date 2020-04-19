using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BezierSolution;
using UnityEngine.Events;
public class testingBezier : MonoBehaviour
{
    private float seconds = 0;
    private float timer = 0;

    private Transform cachedTransform;

    static public bool isBottomSpline;
    [SerializeField] public BezierSpline splineBottom;
    [SerializeField] public BezierSpline splineTop;

    public float progress = 1f;
    public float NormalizedT
    {
        get { return progress; }
        set { progress = value; }
    }

    public bool lookForward = true;

    private bool isGoingForward = true;
    public bool MovingForward { get { return isGoingForward; } }

    public UnityEvent onProgressChanged = new UnityEvent();

    private void Awake()
    {
        cachedTransform = transform;
    }

    void Start()
    {
        // starts on the ground
        isBottomSpline = true;
    }

    private void Update()
    {

        // On the ground
        if (isBottomSpline == true)
        {
            cachedTransform.position = cachedTransform.position;

            bool movingForward = MovingForward;

            //Debug.Log("1 + isBottomSpline = " + isBottomSpline);

        }
        else //if mid-jump
        {
            //timer used to determine how long the car has been in the air
            timer += Time.deltaTime;
            seconds = timer % 60; // convert deltaTime to seconds

            // position of car in air
            cachedTransform.position = Vector3.Lerp(cachedTransform.position, splineTop.GetPoint(progress), Time.deltaTime);
            bool movingForward = MovingForward;

            //Debug.Log("2 + isBottomSpline = " + isBottomSpline);

            // The car is in the air for 0.1 of a second
            // if longer, land on ground
            if (seconds > 0.15)
            {
                toggleSpline();
                timer = 0;
            }

        }

        // when space -> jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key was pressed - bottom");
            toggleSpline();
        }
    }

    //This method changes spline when called
    public void toggleSpline()
    {
        if (isBottomSpline == true)
        {
            isBottomSpline = false;
            cachedTransform.position = Vector3.Lerp(cachedTransform.position, splineTop.GetPoint(progress), Time.deltaTime);
        }
        else
        {
            isBottomSpline = true;
            cachedTransform.position = Vector3.Lerp(cachedTransform.position, splineBottom.GetPoint(progress), Time.deltaTime);
        }
    }
}