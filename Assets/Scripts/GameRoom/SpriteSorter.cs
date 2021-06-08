using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField]
    private Transform Back;
    [SerializeField]
    private Transform Front;
    
    public int GetSortingOrder(GameObject target)
	{
        float targetDist = Mathf.Abs(Back.position.y - target.transform.position.y);
        float totalDist = Mathf.Abs(Back.position.y - Front.position.y);

        return (int)(Mathf.Lerp(System.Int16.MinValue, System.Int16.MaxValue, targetDist / totalDist));
	}
}
