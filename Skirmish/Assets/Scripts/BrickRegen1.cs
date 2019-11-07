using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickRegen1 : MonoBehaviour
{
    //Pool of bricks based on width of screen
    //Two rows of bricks
    //Alternate positions of bricks
    public GameObject brickPrefab;
    public int rowNum = 2;
    public int colNum;
    private GameObject[] bricks;
    private RespawnTime[] respawnTimeList;
    private float spawnXPosition;
    private float currentX;
    private float currentY;
    private float positionYOffset = 0.05f;
    private float positionXOffset = 0.02f;
    private float brickHeight = 0.5f;
    private float brickWidth = 0.5f;
    private int poolSize;

    // Start is called before the first frame update
    void Start()
    {
        //Calculate number of bricks in a row based on screen size. 
        //This ensures that while there may be extra bricks out of the screen, there will never be fewer bricks leading to gaps
        colNum = (int)((Camera.main.orthographicSize * 2 * Camera.main.aspect) / 0.5f);
        poolSize = rowNum * colNum;
        float rowHeight = brickHeight + positionYOffset;
        float colWidth = brickWidth + positionXOffset;
        bricks = new GameObject[poolSize];
        respawnTimeList = new RespawnTime[poolSize];
        float totalBrickHeight = (rowNum * brickHeight) + (rowNum - 1) * positionYOffset; 
        currentY = (brickHeight / 2) - (totalBrickHeight / 2);
        int brickCount = 0;
        for (int i = 0; i < rowNum; i++)
        {
            //Start first brick from left most point in the current row on the screen
            currentX = ((-1) * Camera.main.orthographicSize * Camera.main.aspect) + ((brickWidth/2) - (2 * positionXOffset));
            for (int j = 0; j < colNum; j++)
            {
                Vector2 brickPosition = new Vector2(currentX, currentY);
                bricks[brickCount] = (GameObject) Instantiate(brickPrefab, brickPosition, Quaternion.identity);
                respawnTimeList[brickCount] = new RespawnTime();
                brickCount++;
                currentX += colWidth;
            }
            currentY += rowHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bricks.Length);
        for(int i = 0; i < bricks.Length; i++)
        {
            if(bricks[i].activeSelf == false)
            {
                if (respawnTimeList[i].rate < 10) respawnTimeList[i].rate = Random.Range(10, 100);
                else
                {
                    if (respawnTimeList[i].timeSinceLastSpawned >= respawnTimeList[i].rate)
                    {
                        bricks[i].SetActive(true);
                        respawnTimeList[i].rate = 0;
                        respawnTimeList[i].timeSinceLastSpawned = 0;
                    }
                    else
                    {
                        //Debug.Log(respawnTimeList[i].rate + ", " + respawnTimeList[i].timeSinceLastSpawned);
                        respawnTimeList[i].timeSinceLastSpawned += Time.deltaTime;
                    }
                }
                
            }
        }
    }
}

class RespawnTime
{
    public float rate = 0;
    public float timeSinceLastSpawned = 0;
}
