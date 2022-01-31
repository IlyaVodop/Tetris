using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private View _view;
    [SerializeField] private Controller _controller;
   
    public override void InstallBindings()
    {
        Container.BindInstance(_view);
        Container.BindInstance(_controller); 
    }
}