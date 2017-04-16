using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mode03Controller : MonoBehaviour {

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
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StartListening<WaveOverEvent>(OnWaveOverEvent);
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
  }

  void OnDisable() {
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
    EventManager.StopListening<WaveOverEvent>(OnWaveOverEvent);
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
  }

  #endregion 

  #region Event Behaviour

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
	  StartCoroutine(GameOverRoutine());
  }

  void OnWaveOverEvent(WaveOverEvent waveOverEvent) {
    asteroidSpawner.SpawnAsteroids(INITIAL_AMOUNT + INCREMENT_AMOUNT * current_wave);
    current_wave++;
  }

  void OnSpaceInput(SpaceInput spaceInput) {
    audioSource.Play();
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
