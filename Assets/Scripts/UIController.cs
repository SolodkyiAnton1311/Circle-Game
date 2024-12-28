using TMPro;
using UniRx;
using UnityEngine;
public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI rangeText; 
    
    [SerializeField] public ReactiveProperty<float> scoreInvoker = new();
    [SerializeField] public ReactiveProperty<float> rangeInvoker = new();
    
    private readonly CompositeDisposable _disposable = new();
    
    private void Start()
    {
        scoreInvoker.Value = PlayerPrefs.GetFloat(Helper.Score,0);
        scoreInvoker.Subscribe(i =>
        {
            UpdateText(scoreText,i);
            UpdateSave(Helper.Score, i);
        }).AddTo(_disposable);
        rangeInvoker.Value = PlayerPrefs.GetFloat(Helper.RangeKey,0);
        rangeInvoker.Subscribe(i =>
        {
            UpdateText(rangeText,i);
            UpdateSave(Helper.RangeKey, i);
        }).AddTo(_disposable);
    }
    private void UpdateText(TextMeshProUGUI someText,float value)
    {
        someText.text = value.ToString();
    }
    private void UpdateSave(string key,float i)
    {
        PlayerPrefs.SetFloat(key,i);
    }
}