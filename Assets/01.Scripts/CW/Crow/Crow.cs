using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace CW
{

    public class Crow : MonoBehaviour
    {
        private Vector2 currentPosition;
        [SerializeField] private GameObject destroyCropEffect;
        public bool canThrow = true;
        public bool canMove = true;
        private bool isThrow = false;

        private void Awake()
        {
            canThrow = true;
            canMove = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < .5f)
            {
                DOTween.Kill(this);
                StopAllCoroutines();
                isThrow = true;
                MoveExit();
            }
        }

        public void MoveTile()
        {
            canMove = false;
            List<string> strList = new List<string>();

            Vector2 startPos = CrowManager.Instance.crowStartPos;
            startPos.y += Random.Range(-1, 3);
            transform.position = startPos;

            Vector3Int pos = CropManager.Instance.GetRandomCropPos();
            currentPosition = (Vector3)pos;

            transform.DOMove(pos, 2.5f).OnComplete(() => { StartCoroutine("DestroyCropAndExitCoroutine"); });
        }

        public IEnumerator DestroyCropAndExitCoroutine()
        {
            Vector3Int currentIntPos = new Vector3Int((int)currentPosition.x, (int)currentPosition.y, 0);

            yield return new WaitForSeconds(1);

            if (isThrow) yield break;
            canThrow = false;
            CropManager.Instance.SetGroundTile(currentIntPos);
            Instantiate(destroyCropEffect, transform.position + new Vector3(0, -0.3f), Quaternion.identity);

            yield return new WaitForSeconds(1);

            MoveExit();
        }

        public void MoveExit()
        {
            Vector2 endPos = CrowManager.Instance.crowEndPos;
            endPos.y += Random.Range(-3, 3);

            transform.DOMove(endPos, 2f)
                .OnComplete(() =>
                {
                    canThrow = true;
                    canMove = true;
                    isThrow = false;
                }
                );

        }

    }

}