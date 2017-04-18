using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class UFOWeapon : MonoBehaviour {

  #region Mono Behaviour

  [SerializeField] private float SHOT_SPEED = .175f;
  [SerializeField] private GameObject shotPrefab;

  private GameObjectPool shots;
  private Renderer rend;
  private GameObject player;
  private float shotTime;
  private IEnumerator shootingRoutine;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shotTime = Time.time;
    shots = new GameObjectPool("UFOShots", shotPrefab, 10, transform.parent);
  }

  void Update() {
    FocusOnPlayer();
  }

  void OnEnable() {
    shootingRoutine = ShootingRoutine();
    StartCoroutine(shootingRoutine);
  }

  void OnDisable() {
    StopCoroutine(shootingRoutine);
  }

  #endregion

  #region Public Behaviour

  public void Initialize(GameObject player, Renderer rend) {
    this.player = player;
    this.rend = rend;
  }

  #endregion

  #region Private Behaviour

  private IEnumerator ShootingRoutine() {
    while(gameObject.activeSelf) {
      yield return new WaitForSeconds(SHOT_SPEED);
      GameObject shot = shots.PopObject();
      shot.transform.position = transform.position + transform.up / 3;
      shot.transform.rotation = transform.rotation;
      shot.SetActive(true);
    }
  }

  private void FocusOnPlayer() {
    Vector3 dir = player.transform.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    // The angle focus transform.up on the direction of the target
    Quaternion q = Quaternion.AngleAxis(angle + -90, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, q, 100);
  }

  #endregion

}
