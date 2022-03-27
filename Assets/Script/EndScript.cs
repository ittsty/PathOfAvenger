using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] private GameObject VDO;
    [SerializeField] private GameObject Panal;

    private void Start()
    {
        StartCoroutine(playVDO());
    }

    IEnumerator playVDO()
    {
        yield return new WaitForSeconds(4f);
        VDO.SetActive(true);
        Panal.SetActive(false);
        yield return new WaitForSeconds(26f);
        SceneManager.LoadScene("Mainmenu");
    }
}
