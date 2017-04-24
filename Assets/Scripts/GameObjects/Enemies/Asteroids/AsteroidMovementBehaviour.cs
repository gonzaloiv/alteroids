using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private int[] angle;
  private IAsteroid asteroid;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroid = GetComponent<IAsteroid>();
  }
    
  void OnEnable() {
    transform.Rotate(new Vector3(0, 0, Random.Range(angle[0], angle[1])));
  }

  void Update() {
    transform.position = (Vector2) transform.position + (Vector2) transform.up * asteroid.Speed * Time.deltaTime;
  }

  #endregion

}
