using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
