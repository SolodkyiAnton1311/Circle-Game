using UniRx;

public class UIModel : Model
{
    public ReactiveProperty<float> ScoreInvoker = new();
    public ReactiveProperty<float> RangeInvoker = new();
    public readonly CompositeDisposable Disposable = new();
    public UIModel(View view) : base(view)
    {
    }
}