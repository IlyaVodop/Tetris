using System;
using System.Collections.Generic;
using UnityEngine;

public partial class TetrisGamePlay : MonoBehaviour, ICommandHandler, IScoreSender
{
    public event OnScoreSend OnScoreSend;

    [SerializeField] private GameObject cellPrefab;

    private int width;
    private int height;
    private int numberOfDestroyLayers;
    private int score;
    private float currentTime, delayBetweenTick;
    private float delayBetweenTickInInspector = 1 ;

    private bool isDivided;
    private bool isCanPierceFromWall;

    private TetrisConfig currentSettings;
    private GameObject sample, current;
    private GameObject[,] area = new GameObject[0, 0];
    private List<GameObject> figure = new List<GameObject>();
    private ShapeInfos info;
    private ChanceCalculator calculator;
  

    public void StartGame(TetrisConfig currentSettings)
    {
        this.currentSettings = currentSettings;
        width = currentSettings.Width;
        height = currentSettings.Height;
        numberOfDestroyLayers = currentSettings.NumberOfDestroyLayers;
        isCanPierceFromWall = currentSettings.IsCanPierceFromWall;
        sample = new GameObject();
        area = new GameObject[width, height];
        info = new ShapeInfos();
        calculator = new ChanceCalculator();
        CalculateShape();
        OnScoreSend?.Invoke(0);
    }

    private void Restart()
    {
        StartGame(currentSettings);
    }

}