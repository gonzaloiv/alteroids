using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidCollisionBehaviour : MonoBehaviour {

  #region Fields

  private AsteroidSpawner asteroidSpawner;
  private IAsteroid asteroid;

  private int currentLives;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = transform.parent.parent.GetComponent<AsteroidSpawner>();
    asteroid = GetComponent<IAsteroid>();

  }

  void OnEnable() {
    currentLives = asteroid.Lives;
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Player) {
      currentLives--;
      if (currentLives <= 0) {
        AsteroidType asteroidType = (int) asteroid.Type < Enum.GetNames(typeof(AsteroidType)).Length - 1 ? asteroid.Type + 1 : asteroid.Type; 
        asteroidSpawner.SpawnAsteroids(asteroid.Pieces, asteroidType, transform.position);
      }
    }
  }

  #endregion


}
