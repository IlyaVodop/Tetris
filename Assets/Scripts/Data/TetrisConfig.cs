
using UnityEngine;

[CreateAssetMenu(fileName = "TetrisConfig", menuName = "ScriptableObjects/TetrisConfig", order = 1)]

public class TetrisConfig : ScriptableObject
{   public int Width => width;
    public int Height => height;
    public int NumberOfDestroyLayers => numberOfDestroyLayers;

    public double Cube => cube;
    public double Z => z;
    public double S => s;
    public double L => l;
    public double J => j;
    public double I => i;
    public double T => t;
    public double Plus => plus;
    public double C => c;
    public double E => e;
    
    public bool IsCanPierceFromWall => isCanPierceFromWall;

    [SerializeField] private double cube;
    [SerializeField] private double z;
    [SerializeField] private double s;
    [SerializeField] private double l;
    [SerializeField] private double j;
    [SerializeField] private double i;
    [SerializeField] private double t;
    [SerializeField] private double plus;
    [SerializeField] private double c;
    [SerializeField] private double e;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int numberOfDestroyLayers;
    [SerializeField] private bool isCanPierceFromWall;

 
}
