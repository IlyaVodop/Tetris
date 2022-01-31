using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TetrisGamePlay
{
    #region  Движение
    /// <summary>
    /// Смещение фигур.
    /// </summary>
    /// <param name="line"></param>
    private void DownLine(int line)
    {
       
        for (int x = 0; x < width; x++)
        {
            for (int y = line; y > 0; y--)
            {
                area[x, y] = area[x, y - 1];
            }
        }

        for (int i = 0; i < width; i++)
        {
            area[i, 0] = null;
        }

        figure = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            figure.Add(transform.GetChild(i).gameObject);
        }

       
        foreach (GameObject obj in figure)
        {
            int y = Mathf.RoundToInt(Mathf.Abs(obj.transform.position.y));
            if (y < line)
            {
                obj.transform.position -= new Vector3(0, 1, 0);
            }
        }
    }
    /// <summary>
    /// Движение вниз.
    /// </summary>
    /// <returns></returns>
    private bool IsDown()
    {
        for (int i = 0; i < figure.Count; i++)
        {
            Transform tr = figure[i].transform;
            int x = Mathf.RoundToInt(tr.position.x);
            int y = Mathf.Abs(Mathf.RoundToInt(tr.position.y));

          
                if (y < height - 1)
                {
                    if (area[x, y + 1])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
         
        }

        foreach (GameObject obj in figure)
        {
            obj.transform.position -= new Vector3(0, 1, 0);
        }

        return true;
    }
    /// <summary>
    /// Перемещение фигуры влево или вправо для вторго режима.
    /// </summary>
    /// <param name="index"></param>
    private void MoveThrought(int index)
    {
        if (index > 0)
        {
            bool isDiv = false;
            foreach (GameObject obj in figure)
            {

                if (obj.transform.position.x < width - 1)
                {

                    obj.transform.position += new Vector3(index, 0, 0);
                }
                else
                {
                    isDiv = true;
                    obj.transform.position += new Vector3(index - width, 0, 0);
                }
            }

            isDivided = isDiv;
        }

        if (index < 0)
        {
            bool isDiv = false;
            foreach (GameObject obj in figure)
            {
                if (obj.transform.position.x < 0.9f) // Поправка на float.
                {

                    isDiv = true;
                    obj.transform.position += new Vector3(index + width, 0, 0);

                }
                else
                {
                    obj.transform.position += new Vector3(index, 0, 0);
                }
            }
            isDivided = isDiv;
        }
    }
    /// <summary>
    /// Перемещение фигуры влево или вправо для первого режима.
    /// </summary>
    /// <param name="index"></param>
    private void MoveSimple(int index)
    {
        foreach (GameObject obj in figure)
        {
            obj.transform.position += new Vector3(index, 0, 0);
        }
    }
    /// <summary>
    ///  Метод поворота фигуры.
    /// </summary>
    /// <param name="index"></param>
    private void RotateFigure(int index)
    {
        if (isDivided)
        {
            return;
        }

        bool result;
        sample.transform.position = figure[0].transform.position;
        foreach (GameObject obj in figure)
        {
            obj.transform.parent = sample.transform;
        }
        sample.transform.Rotate(0, 0, index);
        foreach (GameObject obj in figure)
        {
            obj.transform.parent = null;
        }

        
       
        if (!IsInArea())
        {
            result = IsNeedCorrectingRotation(2, 1);
        }
        else
        {
            result = IsThisCellOccupied();
        }

       
        if (result)
        {
            foreach (GameObject obj in figure)
            {
                obj.transform.parent = sample.transform;
            }
            sample.transform.Rotate(0, 0, -index);
            foreach (GameObject obj in figure)
            {
                obj.transform.parent = null;
            }
        }
    }
    /// <summary>
    ///  Метод который принемает команды от Controller.
    /// </summary>
    /// <param name="command"></param>
    public void HandleCommand(Command command)
    {
        delayBetweenTick = delayBetweenTickInInspector;
        switch (command)
        {
            case Command.Left:
                if (isCanPierceFromWall && !IsNextCelIsOccupiedButNoBorder(-1))
                {
                    MoveThrought(-1);
                }
                else if (IsCanMove(-1))
                {
                    MoveThrought(-1);
                }

                break;

            case Command.Right:
                if (isCanPierceFromWall && !IsNextCelIsOccupiedButNoBorder(1))
                {
                    MoveThrought(1);
                }
                else if (IsCanMove(1))
                {
                    MoveThrought(1);
                }

                break;
            case Command.RotateLeft:
                RotateFigure(-90);
                break;
            case Command.RotateRight:
                RotateFigure(90);
                break;
            case Command.Down:
                delayBetweenTick = 0;
                break;
        }
    }
    #endregion
}
