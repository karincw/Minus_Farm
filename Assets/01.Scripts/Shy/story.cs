using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class story : MonoBehaviour
{
    [SerializeField] GameObject viewPos;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject wallet;
    
    [SerializeField] GameObject shadow;
    [SerializeField] Transform happy;
    [SerializeField] Transform bad;
    [SerializeField] Transform nong;
    [SerializeField] Transform money;
    [SerializeField] Image Sign;

    private void Awake()
    {
        shadow.SetActive(false);
        paper.SetActive(false);
        happy.parent.gameObject.SetActive(false);
        bad.gameObject.SetActive(false);
        money.gameObject.SetActive(false);
        nong.gameObject.SetActive(false);
        wallet.SetActive(false);
        wallet.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Start()
    {
        transform.DOMove(transform.position, 2f).OnComplete(()=>
        viewPos.transform.DOLocalMoveY(-1000, 2f).OnComplete(()=>transform.DOMove(transform.position, 0.7f).
        OnComplete(()=>viewPos.transform.DOLocalMoveY(-250, 1.5f).OnStart(()=> 
        {
            paper.SetActive(true);
            transform.DOMove(transform.position, 2.3f).OnComplete(() => viewPos.transform.DOLocalMoveY(-1000, 1.5f).OnStart(()=>smile()));
        }))));   
    }

    void smile()
    {
        happy.parent.gameObject.SetActive(true);
        happy.DORotate(new Vector3(0, 0, -30), 0.4f).OnComplete(()=> 
        happy.DORotate(new Vector3(0, 0, 35), 0.7f).SetLoops(12, LoopType.Yoyo).
        OnStart(()=>transform.DOMove(transform.position, 4f).OnComplete(()=> viewPos.transform.DOLocalMoveY(-250, 2f).
        OnComplete(()=> StartCoroutine(nameSign())))).OnComplete(()=> 
        {
            //shadow.SetActive(true);
            happy.gameObject.SetActive(false);
            money.gameObject.SetActive(true);
        }));
    }

    IEnumerator nameSign()
    {
        yield return new WaitForSeconds(1.3f);

        while (Sign.fillAmount > 0)
        {
            Sign.fillAmount -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        viewPos.transform.DOLocalMoveY(-1000, 1.8f).OnComplete(()=>GiveMoney());
    }

    void GiveMoney()
    {
        paper.SetActive(false);
        wallet.SetActive(true);
        transform.DOMove(transform.position, 0.6f).OnComplete(()=>viewPos.transform.DOLocalMoveY(-250, 1f).OnComplete(() =>
        {
            transform.DOMove(transform.position, 0.6f).OnComplete(() =>
            {
                wallet.transform.GetChild(0).gameObject.SetActive(true);
                money.gameObject.SetActive(true);
                transform.DOMove(transform.position, 1.5f).OnComplete(() =>
                {
                    money.gameObject.SetActive(false);
                    viewPos.transform.DOLocalMoveY(-1000, 1f).OnComplete(() =>
                    {   
                        bad.gameObject.SetActive(true);
                        shadow.SetActive(true);
                        transform.DOMove(transform.position, 0.4f).OnComplete(() => NongAnime());
                    });
                });
            });
        }));
    }

    void NongAnime()
    {
        bad.gameObject.SetActive(false);
        nong.gameObject.SetActive(true);
        nong.DORotate(new Vector3(0, 0, -50f), 0.66f).SetLoops(6, LoopType.Yoyo).OnComplete(() => { SceneManager.LoadScene("TutorialScene"); });

        
    }
}
