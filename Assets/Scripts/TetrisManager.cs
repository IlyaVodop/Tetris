
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class TetrisManager : MonoBehaviour
{
    [Inject] private View view;
    [Inject] private Controller controller;

    [SerializeField] private TetrisGamePlay tetrisGamePlay;

    [SerializeField] private Button verticalButton;
    [SerializeField] private Button horizontalButton;
    [SerializeField] private TetrisConfig verticalSettings;
    [SerializeField] private TetrisConfig horizontalSettings;
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;
    [SerializeField] private Transform downBorder;
    [SerializeField] private Transform camera;

    private const int OFFSET_LEFT_BORDER = -6;
    private const int OFFSET_RIGHT_BORDER = -5;
    private const int OFFSET_DOWN_BORDER = 4;

    private TetrisConfig currentConfig;

    private void Awake()
    {
        horizontalButton.onClick.AddListener(() =>
        {
            LocalInit(horizontalSettings);
        });
        verticalButton.onClick.AddListener(() =>
        {
            LocalInit(verticalSettings);
        });

        _view.Init(tetrisGamePlay);
        _controller.Init(tetrisGamePlay);

    }
   
    private void LocalInit(TetrisConfig config)
    {
        DeactivateButtons();
        currentConfig = config;

        SetupScene();
        tetrisGamePlay.StartGame(currentConfig);
    }

    private void SetupScene()
    {
        camera.position = new Vector3((float)currentConfig.Width / 2, (float)-currentConfig.Height / 2, camera.position.z);
        leftBorder.localPosition =
            new Vector3(OFFSET_LEFT_BORDER,
                leftBorder.transform.position.y,
                leftBorder.transform.position.z);


        rightBorder.localPosition =
            new Vector3(currentConfig.Width + OFFSET_RIGHT_BORDER,
                rightBorder.transform.position.y,
                rightBorder.transform.position.z);

        downBorder.localPosition =
            new Vector3(downBorder.position.x,
                -currentConfig.Height + OFFSET_DOWN_BORDER,
                downBorder.position.z);
    }
  
    private void DeactivateButtons()
    {
        horizontalButton.gameObject.SetActive(false);
        verticalButton.gameObject.SetActive(false);
    }
}
