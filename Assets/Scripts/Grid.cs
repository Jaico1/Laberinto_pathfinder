using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    private int width;
    private int height;
    public List<Cell> cells = new List<Cell>();
    private Cell cellPrefab;
    private Cell[,] gridArray;


    public Grid(int width, int height,  Cell cellPrefab)
    {
        
        this.width = width;
        this.height = height;
        
        this.cellPrefab = cellPrefab;

        generateBoard();
    }

    private void generateBoard()
    {
        Cell cell;
        gridArray = new Cell[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var p = new Vector2(i, j);
                cell = Instantiate(cellPrefab, p, Quaternion.identity);
                cell.Init(this, (int)p.x, (int)p.y, true);
                cells.Add(cell);

                if (Random.Range(0, 10) <= 2)
                    cell.SetWalkable(false);
                else
                    cell.SetColor(Color.blue);

                gridArray[i, j] = cell;
            }
        }

        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
        assignNeighbors();
    }

    internal int GetHeight()
    {
        return height;
    }

    internal int GetWidth()
    {
        return width;
    }

    public void CellMouseClick(Cell cell)
    {
        //cell.SetText("Click on cell "+cell.x+ " "+ cell.y);
        BoardManager.Instance.CellMouseClick(cell.x, cell.y);
    }

    

    public Cell GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    public void assignNeighbors()
    {
        foreach (Cell c in cells)
        {

            foreach (Cell cin in cells)
            {
                bool Der = cin.x == c.x + 1 && cin.y == c.y;
                bool Izq = cin.x == c.x - 1 && cin.y == c.y;
                bool Up = cin.y == c.y + 1 && cin.x == c.x;
                bool Down = cin.y == c.y - 1 && cin.x == c.x;


                if (Der)
                {
                    c.rightNeighbor = cin;

                }

                if (Izq)
                {
                    c.leftNeighbor = cin;
                }

                if (Up)
                {
                    c.upNeighbor = cin;
                }

                if (Down)
                {
                    c.downNeighbor = cin;
                }
            }
        }
    }

    /*internal float GetCellSize()
    {
        return cellSize;
    }*/
}
