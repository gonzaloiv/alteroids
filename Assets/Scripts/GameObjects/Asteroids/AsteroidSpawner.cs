using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AsteroidSpawner : MonoBehaviour {

  #region Fields

  private const int WAVE_AMOUNT = 30;

  private Vector2 screenSize;
  [SerializeField] private GameObject[] asteroidsPrefabs;
  private GameObjectPool asteroidsLg;
  private GameObjectPool asteroidsMd;
  private GameObjectPool asteroidsSm;
  private List<GameObject> asteroids = new List<GameObject>();

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    asteroidsLg = new GameObjectPool("AsteroidsLg", asteroidsPrefabs[0], 5, transform);
    asteroidsMd = new GameObjectPool("AsteroidsMd", asteroidsPrefabs[1], 10, transform);
    asteroidsSm = new GameObjectPool("AsteroidsSm", asteroidsPrefabs[2], 20, transform);
  }

  void Start() {
    SpawnAsteroids();
  }

  void Update() {
    if(asteroids.Where(x => x.activeSelf).Count() == 0)
      SpawnAsteroids();
  }

  #endregion

  #region Public Behaviour

  public void SpawnAsteroids(int amount = WAVE_AMOUNT) {
    for(int i = 0; i < amount; i++) {
      GameObject asteroid = asteroidsLg.PopObject();
      asteroid.transform.position = RandomAsteroidPosition();
      asteroids.Add(asteroid);
      asteroid.SetActive(true);
    }
  }

  #endregion

  #region Private Behaviour

  private Vector2 RandomAsteroidPosition() {
    Vector2 position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    while(Physics2D.OverlapCircle(position, 1))
      position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    return position;
  }

  #endregion
	
}
