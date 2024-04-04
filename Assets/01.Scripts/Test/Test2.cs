using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test2 : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var tile = _tilemap.GetTile(_tilemap.LocalToCell(mousePos));

            Debug.Log(tile);
        }
    }
}
