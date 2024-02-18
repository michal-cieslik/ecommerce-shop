# Projekt sklepu internetowego

Projekt realizowany przez: 
* Miko³aj Chwirot (128323),
* Micha³ Cieœlik (128331) 

## Opis ogólny

Projekt sklepu internetowego z okreœlonymi produktami. 
Zrealizowane przy pomocy **.NET 8** 

## Funkcjonalnoœci

### Role w systemie

 #### U¿ytkownik zalogowany
	* Dostêp do wszystkich produktów
	* Dodanie recenzji – opinia jest przypisana w UserID po hashu
 
#### U¿ytkownik niezalogowany
	* Mo¿liwoœæ przegl¹dania istniej¹cych produktów 
	* Mo¿liwoœæ rejestracji oraz zalogowania do istniej¹cego konta 
	* U¿ytkownik niezalogowany nie mo¿e dodaæ recenzji 

#### Modu³ rejestracji i logowania
Logowanie oraz rejestracja (z pe³n¹ walidacj¹ poprzez bibliotekê **Microsoft.AspNetCore.Identity.EntityFrameworkCore**) jest realizowane przy u¿yciu:
	* e-maila,
	* has³a

#### Budowa/logika bazy danych

![enter image description here](https://media.discordapp.net/attachments/929665697938817024/1208902200458481674/Diagram_bez_tytuu.drawio_10.png?ex=65e4f8e8&is=65d283e8&hm=d62a4018e25cdf445766e9972e65cbddc3840e1251c07def08de1beb9fa9c350&=&format=webp&quality=lossless&width=1440&height=667)
![enter image description here](https://media.discordapp.net/attachments/929665697938817024/1208904959849009182/DB_UML.png?ex=65e4fb7a&is=65d2867a&hm=bd4b9dd98594de622fe288febf04a2f4868d8142e7a9fc90f4ca80144b23f1c8&=&format=webp&quality=lossless&width=1242&height=671)

#### Uwagi
1. Po starcie strony nie ma u¿ytkowników, recenzji oraz produktów. 
	**Powód:** Zabrak³o czasu na implementacjê panelu.  
2. U¿ytkownika mo¿na dodaæ rejestruj¹c siê.
3.  Recenzjê mo¿na dodaæ tylko do istniej¹cego produktu. 
4. By móc odpaliæ aplikacjê, trzeba wystawiæ kontener Docker z obrazem PostgreSQL na porcie **5432:5432** na podstawie którego utworzymy przy starcie aplikacji bazê danych. Je¿eli pojawi siê jakiœ b³¹d zwi¹zany z baz¹ danych - proszê o rêczne utworzenie pustej bazy danych o nazwie **ecommerce_db** poprzez narzêdzie pgAdmin 4 (z takiego korzysta³em przy operacjach na DB). W za³¹czniku filmik z pokazu na istniej¹cym produkcie: [klik](https://streamable.com/jsu39w)