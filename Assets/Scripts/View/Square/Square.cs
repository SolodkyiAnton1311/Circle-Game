using UnityEngine;
using Zenject;
public class Square : MonoBehaviour
{
    [Inject]
    private UIManager _uiManager;
    [Inject]
    private SquareSpawnerManager _squareManager;
    [Inject]
    private SquarePool _squarePool;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _squareManager.SquareController.GenerateSquare();
            _uiManager.UIController.AddScore();
            _squarePool.Despawn(this);
        }
    }
}
