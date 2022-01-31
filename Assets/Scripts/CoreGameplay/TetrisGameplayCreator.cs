
using System.Collections.Generic;
using UnityEngine;

public partial class TetrisGamePlay
{
    #region Создание фигуры
    /// <summary>
    /// Создаем клетку,добавляем в массив фигуры.
    /// </summary>
    private void MakeCell()
    {
        isDivided = false;
        current = Instantiate(cellPrefab) as GameObject;
        current.GetComponent<MeshRenderer>().material.color = Color.red;
        figure.Add(current);
    }
    /// <summary>
    /// Случайным образом выбираем фигуру.
    /// </summary>
    private void CalculateShape()
    {
        delayBetweenTick = delayBetweenTickInInspector;
        string shapeMark = calculator.Calculate(currentSettings);
        Vector2[] shapeMembers = info.GetShape(shapeMark);
        FifureGenerator(shapeMembers);
    }
    /// <summary>
    ///  Добавляем фигуру в массив.
    /// </summary>
    private void AddToArea()
    {
        for (int i = 0; i < figure.Count; i++)
        {
            Transform tr = figure[i].transform;
            int x = Mathf.RoundToInt(tr.position.x);
            int y = Mathf.Abs(Mathf.RoundToInt(tr.position.y));
            area[x, y] = tr.gameObject;
            tr.parent = transform;
        }
    }
    /// <summary>
    /// Создаем фигуру координаты которой мы получаем в аргументах.
    /// </summary>
    /// <param name="shapeMembers"></param>
    private void FifureGenerator(Vector2[] shapeMembers)
    {
        figure = new List<GameObject>();
        foreach (var shapeCoordinates in shapeMembers)
        {
            MakeCell();
            current.transform.position = new Vector2(width / 2 + shapeCoordinates.x, shapeCoordinates.y);
        }

        CheckGameOver();
    }
    #endregion
}
