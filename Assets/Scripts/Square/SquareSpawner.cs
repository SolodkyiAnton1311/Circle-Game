using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class SquareSpawner : MonoBehaviour
{
  [SerializeField] private float _minX,_minY,_maxX,_maxY;
  
  [Inject]
  private SquareFactory squareFactory;

  [SerializeField] private int maxSquareCount;
  private void Start()
  {
    for (int i = 0; i < maxSquareCount; i++)
      GenerateSquare();
  }
  public void GenerateSquare()
  {
    var go = squareFactory.Create();
    go.transform.position = GetRandomPosition();
  }
  private Vector3 GetRandomPosition()
  {
    var randomX = Random.Range(_minX, _maxX);
    var randomY = Random.Range(_minY, _maxY);
    return new Vector3(randomX,randomY,0f);
  }
}
