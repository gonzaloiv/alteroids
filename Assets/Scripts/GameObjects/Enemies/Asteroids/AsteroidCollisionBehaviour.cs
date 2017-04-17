using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollisionBehaviour : MonoBehaviour {

  #region Fields

  private AsteroidSpawner asteroidSpawner;
  private IAsteroid asteroid;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = transform.parent.parent.GetComponent<AsteroidSpawner>();
    asteroid = GetComponent<IAsteroid>();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Player)
      asteroidSpawner.SpawnAsteroids(asteroid.Pieces, (AsteroidType) (int) asteroid.Type + 1, transform.position);
  }

  #endregion


}
