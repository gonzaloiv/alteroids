using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject player;
  [SerializeField] private GameObject[] ufosPrefabs;
  private GameObjectPool ufosLg;
  private GameObjectPool ufosSm;
  private Vector2 screenSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    ufosLg = new GameObjectPool("UFOsLg", ufosPrefabs[0], 2, transform);
    ufosSm = new GameObjectPool("UFOsSm", ufosPrefabs[1], 2, transform);
  }

  void Start() {
    StartCoroutine(UFOSpawningRoutine());
  }

  #endregion

  #region Public Behaviour

  public void SpawnUFO(UFOType ufoType) {
    GameObject ufo;
    switch (ufoType) {
      case UFOType.Large:
        ufo = ufosLg.PopObject();
        break;
      case UFOType.Small:
        ufo = ufosSm.PopObject();
        ufo.GetComponent<UFOSmBehaviour>().Initialize(player);
        break;
      default:
        return;
    }
    ufo.GetComponentInChildren<UFOWeapon>().Initialize(player, ufo.GetComponent<Renderer>());
    ufo.transform.position = RandomUFOPosition();
    ufo.SetActive(true);
  }

  #endregion

  #region Private Behaviour

  private IEnumerator UFOSpawningRoutine() {
    while (gameObject.activeSelf) {
//      yield return new WaitForSeconds(Random.Range(3, 10)); 
      yield return new WaitForSeconds(Random.Range(1, 3)); // DEBUG
      int n = Random.Range(0, 10);
      UFOType type = n > 7 ? UFOType.Small : UFOType.Large;
      SpawnUFO(type);
    }
  }

  private Vector2 RandomUFOPosition() {
    int n = Random.Range(0, 2);
    if (n == 0)
      return new Vector2(new float[] { -screenSize.x, screenSize.x }[Random.Range(0, 2)], Random.Range(-screenSize.y, screenSize.y));
    else
      return new Vector2(Random.Range(-screenSize.x, screenSize.x), new float[] { -screenSize.y, screenSize.y }[Random.Range(0, 2)]);
  }

  #endregion

}
