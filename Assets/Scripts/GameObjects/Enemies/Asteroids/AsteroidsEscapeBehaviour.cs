using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AsteroidsEscapeBehaviour : MonoBehaviour {

  #region Fields

  private float ESCAPE_TIME = 0.2f;
  private float ESCAPE_SPEED = 1.2f;
  private List<GameObject> asteroids;
  private LineRenderer lineRenderer;

  #endregion

  #region Mono Behaviour

  void Awake() {
    asteroids = GetComponent<AsteroidSpawner>().Asteroids;
  }

  void OnEnable() {
    EventManager.StartListening<PlayerShotEvent>(OnPlayerShotEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerShotEvent>(OnPlayerShotEvent);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerShotEvent(PlayerShotEvent playerShotEvent) {
    GameObject shot = playerShotEvent.Shot;
    for (int i = 0; i < 100; i++) {
      Vector2 shotPosition = shot.transform.position + i * 0.1f * shot.transform.up;
      asteroids.ForEach(x => { 
        if (((Vector2) x.transform.position - (Vector2) shotPosition).magnitude < 0.5f) {
          StartCoroutine(EscapeRoutine(x.transform, shot.transform));
          RotateAroundShot(x.transform, shot.transform);
        }
      });
    }
  }

  #endregion

  #region Private Behaviour

  private IEnumerator EscapeRoutine(Transform asteroid, Transform shot) {
    float initialTime = Time.time;
    while (initialTime + ESCAPE_TIME > Time.time) {
      asteroid.position = (Vector2) asteroid.position + (Vector2) asteroid.up * Time.deltaTime * ESCAPE_SPEED;
      yield return null;
    } 
  }

  private void RotateAroundShot(Transform asteroid, Transform shot) {
    Vector3 vectorToTarget = shot.position - asteroid.position;
    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
    asteroid.rotation = Quaternion.Euler(new Vector3(0, 0, asteroid.rotation.eulerAngles.z * angle));
  }

  #endregion

}
