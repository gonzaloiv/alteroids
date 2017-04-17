using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeEnemiesController : MonoBehaviour {

  #region Fields

  [SerializeField] private int INITIAL_AMOUNT = 5;
  [SerializeField] private int INCREMENT_AMOUNT = 2;

  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;
  private int current_wave = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
  }

  void OnEnable() {
    EventManager.StartListening<WaveOverEvent>(OnWaveOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<WaveOverEvent>(OnWaveOverEvent);
  }

  #endregion 

  #region Event Behaviour

  void OnWaveOverEvent(WaveOverEvent waveOverEvent) {
    asteroidSpawner.SpawnAsteroids(INITIAL_AMOUNT + INCREMENT_AMOUNT * current_wave);
    current_wave++;
  }

  #endregion

}
