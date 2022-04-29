using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public Cell currentCell;
    public List<Cell> cells;
    public Vector2 GetPosition => transform.position;

    void Start()
    {




    }
    public void Awake()
    {
        cells = BoardManager.Instance.grid.cells;

        foreach (Cell c in cells)
        {
            if (c.x == 0 && c.y == 0)
            {
                currentCell = c;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey) && currentCell.upNeighbor.isWalkable)
        {
            GetComponent<Transform>().position = new Vector3(currentCell.upNeighbor.x, currentCell.upNeighbor.y, 0);
            currentCell = currentCell.upNeighbor;

        }
        else if (Input.GetKeyDown(downKey) && currentCell.downNeighbor.isWalkable)
        {
            GetComponent<Transform>().position = new Vector3(currentCell.downNeighbor.x, currentCell.downNeighbor.y, 0);
            currentCell = currentCell.downNeighbor;
        }
        else if (Input.GetKeyDown(rightKey) && currentCell.rightNeighbor.isWalkable)
        {
            GetComponent<Transform>().position = new Vector3(currentCell.rightNeighbor.x, currentCell.rightNeighbor.y, 0);
            currentCell = currentCell.rightNeighbor;
        }
        else if (Input.GetKeyDown(leftKey) && currentCell.leftNeighbor.isWalkable)
        {
            GetComponent<Transform>().position = new Vector3(currentCell.leftNeighbor.x, currentCell.leftNeighbor.y, 0);
            currentCell = currentCell.leftNeighbor;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("perdiste");
    }
}
