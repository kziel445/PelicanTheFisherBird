using System.Collections.Generic;
using UnityEngine;

public class Background
{
    private float speedModificator;
    private List<Transform> backgroundsList;
    private float leftBorder;
    private float rightBorder;

    public Background(List<Transform> backgroundsList, float speedModificator)
    {
        this.speedModificator = speedModificator;
        this.backgroundsList = backgroundsList;
        this.leftBorder = backgroundsList[0].position.x - backgroundsList[0].GetComponent<SpriteRenderer>().size.x * backgroundsList[0].transform.localScale.x;
        this.rightBorder = backgroundsList[0].position.x + backgroundsList[0].GetComponent<SpriteRenderer>().size.x * backgroundsList[0].transform.localScale.x;
    }

    public void Move()
    {
        foreach (Transform background in backgroundsList)
        {
            background.position += new Vector3(-1, 0, 0) * speedModificator * Time.deltaTime;
            if (background.position.x < leftBorder)
            {
                background.position = new Vector3(rightBorder - .5f, background.position.y, background.position.z);
            }
        }
    }
}