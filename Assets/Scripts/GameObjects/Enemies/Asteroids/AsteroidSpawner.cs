﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AsteroidSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private bool AreMeteoroids = false;
  [SerializeField] private GameObject[] asteroidsPrefabs;

  public List<GameObject> Asteroids { get { return asteroids; } }
  private List<GameObject> asteroids = new List<GameObject>();

  private GameObjectPool asteroidsLg;
  private GameObjectPool asteroidsMd;
  private GameObjectPool asteroidsSm;
  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    asteroidsLg = new GameObjectPool("AsteroidsLg", asteroidsPrefabs[0], 5, transform);
    asteroidsMd = new GameObjectPool("AsteroidsMd", asteroidsPrefabs[1], 10, transform);
    asteroidsSm = new GameObjectPool("AsteroidsSm", asteroidsPrefabs[2], 20, transform);
  }

  void Update() {
    if (asteroids.Where(x => x.activeSelf).Count() == 0)
      EventManager.TriggerEvent(new WaveOverEvent());
  }

  #endregion

  #region Public Behaviour

  public void SpawnAsteroids(int amount = 5, AsteroidType asteroidType = AsteroidType.Large, Vector2 position = default(Vector2)) {
    for (int i = 0; i < amount; i++) {
      GameObject asteroid;
      switch (asteroidType) {
        case AsteroidType.Large:
          asteroid = asteroidsLg.PopObject();
          break;
        case AsteroidType.Medium:
          asteroid = asteroidsMd.PopObject();
          break;
        case AsteroidType.Small:
          asteroid = asteroidsSm.PopObject();
          break;
        default:
          return;
      }
      asteroid.transform.position = position != default(Vector2) ? position : RandomAsteroidPosition();
      asteroids.Add(asteroid);
      asteroid.SetActive(true);
    }
  }

  #endregion

  #region Private Behaviour

  private Vector2 RandomAsteroidPosition() {
    Vector2 position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    while (Physics2D.OverlapCircle(position, 1))
      position = new Vector2(Random.Range(-screenSize.x, screenSize.x), Random.Range(-screenSize.y, screenSize.y));
    if(AreMeteoroids)
      position = new Vector2(position.x, -screenSize.y - 1); // Sustracts one unit to avoid the wrapping effect
    return position;
  }

  #endregion
	
}
