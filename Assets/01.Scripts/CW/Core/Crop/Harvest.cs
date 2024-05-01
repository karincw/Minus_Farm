using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CW
{

    public class Harvest : MonoBehaviour
    {
        [SerializeField] private RectTransform moveCanvas;
        private RectTransform _myRect;
        private Sprite _cropSprite;
        [SerializeField] private Image _mover;

        private void Awake()
        {
            _myRect = GetComponent<RectTransform>();
            _cropSprite = GetComponent<Image>().sprite;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                HarvestStart(new Vector3(0, 0));
            }
        }
        public void HarvestStart(Vector2 startPos)
        {
            Vector3 endPos = _myRect.InverseTransformPoint(moveCanvas.position);

            startPos = Camera.main.ScreenToWorldPoint(startPos);

            var target = Instantiate(_mover, moveCanvas);
            target.rectTransform.anchoredPosition = startPos;
            target.GetComponent<Image>().sprite = _cropSprite;

            target.rectTransform.anchoredPosition = endPos;
        }
    }

}