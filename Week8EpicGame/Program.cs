
using System.ComponentModel.Design;

string folderPath = @"C:\DATA";  // kaust kust näeme oma andmeid. text fail
string heroFile = "heroes";
string villainFaile = "villains";


string[] heroes = File.ReadAllLines(Path.Combine(folderPath,heroFile));  // path.combine kleebib failid kokku, et saada faili aadressi
string[] villains = File.ReadAllLines(Path.Combine(folderPath,villainFaile));

//Andmete lugemine failist, nt. txt failist . 


//esiteks panna valmis kaks massiivi, kangelased ja kurjategijad

//string[] heroes = { "Harry Potter", "Like Skywalker", "Lara Croft", "Scooby-Doo" };  // kangelaste massiiv
//string[] villains = { "Voldemort", "Darth Vades", "Dracula", "Joker", "Sauron" };  // kurjategijate massiiv. juhusliku tegelase valimisel ei saa kasutada sama randomit,
//sest siin 5 tegelast ja kangelasi 4 . ja ühe sama koodi ei kasuta mitu korda, kasutame selleks funktsiooni 
string[] weapon = { "magic wand", "plastic fork", "banana", "wooden sword", "lego brick" };


//valida suvalist kangelast randomiga 




string hero = GetRandomValuFromArray(heroes);
string heroWeapon = GetRandomValuFromArray(weapon); 
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} save the day!");


string villain = GetRandomValuFromArray(villains);
string villainWeapon = GetRandomValuFromArray(weapon); 
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tryes to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);

}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Hero {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");

}
else if (villainHP > 0)
    {

    Console.WriteLine($"Dark side wins!");
  }
else
{
    Console.WriteLine("Draw!");
        
        
}

static string GetRandomValuFromArray(string[] someArray)  // funktsioon mis oskab massiivist juhusliku väärtuse valida ja salvestada see vahemälusse. massiivi elemendid peavad olema siin string formaadis
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;   
}

//heatpointi arvutamine, heatpoint hakkab sõltuma tegelase nime pikkusest
static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }


else
      {
        return characterName.Length;   

     }
}

//tegelaste löögid . // võtame tegelase nime static hit(string characterName, int characterHP) ja tema HP genereerime löögi tugevuse mis on vahemikus 0 kuni HP 
static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);  

    if ( strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target! ");
    }
    else if ( strike == characterHP-1) 
    { 
    Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");

    }
    return strike;
}


