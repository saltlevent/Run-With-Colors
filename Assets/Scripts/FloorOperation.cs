using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public enum ColorFloor {None, Red, Green, Blue, Yellow, Black, White};

    public ColorFloor colorFloor = ColorFloor.None;
    void Start()
    {
        colorFloor = (ColorFloor)Random.Range(0,7);
    }

    void Update()
    {
        
    }
}
