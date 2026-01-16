using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    public void StartMoving(Vector2 direction)
    {
        StartCoroutine(MoveCoroutine(direction));
    }
    
    private IEnumerator MoveCoroutine( Vector2 direction )
    {
        while (true)
        {
            transform.Translate(direction * (_speed * Time.deltaTime));
            yield return null;
        }
    }
}
