
using System.Collections.Generic;
using UnityEngine;

public partial class TetrisGamePlay
{
    #region Обновление игрового поля
    private void FieldUpdate()

    {
        figure = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            figure.Add(transform.GetChild(i).gameObject);
        }

        if (numberOfDestroyLayers == 2)
        {
            var twoLine = CheckTwoLine();
            if (twoLine != -1)
            {
                var line = twoLine;
                while (line != -1)
                {
                    DestroyLine(line);
                    DownLine(line);
                    line = CheckLine();
                }
            }
        }

        if (numberOfDestroyLayers == 1)
        {
            int line = -1;
            line = CheckLine();
            while (line != -1)
            {
                DestroyLine(line);
                DownLine(line);
                line = CheckLine();
            }
        }



    }
    void Update()
    {

        delayBetweenTick = Mathf.Clamp(delayBetweenTick, 0.1f, 1f);

        currentTime += Time.deltaTime;
        if (currentTime > delayBetweenTick)
        {
            currentTime = 0;
            if (!IsDown())
            {
                AddToArea();
                FieldUpdate();
                CalculateShape();
            }
            delayBetweenTick = delayBetweenTickInInspector;
        }
    }
    #endregion
}
