using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]  private float maxSpeed, minSpeed, slowdownSpeed;
    [SerializeField] private PlayerView playerView;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = new PlayerController(playerView,
            new PlayerModel(playerView,maxSpeed,minSpeed,slowdownSpeed));
    }

    public void OnPointerDown()
    {
        _playerController.OnPointerDown();
    }
    public void OnPointerDrag()
    {
        _playerController.OnPointerDrag();
    }
    public void OnPointerUp()
    {
        _playerController.Move();
    }
    public void Stop()
    {
        _playerController.Stop();
    }
    
}
