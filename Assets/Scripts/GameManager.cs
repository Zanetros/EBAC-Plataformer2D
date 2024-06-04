using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject player;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("Reference")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    private GameObject currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        currentPlayer = Instantiate(player);
        currentPlayer.transform.position = startPoint.transform.position;
        currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }
}
