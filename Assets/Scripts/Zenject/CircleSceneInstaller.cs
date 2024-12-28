using UnityEngine;
using Zenject;
public class CircleSceneInstaller : MonoInstaller
{
    [SerializeField] private Square squarePrefab;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SquareSpawnerManager squareSpawnerManager;
    
    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromInstance(uiManager).AsSingle();
        Container.Bind<SquareSpawnerManager>().FromInstance(squareSpawnerManager).AsSingle();
        Container.BindMemoryPool<Square, SquarePool>().FromComponentInNewPrefab(squarePrefab);
    }
}