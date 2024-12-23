using UnityEngine;
using Zenject;
public class Square : MonoBehaviour
{
    [Inject]
    private UIController _uiController;
    [Inject]
    private SquareSpawner _spawner;
    [Inject]
    private SquarePool squarePool;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _spawner.GenerateSquare();
            _uiController.scoreInvoker.Value++;
            squarePool.Despawn(this);
        }
    }
}
