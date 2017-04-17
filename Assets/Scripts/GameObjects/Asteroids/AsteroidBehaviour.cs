using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private ParticleSystem explosionParticlesPrefab;
  private ParticleSystem explosionParticles;
  private Rigidbody2D rb;
  private AsteroidSpawner asteroidSpawner;
  private IAsteroid asteroid;

  public Vector3 Direction { get { return direction; } set { direction = value; } }
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    explosionParticles = Instantiate(explosionParticlesPrefab, transform.parent);
    rb = GetComponent<Rigidbody2D>();
    asteroidSpawner = transform.parent.parent.GetComponent<AsteroidSpawner>();
    asteroid = GetComponent<IAsteroid>();
  }

  void OnEnable() {
    transform.Rotate(direction);
  }

  void Update() {
    transform.position = (Vector2) transform.position + (Vector2) transform.up * asteroid.Speed * Time.deltaTime;
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Player) {
      PlayParticles(explosionParticles);
      gameObject.SetActive(false);
      asteroidSpawner.SpawnAsteroids(asteroid.Pieces, (AsteroidType) (int) asteroid.Type + 1, transform.position);
      EventManager.TriggerEvent(new AsteroidHitEvent(asteroid.Score));
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
