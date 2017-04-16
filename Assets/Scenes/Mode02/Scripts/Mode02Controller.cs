using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mode02Controller : MonoBehaviour {

	#region Fields

  private const int INITIAL_AMOUNT = 5;
  private int INCREMENT_AMOUNT = 2;

  [SerializeField] private GameObject gameOverScreenPrefab;
  private GameObject gameOverScreen;

  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;

  private AudioSource audioSource;
  private int current_wave = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
    gameOverScreen = Instantiate(gameOverScreenPrefab, transform);
    gameOverScreen.SetActive(false);
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable() {
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<WaveOverEvent>(OnWaveOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StopListening<WaveOverEvent>(OnWaveOverEvent);
  }

  #endregion 

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    audioSource.Play();
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
	  StartCoroutine(GameOverRoutine());
  }

  void OnWaveOverEvent(WaveOverEvent waveOverEvent) {
    asteroidSpawner.SpawnAsteroids(INITIAL_AMOUNT + INCREMENT_AMOUNT * current_wave);
    current_wave++;
  }

  #endregion

  #region Private Behaviour

  private IEnumerator GameOverRoutine() {
  	gameOverScreen.SetActive(true);
  	yield return new WaitForSeconds(1);
	  SceneManager.LoadScene(0);
  }

  #endregion

}
