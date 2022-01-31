using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button ModeVertical;
    [SerializeField] private Button ModeHorisontal;

    [SerializeField] private GameObject ModeVerticalAnchor;
    [SerializeField] private GameObject ModeHorisontalAnchor;

    void Start()
    {
        ModeVertical.transform.DOMove(ModeVerticalAnchor.transform.position, 1);
        ModeHorisontal.transform.DOMove(ModeHorisontalAnchor.transform.position, 1);
    }
    void Update()
    {

    }
}
