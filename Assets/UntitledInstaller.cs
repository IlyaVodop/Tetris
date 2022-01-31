using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private View view;
    [SerializeField] private Controller  controller;
    [SerializeField] private TetrisConfig currentSettings;
    public override void InstallBindings()
    {
        Container.BindInstance(view);
        Container.BindInstance(controller);
        Container.BindInstance(currentSettings);
    }
}