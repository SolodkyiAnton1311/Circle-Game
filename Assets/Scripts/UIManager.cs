using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private UIView view;
    private UIController uiController;
    public UIController UIController
    {
        get => uiController;
    }

    private void Awake()
    {
        uiController = new UIController(view, new UIModel(view));
        UIController.Subscribe();
    }
}
