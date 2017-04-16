using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	#region Fields

  private const int WAVE_AMOUNT = 5;

  [SerializeField] private Text pressSpace;
  [SerializeField] private GameObject asteroids;
  private AsteroidSpawner asteroidSpawner;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroidSpawner = asteroids.GetComponent<AsteroidSpawner>();
  }

  void Start() {
    asteroidSpawner.SpawnAsteroids(5, AsteroidType.Large);
    asteroidSpawner.SpawnAsteroids(5, AsteroidType.Medium);
    asteroidSpawner.SpawnAsteroids(5, AsteroidType.Small);
    pressSpace.GetComponent<Animator>().Play("BlinkingText");
  }

  void OnEnable() {
    EventManager.StartListening<SpaceInput>(OnSpaceInput);
    EventManager.StartListening<ReturnInput>(OnReturnInput);
  }

  void OnDisable() {
    EventManager.StopListening<SpaceInput>(OnSpaceInput);
    EventManager.StopListening<ReturnInput>(OnReturnInput);
  }

  #endregion 

  #region Event Behaviour

  void OnSpaceInput(SpaceInput spaceInput) {
    SceneManager.LoadScene(1);
  }

  void OnReturnInput(ReturnInput returnInput) {
    SceneManager.LoadScene(1);
  }

  #endregion

}
