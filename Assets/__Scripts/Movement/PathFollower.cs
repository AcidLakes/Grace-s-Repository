using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    Node[] pathNode;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timer;
    private int currentNode, nextNode;
    static Vector3 currentPosition;
    static Vector3 futurePosition;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //get all children that have a Node script
        pathNode = GetComponentsInChildren<Node>();
        checkNode();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        MovePlayer();
        //FaceMoveDirection();
    }

    void MovePlayer()
    {
        Debug.Log(currentNode);
        timer += Time.deltaTime * moveSpeed;
        if (player.transform.position != currentPosition)
        {
            nextNode = currentNode + 1;
            player.transform.position = Vector3.Lerp(player.transform.position, currentPosition, timer);
            //Lerp = value will change from from value to  to value over timer

            if (currentNode+1 == pathNode.Length)
            {
                nextNode = 0;
            }
            player.transform.LookAt(pathNode[nextNode].transform.position);
            player.transform.Rotate(0, 90, 0);
        }
        else
        {
            if (currentNode < pathNode.Length - 1)
            {
                currentNode++;
                checkNode();
            }
            else
            {
                currentNode = 0;
                checkNode();
            }
        }
    }
    void checkNode()
    {
        if(currentNode<pathNode.Length-1)
            timer = 0;
        currentPosition = pathNode[currentNode].transform.position;
    }
    void DrawLine()
    {
        for(int i = 0; i<pathNode.Length; i++)
        {
            if(i<pathNode.Length - 1)
            {
                Debug.DrawLine(pathNode[i].transform.position, pathNode[i + 1].transform.position, Color.red);
                //only draws the line following path in scene view not game view
            }
            
        }
    }
    public void FaceMoveDirection()
    {
        
        Vector3 diff = target.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        //player.transform.rotation = ;
        player.transform.Rotate(0f, 0f, rot_z - 90);
    }
}

//https://forum.unity.com/threads/move-gameobject-along-a-given-path.455195/
