using DG.Tweening;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System.Collections.Generic;

namespace CW
{

    public class Crow : MonoBehaviour
    {
        private Vector2 currentPosition;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                MoveTile();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                MoveExit();
            }
        }

        public void MoveTile()
        {

            List<string> strList = new List<string>();

            Vector2 startPos = CrowManager.Instance.crowStartPos;
            startPos.y += Random.Range(-1, 3);
            transform.position = startPos;

            Vector3Int pos = CropManager.Instance.GetRandomCropPos();
            currentPosition = (Vector3)pos;

            transform.DOMove(pos, 2.5f).OnComplete(() => { DestroyCrop(); });
        }

        public void DestroyCrop()
        {
            Debug.Log(1);
            Vector3Int currentIntPos = new Vector3Int((int)currentPosition.x, (int)currentPosition.y, 0);

            CropManager.Instance.SetGroundTile(currentIntPos);
        }

        public void MoveExit()
        {
            Vector2 endPos = CrowManager.Instance.crowEndPos;
            endPos.y += Random.Range(-3, 3);

            transform.DOMove(endPos, 2f);

        }

    }

}