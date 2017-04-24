using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private ParticleSystem explosionParticlesPrefab;
  private ParticleSystem explosionParticles;
  private IEnemy enemy;

  private int currentLives;

  #endregion

  #region Mono Behaviour

  void Awake() {
    explosionParticles = Instantiate(explosionParticlesPrefab, transform.parent);
    enemy = GetComponent<IEnemy>();
  }

  void OnEnable() {
    currentLives = enemy.Lives;
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Player) {
      PlayParticles(explosionParticles);
      EventManager.TriggerEvent(new EnemyHitEvent(enemy.Score));
      currentLives--;
      if(currentLives <= 0)
        gameObject.SetActive(false);
    }
  }

  #endregion

  #region Private Behaviour

  private void PlayParticles(ParticleSystem particles) {
    particles.transform.position = transform.position;
    particles.Play();
  }

  #endregion

}
