using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOver gameOver;
    public win winn;

    public void GameOver()
    {
        gameOver.Setup();
        Debug.Log("Game Over");
    }

    public void win()
    {
        winn.Setup();
        Debug.Log("winner");
    }
}
