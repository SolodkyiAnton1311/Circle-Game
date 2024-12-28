using UnityEngine;
using UniRx;
public class UIController : Controller
{
   private UIView _view;
   private UIModel _model;
    public UIController(UIView view, UIModel model) : base(view, model)
    {
        _view = view;
        _model = model;
       
    }
    public void AddScore()
    {
        _model.ScoreInvoker.Value++;
    }
    public void AddRange(float value)
    {
        _model.RangeInvoker.Value += value;
    }
    public void Subscribe()
    {
        _model.ScoreInvoker.Value = PlayerPrefs.GetFloat(Helper.Score,0);
        _model.ScoreInvoker.Subscribe(i =>
        {
            _view.UpdateText(_view.scoreText,i);
            UpdateSave(Helper.Score, i);
        }).AddTo(_model.Disposable);
        _model.RangeInvoker.Value = PlayerPrefs.GetFloat(Helper.RangeKey,0);
        _model.RangeInvoker.Subscribe(i =>
        {
            _view.UpdateText(_view.rangeText,i);
            UpdateSave(Helper.RangeKey, i);
        }).AddTo(_model.Disposable);
    }
    private  void UpdateSave(string key,float i)
    {
        PlayerPrefs.SetFloat(key,i);
    }
}