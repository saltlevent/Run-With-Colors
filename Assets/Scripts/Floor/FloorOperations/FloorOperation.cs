using UnityEngine;
using ToolsLevent;
/*
Amaç oyunda verilen renklere göre karakterin o renge ait zemine basmasý.
renkler oyuncunun seçtiði item'lere göre deðiþiklik göstermektedir.
doðru renge bastýðý sürece puan kazanacak
yanlýþ renge basarsa puan kaybedecek
zýplarsa veya nötr bölgeye basarsa puan kazanmayacak ve kaybetmeyecek.
oyuncu elini çekip bastýðýnda karakter zýplayacak.
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
