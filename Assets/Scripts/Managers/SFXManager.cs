using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	#region Fields

  // Menus
  [SerializeField] private AudioClip selectMode;

  // Game Mechanics
  [SerializeField] private AudioClip asteroidHit;
  [SerializeField] private AudioClip playerShot;
  [SerializeField] private AudioClip playerHit;
  [SerializeField] private AudioClip playerSpawn;
  [SerializeField] private AudioClip gameOver;

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable () {
    EventManager.StartListening<SelectModeEvent>(OnSelectModeEvent);
    EventManager.StartListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StartListening<PlayerShotEvent>(OnPlayerShotEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<PlayerSpawnEvent>(OnPlayerSpawnEvent);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnDisable () {
    EventManager.StopListening<SelectModeEvent>(OnSelectModeEvent);
    EventManager.StopListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StopListening<PlayerShotEvent>(OnPlayerShotEvent);
    EventManager.StopListening<PlayerSpawnEvent>(OnPlayerSpawnEvent);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
  }

  #endregion

  #region Event Behaviour


  void OnSelectModeEvent(SelectModeEvent selectModeEvent) {
    audioSource.PlayOneShot(selectMode);
  }

  void OnAsteroidHitEvent(AsteroidHitEvent asteroidHitEvent) {
    audioSource.PlayOneShot(asteroidHit);
  }

  void OnPlayerShotEvent(PlayerShotEvent playerShotEvent) {
    audioSource.PlayOneShot(playerShot);
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    audioSource.PlayOneShot(playerHit);
  }

  void OnPlayerSpawnEvent(PlayerSpawnEvent playerSpawnEvent) {
    audioSource.PlayOneShot(playerSpawn);
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    audioSource.PlayOneShot(gameOver);
  }

  #endregion

}
