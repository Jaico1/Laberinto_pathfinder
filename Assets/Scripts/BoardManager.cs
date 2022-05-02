using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public int level;
    public int N = 11;
    public GameObject cam;
    

    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        N = PlayerPrefs.GetInt("Size");
        switch (PlayerPrefs.GetInt("level"))
        {
            case 1:
                grid = new Grid(N, N, N - 2, N - 3, CellPrefab);


                enemy = Instantiate(EnemyPrefab, new Vector2(0, 0), Quaternion.identity);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N-2), Quaternion.identity);
                enemies.Add(player);

                if (PathManager.Instance.FindPath(grid, 0, 0, 8, 7) == null)
                {

                    SceneManager.LoadScene("GameScene");
                }

                break;
            case 2:
                grid = new Grid(N, N, N - 2, N - 3, CellPrefab);


                enemy = Instantiate(EnemyPrefab, new Vector2(0, 0), Quaternion.identity);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - (N-1)), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - 2), Quaternion.identity);
                enemies.Add(player);

                if (PathManager.Instance.FindPath(grid, 0, 0, 8, 7) == null)
                {

                    SceneManager.LoadScene("GameScene");
                }
                break;
            case 3:
                grid = new Grid(N, N, N - 2, N - 3, CellPrefab);


                enemy = Instantiate(EnemyPrefab, new Vector2(0, 0), Quaternion.identity);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - (N - 1)), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - 2), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - (N - 1), N-2), Quaternion.identity);
                enemies.Add(player);

                if (PathManager.Instance.FindPath(grid, 0, 0, 8, 7) == null)
                {

                    SceneManager.LoadScene("GameScene");
                }
                break;
            case 4:
                grid = new Grid(N, N, N - 2, N - 3, CellPrefab);


                enemy = Instantiate(EnemyPrefab, new Vector2(0, 0), Quaternion.identity);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - (N - 1)), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - 2, N - 2), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - (N - 1), N - 2), Quaternion.identity);
                enemies.Add(player);
                player = Instantiate(PlayerPrefab, new Vector2(N - (N /2), N - (N / 2)), Quaternion.identity);
                enemies.Add(player);

                if (PathManager.Instance.FindPath(grid, 0, 0, 8, 7) == null)
                {

                    SceneManager.LoadScene("GameScene");
                }
                break;

                

        }

        foreach (Player e in enemies)
        {


            if (PathManager.Instance.FindPath(grid, (int)e.GetPosition.x, (int)e.GetPosition.y, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y) == null)
            {
                SceneManager.LoadScene("GameScene");
            }
        }

    }
    private void Update()
    {

        foreach (Player e in enemies)
        {


            if (getDistanceBetween(e.transform.position.x, enemy.transform.position.x) <  0.5 && getDistanceBetween(e.transform.position.y, enemy.transform.position.y) <0.5)
            {
                Debug.Log("perdiste");
                SceneManager.LoadScene("Lose");
            }
            //if ((int)e.transform.position.x == (int)enemy.transform.position.x && (int)e.transform.position.y == (int)enemy.transform.position.y)
            //{
            //    Debug.Log("perdiste");
            //    SceneManager.LoadScene("WinScreen");

            //}
        }

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
        if (PlayerPrefs.GetInt("level") == 1 && (int)enemy.GetPosition.x == N-2 && (int)enemy.GetPosition.y == N-3)
        {
            PlayerPrefs.SetInt("level", 2);
            SceneManager.LoadScene("GameScene");

        }else if (PlayerPrefs.GetInt("level") == 2 && (int)enemy.GetPosition.x == N - 2 && (int)enemy.GetPosition.y == N - 3)
        {
            PlayerPrefs.SetInt("level", 3);
            SceneManager.LoadScene("GameScene");

        }else if (PlayerPrefs.GetInt("level") == 3 && (int)enemy.GetPosition.x == N - 2 && (int)enemy.GetPosition.y == N - 3)
        {
            PlayerPrefs.SetInt("level", 4);
            SceneManager.LoadScene("GameScene");

        }
        else if (PlayerPrefs.GetInt("level") == 4 && (int)enemy.GetPosition.x == N - 2 && (int)enemy.GetPosition.y == N - 3)
        {
            
            SceneManager.LoadScene("P1wins");

        }



        Debug.Log(PlayerPrefs.GetInt("level"));
        foreach (Player e in enemies)
        {
            List<Cell> path = PathManager.Instance.FindPath(grid, (int)e.GetPosition.x, (int)e.GetPosition.y, (int)enemy.GetPosition.x, (int)enemy.GetPosition.y);
            
            path.Remove(path[0]);
            e.SetPath(path);

            
        }
    }
    public float getDistanceBetween(float a, float b)
    {
        if (a>b)
        {
            return a - b;
        }
        if (b > a)
        {
            return b - a;
        }
        else
        return 0;
    }
}
