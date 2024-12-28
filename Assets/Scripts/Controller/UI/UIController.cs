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
        _model.scoreInvoker.Value++;
    }

    public void AddRange(float value)
    {
        _model.rangeInvoker.Value += value;
    }
    
    public void Subscribe()
    {
        _model.scoreInvoker.Value = PlayerPrefs.GetFloat(Helper.Score,0);
        _model.scoreInvoker.Subscribe(i =>
        {
            _view.UpdateText(_view.scoreText,i);
            UpdateSave(Helper.Score, i);
        }).AddTo(_model._disposable);
        _model.rangeInvoker.Value = PlayerPrefs.GetFloat(Helper.RangeKey,0);
        _model.rangeInvoker.Subscribe(i =>
        {
            _view.UpdateText(_view.rangeText,i);
            UpdateSave(Helper.RangeKey, i);
        }).AddTo(_model._disposable);
    }
    private  void UpdateSave(string key,float i)
    {
        PlayerPrefs.SetFloat(key,i);
    }
}