using UnityEngine;
using System.Collections;

public class tileScr : MonoBehaviour
{
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Enemys;
    public Transform NextTilePos;

    public GameObject[] NextTiles;
    void Start()
    {
        LeftWall.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStateMachine>() != null)
        {
            StartFight();
            GetComponent<BoxCollider>().enabled = false;
        }

    }
    public void StartFight()
    {
        Debug.Log("StartFight");
        LeftWall.SetActive(true);
        RightWall.SetActive(true);
        Enemys.SetActive(true);
        for (int i = 0; i < Enemys.transform.childCount; i++)
        {
            Enemys.transform.GetChild(i).GetComponent<EnemyStateMachine>().DestroyEvent.AddListener(CheckEnemys);
        }
    }
    public void CheckEnemys()
    {

        Debug.Log("checkenemys");
        StartCoroutine("CheckEnemyss");

        
    }
    IEnumerator CheckEnemyss()
    {
        yield return new WaitForSeconds(.5f);
        if (Enemys.transform.childCount <= 0)
        {
            Debug.Log("endLevel");
            RightWall.SetActive(false);
            Instantiate(NextTiles[Random.Range(0, NextTiles.Length)], NextTilePos.position, Quaternion.identity);
        }
        
    }
    
}
