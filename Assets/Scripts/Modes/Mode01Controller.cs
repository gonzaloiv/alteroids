using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mode01Controller : MonoBehaviour {

	#region Fields

  private const int WAVE_AMOUNT = 5;

  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
  }

  void Start() {
    asteroidSpawner.SpawnAsteroids(WAVE_AMOUNT);
  }

  void OnEnable() {
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
  }

  #endregion 

  #region Event Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    SceneManager.LoadScene(0);
  }

  #endregion

}
