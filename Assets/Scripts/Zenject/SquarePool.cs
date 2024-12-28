using Zenject;
public class SquarePool : MemoryPool<Square>
{
    protected override void OnSpawned(Square item)
    {
        item.gameObject.SetActive(true);
    }
    protected override void OnDespawned(Square item)
    {
        item.gameObject.SetActive(false);
    }
}