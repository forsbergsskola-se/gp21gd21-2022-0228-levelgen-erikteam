using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.TerrainAPI;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool Visited = false;
        public readonly bool[] Status = new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;

    public GameObject[] room;
    public GameObject firstRoom;
    public GameObject lastRoom;
    public GameObject bonusRoom;

    private Color[] colors;

    public int bonusRoomChance;
    private List<Cell> _board;

    private float _roomOffsetX;
    private float _roomOffsetY;
    // Start is called before the first frame update
    void Start()
    {
        float temp = (size.x + size.y) - 2;
        colors = new Color[(int)temp];

        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.Lerp(Color.green, Color.red, ((float)i/10));
        }

        MazeGenerator();
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            int randomBonusNumber = Random.Range(0, 100);
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = _board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.Visited)
                {
                    if (i == 0 && j == 0)
                    {
                        _roomOffsetX = firstRoom.GetComponent<RoomBehaviour>().RoomOffsetX;
                        _roomOffsetY = firstRoom.GetComponent<RoomBehaviour>().RoomOffsetY;
                        if (firstRoom.GetComponent<RoomBehaviour>().lights.Length != 0)
                        {
                            for (int k = 0; k < firstRoom.GetComponent<RoomBehaviour>().lights.Length; k++)
                            {
                                for (int l = 0; l < ((size.x + size.y) - 2); l++)
                                {
                                    if (i + j == l)
                                    {
                                        firstRoom.GetComponent<RoomBehaviour>().lights[k].GetComponent<Light>().color = colors[l];
                                    }
                                }
                            }
                        }
                        var newRoom = Instantiate(firstRoom, new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                        newRoom.UpdateRoom(currentCell.Status);
                        newRoom.name += "First Room " + i + "-" + j;
                    }
                    else if (i == size.x - 1 && j == size.y - 1)
                    {
                        _roomOffsetX = lastRoom.GetComponent<RoomBehaviour>().RoomOffsetX;
                        _roomOffsetY = lastRoom.GetComponent<RoomBehaviour>().RoomOffsetY;
                        if (firstRoom.GetComponent<RoomBehaviour>().lights.Length != 0)
                        {
                            for (int k = 0; k < lastRoom.GetComponent<RoomBehaviour>().lights.Length; k++)
                            {
                                for (int l = 0; l < ((size.x + size.y) - 2); l++)
                                {
                                    if (i + j == l)
                                    {
                                        lastRoom.GetComponent<RoomBehaviour>().lights[k].GetComponent<Light>().color = colors[l];
                                    }
                                }
                            }
                        }
                        var newRoom = Instantiate(lastRoom, new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                        newRoom.UpdateRoom(currentCell.Status);
                        newRoom.name += "Last Room " + i + "-" + j;
                    }
                    else if (i != 0 && j != 0 && i != size.x - 1 && j != size.y - 1 && randomBonusNumber < bonusRoomChance)
                    {
                        _roomOffsetX = bonusRoom.GetComponent<RoomBehaviour>().RoomOffsetX;
                        _roomOffsetY = bonusRoom.GetComponent<RoomBehaviour>().RoomOffsetY;
                        var newRoom = Instantiate(bonusRoom, new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                        if (firstRoom.GetComponent<RoomBehaviour>().lights.Length != 0)
                        {
                            for (int k = 0; k < bonusRoom.GetComponent<RoomBehaviour>().lights.Length; k++)
                            {
                                for (int l = 0; l < ((size.x + size.y) - 2); l++)
                                {
                                    if (i + j == l)
                                    {
                                        bonusRoom.GetComponent<RoomBehaviour>().lights[k].GetComponent<Light>().color = colors[l];
                                    }
                                }
                            }
                        }
                        newRoom.UpdateRoom(currentCell.Status);
                        randomBonusNumber = bonusRoomChance + 100;
                        newRoom.name += "Bonus Room " + i + "-" + j;
                    }
                    else
                    {
                        int randomNumberRoom = Random.Range(0, room.Length);
                        _roomOffsetX = room[randomNumberRoom].GetComponent<RoomBehaviour>().RoomOffsetX;
                        _roomOffsetY = room[randomNumberRoom].GetComponent<RoomBehaviour>().RoomOffsetY;
                        if (firstRoom.GetComponent<RoomBehaviour>().lights.Length != 0)
                        {
                            for (int k = 0; k < room[randomNumberRoom].GetComponent<RoomBehaviour>().lights.Length; k++)
                            {
                                for (int l = 0; l < ((size.x + size.y) - 2); l++)
                                {
                                    if (i + j == l)
                                    {
                                        room[randomNumberRoom].GetComponent<RoomBehaviour>().lights[k].GetComponent<Light>().color = colors[l];
                                    }
                                }
                            }
                        }
                        var newRoom = Instantiate(room[randomNumberRoom], new Vector3(i * _roomOffsetX, 0, -j * _roomOffsetY), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                        newRoom.UpdateRoom(currentCell.Status);
                        newRoom.name += " " + i + "-" + j;
                    }
                }
            }
        }
        gameObject.GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    void MazeGenerator()
    {
        _board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                _board.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 1000)
        {
            k++;

            _board[currentCell].Visited = true;

            if (currentCell == _board.Count - 1)
            {
                break;
            }

            //check the cell's neighbours
            List<int> neighbours = CheckNeighbours(currentCell);

            if (neighbours.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbours[Random.Range(0, neighbours.Count)];

                if (newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        _board[currentCell].Status[2] = true;
                        currentCell = newCell;
                        _board[currentCell].Status[3] = true;
                    }
                    else
                    {
                        _board[currentCell].Status[1] = true;
                        currentCell = newCell;
                        _board[currentCell].Status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        _board[currentCell].Status[3] = true;
                        currentCell = newCell;
                        _board[currentCell].Status[2] = true;
                    }
                    else
                    {
                        _board[currentCell].Status[0] = true;
                        currentCell = newCell;
                        _board[currentCell].Status[1] = true;
                    }
                }
            }
        }
        GenerateDungeon();
    }

    List<int> CheckNeighbours(int cell)
    {
        List<int> neighbours = new List<int>();

        //check up neighbour
        if (cell - size.x >= 0 && !_board[Mathf.FloorToInt(cell - size.x)].Visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell - size.x));
        }
        //check down neighbour
        if (cell + size.x < _board.Count && !_board[Mathf.FloorToInt(cell + size.x)].Visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + size.x));
        }
        //check right neighbour
        if ((cell + 1) % size.x != 0 && !_board[Mathf.FloorToInt(cell + 1)].Visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + 1));
        }
        //check left neighbour
        if (cell % size.x != 0 && !_board[Mathf.FloorToInt(cell - 1)].Visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbours;
    }
}
