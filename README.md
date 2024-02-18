# Projekt sklepu internetowego

Projekt realizowany przez: 
* Miko�aj Chwirot (128323),
* Micha� Cie�lik (128331) 

## Opis og�lny

Projekt sklepu internetowego z okre�lonymi produktami. 
Zrealizowane przy pomocy **.NET 8** 

## Funkcjonalno�ci

### Role w systemie

 #### U�ytkownik zalogowany
	* Dost�p do wszystkich produkt�w
	* Dodanie recenzji � opinia jest przypisana w UserID po hashu
 
#### U�ytkownik niezalogowany
	* Mo�liwo�� przegl�dania istniej�cych produkt�w 
	* Mo�liwo�� rejestracji oraz zalogowania do istniej�cego konta 
	* U�ytkownik niezalogowany nie mo�e doda� recenzji 

#### Modu� rejestracji i logowania
Logowanie oraz rejestracja (z pe�n� walidacj� poprzez bibliotek� **Microsoft.AspNetCore.Identity.EntityFrameworkCore**) jest realizowane przy u�yciu:
	* e-maila,
	* has�a

#### Budowa/logika bazy danych

![enter image description here](https://media.discordapp.net/attachments/929665697938817024/1208902200458481674/Diagram_bez_tytuu.drawio_10.png?ex=65e4f8e8&is=65d283e8&hm=d62a4018e25cdf445766e9972e65cbddc3840e1251c07def08de1beb9fa9c350&=&format=webp&quality=lossless&width=1440&height=667)
![enter image description here](https://media.discordapp.net/attachments/929665697938817024/1208904959849009182/DB_UML.png?ex=65e4fb7a&is=65d2867a&hm=bd4b9dd98594de622fe288febf04a2f4868d8142e7a9fc90f4ca80144b23f1c8&=&format=webp&quality=lossless&width=1242&height=671)

#### Uwagi
1. Po starcie strony nie ma u�ytkownik�w, recenzji oraz produkt�w. 
	**Pow�d:** Zabrak�o czasu na implementacj� panelu.  
2. U�ytkownika mo�na doda� rejestruj�c si�.
3.  Recenzj� mo�na doda� tylko do istniej�cego produktu. 
4. By m�c odpali� aplikacj�, trzeba wystawi� kontener Docker z obrazem PostgreSQL na porcie **5432:5432** na podstawie kt�rego utworzymy przy starcie aplikacji baz� danych. Je�eli pojawi si� jaki� b��d zwi�zany z baz� danych - prosz� o r�czne utworzenie pustej bazy danych o nazwie **ecommerce_db** poprzez narz�dzie pgAdmin 4 (z takiego korzysta�em przy operacjach na DB). W za��czniku filmik z pokazu na istniej�cym produkcie: [klik](https://streamable.com/jsu39w)