using TMPro;
using UniRx;
using UnityEngine;
public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rangeText; 
    
    [SerializeField] public ReactiveProperty<int> scoreInvoker = new();
    [SerializeField] public ReactiveProperty<float> rangeInvoker = new();
    
    private CompositeDisposable disposable = new();
    
    private void Start()
    {
        scoreInvoker.Value = PlayerPrefs.GetInt(Helper.HealthKey,0);
        scoreInvoker.Subscribe(i =>
        {
            UpdateText(scoreText,i);
            UpdateSave(Helper.HealthKey, i);
        }).AddTo(disposable);
        rangeInvoker.Value = PlayerPrefs.GetFloat(Helper.RangeKey,0);
        rangeInvoker.Subscribe(i =>
        {
            UpdateText(rangeText,i);
            UpdateSave(Helper.RangeKey, i);
        }).AddTo(disposable);
    }

    private void UpdateText(TextMeshProUGUI someText,int value)
    {
        someText.text = $"Score : {value}";
    }
    private void UpdateText(TextMeshProUGUI someText,float value)
    {
        someText.text = $"Summary Range : {value}";
    }
    private void UpdateSave(string key,int i)
    {
        PlayerPrefs.SetInt(key,i);
    }
    private void UpdateSave(string key,float i)
    {
        PlayerPrefs.SetFloat(key,i);
    }
}