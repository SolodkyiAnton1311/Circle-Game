using UniRx;

public class UIModel : Model
{
    public ReactiveProperty<float> scoreInvoker = new();
    public ReactiveProperty<float> rangeInvoker = new();
    public readonly CompositeDisposable _disposable = new();
    public UIModel(View view) : base(view)
    {
    }
}