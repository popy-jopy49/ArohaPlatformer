using UnityEngine;

public class Grid
{

    Vector2 offset;
    GameObject[,] gridObjects;
    Vector2 gridSize;

    public Grid(Vector2 offset, Vector2 gridSize, int gridHeight, int gridWidth)
    {
        this.offset = offset;
        this.gridSize = gridSize;
        gridObjects = new GameObject[gridWidth, gridHeight];
    }

}
