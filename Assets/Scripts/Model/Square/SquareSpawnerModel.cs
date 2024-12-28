public class SquareSpawnerModel : Model
{
    private float _minX,_minY,_maxX,_maxY;
    private int _maxSquareCount;

    public float minX
    {
        get => _minX;
        set => _minX = value;
    }
    public float minY
    {
        get => _minY;
    }
    public float maxX
    {
        get => _maxX;
    }
    public float maxY
    {
        get => _maxY;
    }
    public int maxSquareCount
    {
        get => _maxSquareCount;
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
