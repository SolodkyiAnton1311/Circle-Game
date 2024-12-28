using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerView : View
{
    [Inject]
    private UIManager _uiManager;
    public async UniTask MoveProcess(Vector3[] worldPositions, CancellationToken cancellationToken,float maxSpeed,float minSpeed,float slowdownSpeed)
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
        _uiManager.UIController.AddRange(Helper.CalculateDistance(target, transform.position));
        transform.position += direction * speed * Time.deltaTime;
    }
}
