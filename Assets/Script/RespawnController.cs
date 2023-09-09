using UnityEngine;
using System.Collections.Generic;

public class RespawnController : MonoBehaviour
{
    public GameObject ballPrefab; 
    public Transform spawnPoint; 

    private List<GameObject> activeBalls = new List<GameObject>(); 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        activeBalls.Add(newBall);
    }

    public void BallDestroyed(GameObject ball)
    {
        if (activeBalls.Contains(ball))
        {
            activeBalls.Remove(ball);
        }
    }

    public void ResetBallPosition(GameObject ball)
    {
        ball.transform.position = spawnPoint.position;
    }
}
