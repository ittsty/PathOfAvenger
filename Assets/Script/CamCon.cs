using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour
{
    private Transform _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }
}
