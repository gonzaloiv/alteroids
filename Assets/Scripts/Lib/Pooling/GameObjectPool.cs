using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// Based on TheLiquidFire's: https://theliquidfire.wordpress.com/2015/07/06/object-pooling/
public class GameObjectPool : IPool {

  #region Fields

  public int ActiveObjects { get { return objects.Where(x => x.activeSelf).Count(); } } 

  private GameObject prefab;
  private List<GameObject> objects = new List<GameObject>();
  GameObject poolGameObject;

  #endregion

  #region Contructors

	public GameObjectPool(string poolName, GameObject prefab, int initialObjectAmount, Transform parent) {
    this.prefab = prefab;
    poolGameObject = new GameObject(poolName);
    poolGameObject.transform.parent = parent;
    Prepopulate(initialObjectAmount);
  }

  #endregion

  #region Public Behaviour

  public GameObject PopObject() {
    foreach (GameObject obj in objects) {
      if (!obj.activeInHierarchy)
        return obj;
    }
    return PushObject();
  }

  public GameObject PushObject() {
    GameObject obj = MonoBehaviour.Instantiate(prefab, poolGameObject.transform);
    obj.SetActive(false);
    objects.Add(obj);

    return obj;
  }

  #endregion

  #region Private Behaviour

  private void Prepopulate(int objectAmount) {
    for (int i = 0; i < objectAmount; i++)
      PushObject(); 
  }

  #endregion

}