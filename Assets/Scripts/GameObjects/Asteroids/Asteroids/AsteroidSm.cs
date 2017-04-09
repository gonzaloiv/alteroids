using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSm : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return AsteroidType.Small; } }
  public int Pieces { get { return 0; } }
  public float Speed { get { return 3; } } 
  public int Score { get { return 100; } }
  
}
