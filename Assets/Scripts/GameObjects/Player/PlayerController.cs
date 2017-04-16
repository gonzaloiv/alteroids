using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController {

  #region Fields Behaviour

  private float THRUST = 0.5f;
  private float ROTATION_SPEED = 4f;
  private float DECELERATION = 0.99f;
  private float SPACE_UNIT = 0.6f;

  [SerializeField] private ParticleSystem jetParticles;
  [SerializeField] private ParticleSystem explosionParticles;

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
    EventManager.StartListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StartListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StartListening<MoveLeftInput>(OnMoveLeftInput);
    Spawn();
  }

  void OnDisable() {
    EventManager.StopListening<MoveUpInput>(OnMoveUpInput);
    EventManager.StopListening<MoveRightInput>(OnMoveRightInput);
    EventManager.StopListening<MoveLeftInput>(OnMoveLeftInput);
  }

  #endregion

  #region Event Behaviour

  void OnMoveUpInput(MoveUpInput moveUpInput) {
    rb.AddForce(transform.up * THRUST);
    jetParticles.Play();
  }

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

    int tries = 8;
    Vector2 position = Vector2.zero;

    while (Physics2D.OverlapCircle(position, SPACE_UNIT) && tries > 0) {
      position = new Vector2(new float[] { -SPACE_UNIT, SPACE_UNIT }[Random.Range(0, 2)], new float[] { SPACE_UNIT, SPACE_UNIT }[Random.Range(0, 2)]);
      tries--;
    }

    transform.position = position;

  }

  #endregion

}
