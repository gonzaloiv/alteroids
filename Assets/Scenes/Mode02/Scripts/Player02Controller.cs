using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Controller : MonoBehaviour, IPlayerController {

  #region Fields Behaviour

  private float THRUST = 0.5f;
  private float ROTATION_SPEED = 4f;
  private float DECELERATION = 0.99f;
  private float SPACE_UNIT = 0.6f;

  [SerializeField] private ParticleSystem explosionParticles;
  [SerializeField] private ParticleSystem jetParticles;
  private Rigidbody2D rb;
  private Animator anim;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  void Update() {
    rb.velocity *= DECELERATION;
  }

  void OnEnable() {
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    Spawn();
  }

  void OnDisable() {
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
  }

  #endregion

  #region Event Behaviour

  void OnMoveRightInput(MoveRightInput moveRightInput) {
    transform.Rotate(-Vector3.forward * ROTATION_SPEED);
  }

  void OnMoveLeftInput(MoveLeftInput moveLeftInput) {
    transform.Rotate(Vector3.forward * ROTATION_SPEED);
  }

  #endregion

  #region Public Behaviour

  public void Spawn() { // Resets the ship and spawns it in its original position
    SetSpawnPosition();
    gameObject.SetActive(true);
    anim.Play("Spawn");
    EventManager.TriggerEvent(new PlayerSpawnEvent());
  }

  public void Respawn() {
    StartCoroutine(RespawningRoutine());
  }

  public void Disable() {
    StartCoroutine(DisablingRoutine());
  }

  #endregion

  #region Private Behaviour

  private IEnumerator RespawningRoutine() {
    DisableAnimation();
    yield return new WaitForSeconds(0.3f);
    Spawn();
  }

  private IEnumerator DisablingRoutine() {
    DisableAnimation();
    yield return new WaitForSeconds(0.3f);
    gameObject.SetActive(false);
  }

  private void DisableAnimation() {
    explosionParticles.transform.position = transform.position;
    explosionParticles.Play();
    rb.velocity = Vector2.zero;
    rb.angularVelocity = 0;
    anim.Play("Disable");
  }

  private void SetSpawnPosition() {
	transform.position = Vector2.zero;
  }

  #endregion

}
