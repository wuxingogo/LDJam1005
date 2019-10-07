using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using wuxingogo.Runtime;
using wuxingogo.tools;

public class EndingListener : XMonoBehaviour
{
    public Animator _animtor = null;
    public Image bg = null;
    private void Start()
    {
        DelegateUtils.addListener("GameEnded", GameEnded);
    }
    [X]
    void GameEnded()
    {
        var action = bg.DOFade(1, 2);
        action.onComplete += PlayAnim;
    }
    [X]
    void PlayAnim()
    {
        _animtor.gameObject.SetActive(true);
        _animtor.Play("quit_game");
        
        AsynchronousFunc.Delaytime(5.0f, ()=> SceneManager.LoadScene(0));
    }
}
