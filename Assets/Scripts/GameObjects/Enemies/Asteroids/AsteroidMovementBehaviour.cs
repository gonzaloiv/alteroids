using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementBehaviour : MonoBehaviour {

  #region Fields

  private IAsteroid asteroid;
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroid = GetComponent<IAsteroid>();
  }

  void OnEnable() {
    direction = RandomAsteroidDirection();
    transform.Rotate(direction);
  }

  void Update() {
    transform.position = (Vector2) transform.position + (Vector2) transform.up * asteroid.Speed * Time.deltaTime;
  }

  #endregion

  #region Private Behaviour

  private Vector3 RandomAsteroidDirection() {
    return new Vector3(0, 0, Random.Range(-90, 90));
  }

  #endregion

}
