using UnityEngine;
using Zenject;
public class SquareSpawnerView : View
{
  [Inject]
  private SquarePool _squarePool;
  
  public void GenerateSquare(Vector3 position)
  {
    _squarePool.Spawn().transform.position = position;
  }

}
