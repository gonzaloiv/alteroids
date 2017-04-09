using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMd : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return AsteroidType.Medium; } }
  public int Pieces { get { return 4; } } 
  public float Speed { get { return 2; } } 
  public int Score { get { return 50; } }

}
