using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour, IMove
{
   [SerializeField] private float maxSpeed, minSpeed, slowdownSpeed;
    private Camera _camera;
    private List<Vector3> _pathPoints;
    [Inject]
    private UIController _uiController;
    private CancellationTokenSource _cts;
    void Start()
    {
        _camera = Camera.main;
        _pathPoints = new List<Vector3>();
    }
    public async void Move()
    {
        Stop();
        _cts = new CancellationTokenSource();
        try
        {
            await MoveProcess(_pathPoints.ToArray(), _cts.Token);
        }
        catch (OperationCanceledException)
        {
            Debug.Log("New way");
        }
    }
    private async UniTask MoveProcess(Vector3[] worldPositions, CancellationToken cancellationToken)
    {
        var speed = maxSpeed;
        foreach (var position in worldPositions)
        {
            //Погрешность округления
            while (Vector3.Distance(transform.position, position) > 0.01f)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await UniTask.Yield(PlayerLoopTiming.Update);
                Step(position, speed);
                if (speed > minSpeed)
                    speed -= slowdownSpeed;
                
            }
        }
    }
    private void Step(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        _uiController.rangeInvoker.Value += Helper.CalculateDistance(target, transform.position);
        transform.position += direction * speed * Time.deltaTime;
        
    }
    private Vector3 InitWay()
    {
        var screenPosition = Input.mousePosition;
        var worldPosition = _camera.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 1;
        return worldPosition;
    }
    public void Stop()
    {
        if (_cts != null)
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }
    public void OnPointerDown()
    {
        
        _pathPoints.Clear();
        AddPoint();
    }
    public void OnPointerDrag()
    {
        AddPoint();
    }
   
    private void AddPoint()
    {
        var worldPosition = InitWay();
        if (_pathPoints.Count == 0 || Vector3.Distance(worldPosition, _pathPoints[_pathPoints.Count - 1]) > 1f)
        {
            _pathPoints.Add(worldPosition);
        }
    }
 
    
}