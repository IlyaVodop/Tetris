
using UnityEngine;

public partial class TetrisGamePlay
{
    #region Уничтожение линии
    /// <summary>
    /// Удаление полной линии.
    /// </summary>
    /// <param name="line"></param>
    private void DestroyLine(int line)
    {

        score++;
        OnScoreSend?.Invoke(score);

        foreach (GameObject obj in figure)
        {
            int x = Mathf.RoundToInt(obj.transform.position.x);
            int y = Mathf.RoundToInt(Mathf.Abs(obj.transform.position.y));
            if (y == line)
            {
                area[x, y] = null;
                Destroy(obj);



            }
        }
    }


    #endregion
}
