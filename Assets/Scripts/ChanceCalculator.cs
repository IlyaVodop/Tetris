using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChanceCalculator : MonoBehaviour
{
    /// <summary>
    ///  Здесь определяем какая фигура выпадет.
    /// </summary>
    /// <param name="currentSettings"></param>
    /// <returns></returns>
    public string Calculate(TetrisConfig currentSettings)
    {
        string shapeMark = "";
        (double Chance, string s)[] chances =
        {
            (Chance: currentSettings.Cube, S:"Cube"),
            (Chance: currentSettings.Z, S: "Z"),
            (Chance:currentSettings.S, S: "S"),
            (Chance: currentSettings.L, S: "L"),
            (Chance: currentSettings.J, S: "J"),
            (Chance: currentSettings.I, S: "I"),
            (Chance: currentSettings.T, S: "T"),
            (Chance: currentSettings.Plus, S: "+"),
            (Chance: currentSettings.C, S: "C"),
            (Chance: currentSettings.E, S: "E"),
               

        };
        double total = 0;
        foreach (var el in chances)
        {
            total = total + el.Chance;
        }
        double chance = Random.Range(0, 100) + 1;
        double temp = 0;
        for (int index = 0; index < chances.Length; index++)
        {
            var pair = chances[index];
            temp = temp + pair.Chance / total * 100;
            if (chance <= temp)
            {
                return pair.s;

            }
        }

        throw new NotSupportedException("Некорректно настроен рандом");
    }
}
