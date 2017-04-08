using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	#region Fields

  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
  }

  #endregion 

}
