using UnityEngine;

public class SquareController : Controller
{ 
    private SquareSpawnerView _view;
    private SquareSpawnerModel _model;
    public SquareController(SquareSpawnerView view, SquareSpawnerModel model) : base(view, model)
    {
        _view = view;
        _model = model;
    }
    public void GenerateSquares()
    {
        for (int i = 0; i < _model.MaxSquareCount; i++)
            GenerateSquare();
    }
    public void GenerateSquare()
    {
        _view.GenerateSquare(GetRandomPosition());
    }
    private Vector3 GetRandomPosition()
    {
        var randomX = Random.Range(_model.MinX, _model.MaxX);
        var randomY = Random.Range(_model.MinY, _model.MaxY);
        return new Vector3(randomX, randomY, 0f);
    }
}