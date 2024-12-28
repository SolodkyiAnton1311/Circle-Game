public class PlayerModel : Model
{
    private float _maxSpeed, _minSpeed, _slowdownSpeed;
    public PlayerModel(View view, float maxSpeed, float minSpeed, float slowdownSpeed) : base(view)
    {
        _maxSpeed = maxSpeed;
        _minSpeed = minSpeed;
        _slowdownSpeed = slowdownSpeed;
    }
    public float maxSpeed
    {
        get => _maxSpeed;
    }
    public float minSpeed
    {
        get => _minSpeed;
    }
    public float slowdownSpeed
    {
        get => _slowdownSpeed;
    }
}
