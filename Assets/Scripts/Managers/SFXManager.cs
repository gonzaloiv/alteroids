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

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable () {

    // Menus
    EventManager.StartListening<SelectModeEvent>(OnSelectModeEvent);

    // Game Mechanics
    EventManager.StartListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StartListening<PlayerShotEvent>(OnPlayerShotEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);

  }

  void OnDisable () {

    // Menus
    EventManager.StartListening<SelectModeEvent>(OnSelectModeEvent);

    // Game Mechanics
    EventManager.StartListening<AsteroidHitEvent>(OnAsteroidHitEvent);
    EventManager.StartListening<PlayerShotEvent>(OnPlayerShotEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);

  }

  #endregion

  #region Event Behaviour

  // Menus

  void OnSelectModeEvent(SelectModeEvent selectModeEvent) {
    audioSource.PlayOneShot(selectMode);
  }

  // Game Mechanics

  void OnAsteroidHitEvent(AsteroidHitEvent asteroidHitEvent) {
    audioSource.PlayOneShot(asteroidHit);
  }

  void OnPlayerShotEvent(PlayerShotEvent playerShotEvent) {
    audioSource.PlayOneShot(playerShot);
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    audioSource.PlayOneShot(playerHit);
  }

  #endregion

}
