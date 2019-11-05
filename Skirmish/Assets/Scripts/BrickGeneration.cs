using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGeneration : MonoBehaviour
{
    public int numberOfBricks = 8;
    private float startXPosition = -2.5f;
    public GameObject brickPrefab;
    void Start()
    {
        for(int i = 0; i < numberOfBricks; i++)
        {
            Vector2 brickPosition = new Vector2(startXPosition + i, 0f);
            Instantiate(brickPrefab, brickPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
