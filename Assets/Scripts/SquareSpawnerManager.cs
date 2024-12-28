using UnityEngine;

public class SquareSpawnerManager : MonoBehaviour
{
    [SerializeField] private SquareSpawnerView view;
    
    [SerializeField] private float _minX, _minY, _maxX, _maxY;
   
    [SerializeField] private int _maxSquareCount;
    private SquareController _squareController;

    public SquareController SquareController
    {
        get => _squareController;
    }

    private void Start()
    {
        _squareController =
            new SquareController(view, new SquareSpawnerModel(view, _minX, _minY, _maxX, _maxY, _maxSquareCount));
        _squareController.GenerateSquares();
    }
}
