using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class PlayerController : Controller
{
    private CancellationTokenSource _cts;
    private Queue<Vector3> _pathPoints;
    
    private PlayerView _view;
    private PlayerModel _model;

    public PlayerController(PlayerView view, PlayerModel model) : base(view, model)
    {
        _view = view;
        _model = model;
        _pathPoints = new Queue<Vector3>();
    }

    public async void Move()
    {
        Stop();
        _cts = new CancellationTokenSource();
        try
        {
            await _view.MoveProcess(_pathPoints.ToArray(), _cts.Token, _model.maxSpeed, _model.minSpeed,
                _model.slowdownSpeed);
        }
        catch (OperationCanceledException)
        {
            Debug.Log("New way");
        }
    }

    private Vector3 InitWay()
    {
        var screenPosition = Input.mousePosition;
        if (Camera.main != null)
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 1;
            return worldPosition;
        }

        return Vector3.zero;
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
    private void AddPoint()
    {
        var worldPosition = InitWay();
        if (_pathPoints.Count == 0 || Vector3.Distance(worldPosition, _pathPoints.Last()) > 1f)
        {
            _pathPoints.Enqueue(worldPosition);
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
}