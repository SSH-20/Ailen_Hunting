using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int imin;
        public int imax;

        public Count(int min, int max)
        {
            imin = min;
            imax = max;
        }
    }

    public int icols = 8;
    public int irows = 8;

    public Count wallCount = new Count(5, 9);
    public Count lootCount = new Count(1, 5);
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] enemyTiles;
    public GameObject[] lootTiles;

    private Transform boardHolder;
    private List <Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x = 1; x < icols-1; x++)
        {
            for (int y = 1; y < irows -1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject ("Board").transform;

        for (int x = -1; x < icols + 1; x++)
        {
            for (int y = -1; y < irows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];

                if (x==-1 || x==icols || y==-1 || y==irows)
                {
                    toInstantiate = outerWallTiles[Random.Range (0, outerWallTiles.Length)];
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPos()
    {
        if (gridPositions.Count == 0)
        {
            InitializeList(); // Regenerate grid positions if it's empty
        }
        int randomIdx = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIdx];
        gridPositions.RemoveAt(randomIdx);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objCt = Random.Range(min, max + 1);

        for (int i = 0; i < objCt; i++) 
        {
            Vector3 randomPosition = RandomPos();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }

    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(wallTiles, wallCount.imin, wallCount.imax);
        LayoutObjectAtRandom(lootTiles, lootCount.imin, lootCount.imax);
        int enemyCt = (int)Mathf.Log(level, 2f);
        LayoutObjectAtRandom(enemyTiles, enemyCt, enemyCt);
    }
}
