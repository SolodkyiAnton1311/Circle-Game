using TMPro;
using UnityEngine;
public class UIView : View
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI rangeText;
    public void UpdateText(TextMeshProUGUI someText,float value)
    {
        someText.text = value.ToString();
    }
   
}