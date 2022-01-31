using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TetrisGamePlay
{
    #region Проверки
    /// <summary>
    ///  Проверка на препятствия.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool IsBorder(int index)
    {
        bool isBorder = false;
        foreach (var t in figure)
        {
            Transform tr = t.transform;
            int x = Mathf.RoundToInt(tr.position.x);

            if ((x < width - 1 && index > 0) || (x > 0 && index < 0))
            {
                continue;
            }
            else
            {
                isBorder = true;
            }
        }

        return isBorder;
    }
    /// <summary>
    /// Можно-ли сдвинуть влево или вправо, проверка.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private bool IsCanMove(int index)
    {
        for (int i = 0; i < figure.Count; i++)
        {
            Transform tr = figure[i].transform;
            int x = Mathf.RoundToInt(tr.position.x);
            int y = Mathf.Abs(Mathf.RoundToInt(tr.position.y));

            if (x < width - 1 && index > 0)
            {
                if (area[x + 1, y])
                {
                    return false;
                }
            }
            else if (x > 0 && index < 0)
            {
                if (area[x - 1, y])
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
    /// <summary>
    /// Метод который возвращает true,если клетка справа или слева от нас занята, но еще не край.
    /// </summary>
    private bool IsInArea()
    {
        for (int i = 0; i < figure.Count; i++)
        {
            Transform tr = figure[i].transform;
            int x = Mathf.RoundToInt(tr.position.x);
            int y = Mathf.Abs(Mathf.RoundToInt(tr.position.y));

            if (x < 0 || x > width - 1 || y > height - 1 || y < 0)
            {
                return false;
            }
        }

        return true;
    }
    /// <summary>
    /// Проверка на перекрытие  фигурами.
    /// </summary>
    /// <returns></returns>
    private bool IsThisCellOccupied()
    {
        for (int i = 0; i < figure.Count; i++)
        {
            Transform tr = figure[i].transform;
            int x = Mathf.RoundToInt(tr.position.x);
            int y = Mathf.Abs(Mathf.RoundToInt(tr.position.y));

            if (area[x, y])
            {
                return true;
            }
        }

        return false;
    }

    private bool IsNextCelIsOccupiedButNoBorder(int index)
    {
        return !IsCanMove(index) && !IsBorder(index);
    }
    /// <summary>
    /// Проверка если движение фигуры в низ не возможно то геймовер
    /// </summary>
    private void CheckGameOver()
    {
        if (GameOver())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (GameObject obj in figure)
            {
                Destroy(obj);
            }

            Restart();

        }
    }
    /// <summary>
    /// Проверка на Game Over.
    /// </summary>
    /// <returns></returns>
    private bool GameOver()
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
                    return true;
                }
            }
        }

        return false;
    }
    /// <summary>
    /// Поиск полной линии для второго режима.
    /// </summary>
    /// <returns></returns>
    private int CheckTwoLine()
    {
        int i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (area[x, y])
                    i++;
            }
            if (i == width)
            {
                int j = 0;

                if (y + 1 >= height) 
                {
                    return -1;
                }
                for (int x = 0; x < width; x++)
                {
                    if (area[x, y + 1])
                        j++;
                }
                if (j == width)
                {
                    return y;

                }

            }
            i = 0;
        }

        return -1; 
    }
    /// <summary>
    /// Поиск полной лини для первого режима.
    /// </summary>
    /// <returns></returns>
    private int CheckLine()
    {
        int i = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (area[x, y])
                    i++;
            }
            if (i == width)
            {
                return y;
            }
            i = 0;
        }
        return -1;
    }
    /// <summary>
    /// функция сдвига фигуры, если при развороте она выходит за рамки поля.
    /// </summary>
    /// <param name="iter"></param>
    /// <param name="shift"></param>
    /// <returns></returns>
    private bool IsNeedCorrectingRotation(int iter, int shift)
    {
        MoveSimple(shift);
        if (IsInArea())
        {
            if (IsThisCellOccupied())
            {
                MoveSimple(-shift);
                return true;
            }
            return false;
        }

        MoveSimple(-shift * 2); 
        if (IsInArea())
        {
            if (IsThisCellOccupied())
            {
                MoveSimple(shift);
                return true;
            }
            return false;
        }
        MoveSimple(shift);

        if (iter > 0) 
        {
            return IsNeedCorrectingRotation(iter - 1, shift + 1);
        }

        return true;

    }
    #endregion
}
