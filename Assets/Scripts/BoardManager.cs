using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemyPrefab;
    public Grid grid;
    private Player player;
    public List<Player> enemies;
    private Enemy enemy;
    [SerializeField]
    private float moveSpeed = 2f;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        grid = new Grid(10, 10, CellPrefab);


        enemy = Instantiate(EnemyPrefab, new Vector2(0, 0), Quaternion.identity);
        player = Instantiate(PlayerPrefab, new Vector2(8, 8), Quaternion.identity);
        enemies.Add(player);
        
    }
    private void Update()
    {
        //if (Input.GetKeyDown(upKey)) 
        //{
        //    List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y+1);
        //    player.SetPath(path);
        //}
        //if (Input.GetKeyDown(downKey))
        //{
        //    List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y-1);
        //    player.SetPath(path);
        //}
        //if (Input.GetKeyDown(leftKey))
        //{
        //    List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, (int)enemy.GetPosition.x-1, (int)enemy.GetPosition.y);
        //    player.SetPath(path);
        //}
        //if (Input.GetKeyDown(rightKey))
        //{
        //    List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, (int)enemy.GetPosition.x+1, (int)enemy.GetPosition.y);
        //    player.SetPath(path);
        //}
    }
    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, (int)enemy.GetPosition.x , (int)enemy.GetPosition.y);
        //List<Cell> pathE = PathManager.Instance.FindPath(grid, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y, x, y);
        player.SetPath(path);
        //enemy.SetPath(path);
    }
    public void MoveEnemies()
    {
        foreach (Player e in enemies)
        {
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)e.GetPosition.x, (int)e.GetPosition.y, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y);
            
            path.Remove(path[0]);
            e.SetPath(path); 
        }
    }
}
