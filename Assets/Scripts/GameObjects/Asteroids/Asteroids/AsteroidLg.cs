using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLg : MonoBehaviour, IAsteroid {

  public AsteroidType Type { get { return AsteroidType.Large; } }
  public int Pieces { get { return 2; } }
  public float Speed { get { return 1; } } 
  public int Score { get { return 20; } }
	
}
