# Kliensoldali fejlesztés féléves feladat specifikáció


## 1. Leírás

A webalkalmazás egy hallgatói fórum, amely az előző féléves ASP beadandónak a továbbfejlesztésére épít. Az akkori beadandóban a következő komponensek voltak, amelyeket kétféle felhasználó tudott használni, a következő jogosultságokkal:
  - tantárgyak:
    - admin létrehozhat, törölhet, módosíthat
    - felhasználó megtekintheti
  - posztok:
    - tantárgyakhoz tartoznak, egy poszthoz egy tantárgy tartozik, egy tantárgyhoz több poszt tartozhat
    - admin létrehozhat, törölhet, módosíthat (bárkiét)
    - felhasználó létrehozhat, sajátját törölheti
  - kommentek:
    - posztokhoz tartoznak, egy kommenthez egy poszt tartozik, egy poszthoz több komment tartozhat
    - admin létrehozhat, törölhet, módosíthat (bárkiét)
    - felhasználó létrehozhat, sajátját törölheti
    
Ebben a beadandóban ez az alkalmazás a következő módon lesz bővítve:
  - a kommenteket lehet lájkolni, és meg fog jelenni, hogy egy adott komment hány lájkot kapott
  - eddig bejelentkezés nélkül semmi sem jelent meg, most bejelentkezés nélkül is megtekinthető a tantárgyak listája, és azokon belül a posztok listája (azonban a posztok nem kattinthatók, tehát a kommentek nem jeleníthetők meg)
  - bejelentkezés nélkül semmilyen létrehozási, módosítási vagy törlési jogosultság nincs
  
## 2. Végpont lista
 - subjects - visszaadja a tantárgyakat (ID, név, kreditérték)
 - posts of a subject - visszaadja adott tárgy posztjait (ID, szöveg, adott poszt szerzője, adott poszt tantárgy ID-ja)
 - comments of a post - visszaadja adott poszt kommentjeit (ID, szöveg, adott komment szerzője, adott kommenthez tartozó poszt ID-ja, adott kommenthez tartozó like mennyisége)
 
## 3. Funkciólista - kibővítés
  - a legtöbb funkció a leírásban található
  - a like kezelésre a komment osztály kap egy likedby tulajdonságot, amely egy olyan lista, amelyben különböző siteuserek ID-i találhatók meg. A komment megtekintése esetén a webalkalmazás ellenőrzi, hogy a bejelentkezett felhasználó ID-ja (e-mail cím string?) megtalálható-e az adott komment like-listájában, ha nem, akkor a gomb aktív és megnyomható, ha igen, akkor disabled lesz. A gomb megnyomásakor (tehát a like beküldésekor) a program ismételten ellenőrzi, hogy az adott user id-ja megtalálható-e a kommentet lájkolók között, és csak akkor növeli meg a likecount tulajdonság értékét 1-el, ha ő még nem like-olta
  - a like visszavonására nincs lehetőség
  
## 4. Technológiák, keretrendszerek
  - Angular keretrendszer, CSS megjelenítést Angular Material fogja segíteni
  
## 5. Látványterv
<img width="385" alt="image" src="https://user-images.githubusercontent.com/92106195/235349996-53eec5fa-681d-4e3c-956f-d3db7a7724ef.png">
