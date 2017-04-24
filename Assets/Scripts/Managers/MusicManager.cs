using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

  #region Fields

  private const float PITCH_RATIO = 0.03f;
  private const float MAX_PITCH = 1.8f;

  private AudioSource audioSource;
  private float initialPitch;

  #endregion

	#region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void Start() {
    initialPitch = audioSource.pitch;
  }

  void OnEnable() {
    EventManager.StartListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StartListening<WaveOverEvent>(OnWaveOverEvent);
    EventManager.StartListening<GameOverEvent>(OnGameOverEvent);
  }

  void OnDisable() {
    EventManager.StopListening<EnemyHitEvent>(OnEnemyHitEvent);
    EventManager.StopListening<WaveOverEvent>(OnWaveOverEvent);
    EventManager.StopListening<GameOverEvent>(OnGameOverEvent);
  }

  #endregion

  #region Event Behaviour

  void OnEnemyHitEvent(EnemyHitEvent enemyHitEvent) {
    if(audioSource.pitch < MAX_PITCH)
      audioSource.pitch = audioSource.pitch + PITCH_RATIO;
  }

  void OnWaveOverEvent(WaveOverEvent waveOverEvent) {
    audioSource.pitch = initialPitch;
  }

  void OnGameOverEvent(GameOverEvent gameOverEvent) {
    audioSource.pitch = 3;
  }

  #endregion

}
