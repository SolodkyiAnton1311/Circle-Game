using UnityEngine;
using Zenject;

public class CircleSceneInstaller : MonoInstaller
{
    [SerializeField] private Square square;
    [SerializeField] private UIController uiController;
    [SerializeField] private SquareSpawner squareSpawner;
    public override void InstallBindings()
    {
        Container.BindMemoryPool<Square,SquarePool>().FromComponentInNewPrefab(square);
        Container.Bind<UIController>().FromInstance(uiController).AsSingle();
        Container.Bind<SquareSpawner>().FromInstance(squareSpawner).AsSingle();
    }
}
