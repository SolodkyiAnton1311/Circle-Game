public class SquareSpawnerModel : Model
{
    private float _minX,_minY,_maxX,_maxY;
    private int _maxSquareCount;

    public float MinX
    {
        get => _minX;
        set => _minX = value;
    }

    public float MinY
    {
        get => _minY;
        set => _minY = value;
    }

    public float MaxX
    {
        get => _maxX;
        set => _maxX = value;
    }

    public float MaxY
    {
        get => _maxY;
        set => _maxY = value;
    }

    public int MaxSquareCount
    {
        get => _maxSquareCount;
        set => _maxSquareCount = value;
    }

    public SquareSpawnerModel(View view, float minX, float minY, float maxX, float maxY, int maxSquareCount) : base(view)
    {
        _minX = minX;
        _minY = minY;
        _maxX = maxX;
        _maxY = maxY;
        _maxSquareCount = maxSquareCount;
    }
}
