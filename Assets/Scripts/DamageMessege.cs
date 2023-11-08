using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessege : MonoBehaviour
{
    [SerializeField] float TimeToLive = 2f;
    float ttl = 2f;


    private void OnEnable()
    {
        ttl = TimeToLive;
    }
    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
