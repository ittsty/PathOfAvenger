using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject item;

    [SerializeField] private Gamemaneger Gm;
    private void OnEnable()
    {
        Gm._spawnitem += Spawn;
    }
    private void OnDisable()
    {
        Gm._spawnitem -= Spawn;
    }

    private void Spawn()
    {
        GameObject _effect = Instantiate(effect, spawnpoint.position, spawnpoint.rotation);
        Sound_Manager.instance.playItem();
        item.gameObject.SetActive(true);
        Gm._spawnitem -= Spawn;
    }
}
