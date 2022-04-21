using UnityEngine;
using ToolsLevent;
/*
Ama� oyunda verilen renklere g�re karakterin o renge ait zemine basmas�.
renkler oyuncunun se�ti�i item'lere g�re de�i�iklik g�stermektedir.
do�ru renge bast��� s�rece puan kazanacak
yanl�� renge basarsa puan kaybedecek
z�plarsa veya n�tr b�lgeye basarsa puan kazanmayacak ve kaybetmeyecek.
oyuncu elini �ekip bast���nda karakter z�playacak.
*/

public class FloorOperation : MonoBehaviour
{
    private Transform MainCharacter;
    void Start()
    {
        MainCharacter = GameObject.Find("Character").transform;

        foreach (var item in GetComponentsInChildren<SingleFloorModel>())
        {
            if (item.name == transform.name) continue;

            generateColor(item.gameObject);
        }
    }
    void generateColor(GameObject singleFloorGameObject)
    {
        Renderer rend = singleFloorGameObject.GetComponent<Renderer>();

        ColorFloor ColorE = (ColorFloor)Random.Range(0, 7);        
        singleFloorGameObject.GetComponent<SingleFloorModel>().colorFloorE = ColorE;
        
        rend.material.color = ColorOps.ConvertEnumToColor(ColorE);
    }

    
}
