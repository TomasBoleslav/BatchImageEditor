# BatchImageEditor

**BatchImageEditor** je jednoduchý editor pro větší množství obrázků najednou. Nahrajete své obrázky, zvolíte některé z nabídnutých úprav a necháte program obrázky zpracovat. Aby byl celý proces rychlejší, umožňuje aplikace spouštět výpočet paralelně.

Program je naprogramován v jazyce C# jako okenní aplikace WindowsForms.

## Obsah

- [Sestavení](#sestavení)
- [Návod k použití](#návod-k-použití)

## Sestavení

Sestavení programu můžete provést ve *Visual Studiu* nebo pomocí příkazové řádky:

````powershell
> dotnet build
````

Testy můžete spustit příkazem:

```powershell
> dotnet test
```

## Návod k použití

Program spustíte otevřením výsledného `*.exe` souboru po sestavení nebo pomocí příkazové řádky:

```powershell
> dotnet run
```

Otevře se okno editoru se scénou pro načítání obrázků.

![load-scene](./ReadmeResources/load-scene.png)

Na vrchní části okna se nacházejí tlačítka pro změnu scény. Kliknutím na některé z nich můžete kdykoliv přepnout mezi scénou pro načítání obrázků (**LOAD**), jejich úpravu (**EDIT**) a konečné zpracování (**PROCESS**).

### Načtení obrázků

Načítání souborů probíhá ve scéně **LOAD**. 

![load-scene-with-images](./ReadmeResources/load-scene-with-images.png)

Obrázky můžete načíst jednotlivě tlačítkem **Load images** nebo jako celou složku tlačítkem **Load folder**. Informace o souborech se pak objeví v seznamu nalevo. Pokud některý ze souborů v seznamu označíte, ukáže se náhled obrázku vpravo dole. Označené soubory můžete odebrat ze seznamu tlačítkem **Remove**.

Mezi **podporované formáty** patří JPEG, PNG, BMP a GIF.

### Úprava obrázků

K úpravě obrázků slouží scéna **EDIT**.

![edit-scene](./ReadmeResources/edit-scene.png)

V levé části okna můžete upravovat seznam filtrů. Pro přidání filtru použijte tlačítko **Add** a v zobrazeném menu vyberte požadovaný filtr. Označené položky můžete odebrat pomocí tlačítka **Remove** nebo upravit kliknutím na **Edit**. Pokud filtr nechcete odstranit, ale pouze vynechat, využijte zaškrtávacího tlačítka vedle názvu položky. Jednotlivými filtry můžete v seznamu posouvat nahoru a dolů, čímž změníte pořadí jejich vykonávání. Filtry se na obrázek aplikují vždy v pořadí shora dolů.

V pravé části okna je náhled obrázku, který můžete zvolit na vysouvací liště v horní části. Mezi původním a zpracovaným obrázkem přepínáte tlačítkem **Show original** / **Show preview**. Pro zobrazení náhledu jsou dvě volby **Fit** (natáhnutí obrázku na velikost plochy) a **Center** (zobrazení obrázku doprostřed plochy v originální velikosti).

Při výběru nového filtru pomocí **Add** nebo úpravy existujícího pomocí **Edit** se zobrazí okno pro nastavení filtru. Například pro filtr **Flip** vypadá nastavení následovně:

![flip-filter-settings](./ReadmeResources/flip-filter-settings.png)

V pravé části je náhled obrázku, v levé je nastavení filtru. Položky nastavení se pro každý filtr liší. Pro **Flip** je to typ převrácení, pro **Channels** je to změna jednotlivých barevných kanálů, atd.

Kliknutím na **Ok** se filtr s daným nastavením přidá do seznamu. Pomocí **Reset** se nastavení změní zpět na výchozí. Zavřením okna volbu zrušíte a změny nebudou uloženy.

### Zpracování

Ve scéně **Process** se nastavuje a provádí finální zpracování obrázků.

![process-scene](./ReadmeResources/process-scene.png)

Zvolte cestu k výstupní složce pomocí tlačítka **Select**, nebo ji napište přímo do vstupního pole. Nastavit můžete i maximální počet vláken, který se použije na výpočet. Ve výchozím nastavení je zaškrtnuté **Use Core Count**, což znamená, že se použije stejný počet vláken, jako je počet jader procesoru na daném počítači. Odškrtnutím se povolí zápis do pole **Thread Count**, kde můžete nastavit počet vláken manuálně. Maximum je však dvojnásobek celkového počtu jader. Pokud zvolíte pouze 1 vlákno, výpočet bude probíhat sekvenčně a reakce editoru se velmi zpomalí.

Kliknutím na **Process** se zahájí výpočet a otevře se nové okno s informacemi o výpočtu:

![image-processing-dialog](./ReadmeResources/image-processing-dialog.png)

Ve vrchní části okna můžete sledovat postup. Proces můžete kdykoliv přerušit tlačítkem **Cancel** nebo zavřením okna. Dole můžete vidět seznam chyb, které při výpočtu nastaly.

## Vývojová dokumentace

TODO úvod do programu - představení hlavních problémů a image processingu

součástí dokumentace je zdrojový kód a jeho komentáře

### Struktura programu

Program je dohromady složen z 5 projektů, z toho 1 jsou testy s použitím knihovny [xUnit](https://xunit.net/) a 1 je projekt benchmarků v [BenchmarkDotNet](https://benchmarkdotnet.org/).

Zbývající 3 projekty už přispívají ke kódu editoru:

- [ImageFilters](#projekt-imagefilters) - knihovna pro image processing.
- [BatchImageEditor](#projekt-batchimageeditor) - editor pro dávkovou úpravu obrázků využívající knihovnu *ImageFilters*.
- ThrowHelpers - knihovna obsahující pomocné třídy pro vyhazování výjimek. Není nijak zvlášť důležitá, proto dále není zmíněna.

### Projekt ImageFilters

Účelem knihovny ImageFilters je zpracování obrázků pomocí různých filtrů. Tyto operace mohou být velmi náročné a jedním z hlavních problémů bylo právě balancování rozšiřitelnosti a výkonu.

Tento projekt mimo jiné obsahuje třídy pro paralelní zpracování. Pro jediný obrázek to nejde jinak, než na něj aplikovat filtry sekvenčně. Pokud je ale obrázků více, může být posloupnost filtrů aplikována na každý ve stejnou chvíli.

#### Filtry

Pro kompatibilitu s *Windows Forms* byly použity třídy a struktury ze jmenného prostoru [`System.Drawing`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing?view=net-5.0). V něm slouží pro reprezentaci obrázku třída [`Bitmap`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0), ale přístup k jejím datům pomocí metod `GetPixel` a `SetPixel` je velmi pomalý. Pro náročné operace jsou k dispozici metody `LockBits` a `UnlockBits`, které nedovolí garbage collectoru přesouvat data obrázku a umožní tak přístup pomocí pointerů. Nakonec bylo použito řešení ze [stackoverflow](https://stackoverflow.com/a/34801225/13555057), které zavádí třídu `DirectBitmap` s přímým přístupem k datům v bufferu. Tento způsob je jednodušší a dokonce i rychlejší než zamykání, což bylo vyzkoušeno v projektu s benchmarky.

Důležitým rozhraním je `IImageFilter`, které předepisuje jedinou funkci `void Apply(ref DirectBitmap image)` V některých případech je nutné vytvořit obrázek nový a starý smazat, jindy stačí operaci vykonat přímo na vstupním obrázku. Aby bylo sémanticky jasné, že se při zavolání funkce obrázku vzdáváme, je předáván jako reference. Všechny filtry toto rozhraní implementují.

Některé filtry, např. `ResizingFilter`, používají návrhový vzor [Strategy](https://en.wikipedia.org/wiki/Strategy_pattern). Je definováno rozhraní reprezentující algoritmus, který se nějakým způsobem použije na filtrování obrázku. Pro změnu velikosti je to např. `IResizingAlgorithm`, který podle vstupního obrázku spočítá jeho výstupní velikost. Toto rozhraní implementují`FixedResizing` a `ResizingByFactor`, které počítají novou velikost jako fixní počet pixelů, respektive jako násobek staré velikosti.

Jiné filtry jsou rozšiřitelné pomocí dědičnosti. To platí například pro `LinearFilter`, jehož potomci mají společné to, že definují matici vah, která je jako okno "přiložena" na pixel a jeho výstupní hodnota bude spočítána jako součet pixelů vynásobených přiloženými vahami. Odvozené třídy tedy volají metodu `SetKernel`, čímž danou matici nastaví.

Filtry, u kterých se další rozšíření nepředpokládá (např. `FlipFilter`), ale u kterých je potřeba rozlišit způsob chování, mají na vstupu hodnotu typu `enum`. Pro převrácení obrázku je to například typ `FlipType` s hodnotami `Horizontal`, `Vertical` a `Both`.

#### Paralelní zpracování

Třídy pro zpracování obrázků byly vytvořeny s vědomím, že budou výsledky průběžně hlášeny uživateli, a tomu byly také přizpůsobeny.

Třída `ImageProcessingJob` představuje úlohu na zpracování obrázku, která zahrnuje i jeho načtení a uložení. Tento proces může být zrušen, čehož je dosaženo pomocí delegátů (`Func<bool> ShouldCancelFunc`), kterých se třída průběžně dotazuje. Místo toho, aby při chybách vznikaly výjimky, jsou spouštěny delegáty pro selhání s chybovou zprávou a také úspěch, pokud výpočet bez problémů doběhl až do konce.

Úlohy jsou paralelizovány pomocí třídy `BatchProcessor`, která volá metodu [`System.Threading.Tasks.Parallel.Foreach`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallel.foreach?view=net-5.0) na kolekci `ImageProcessingJob`.

#### Stará řešení a jiné poznámky

`DirectBitmap` byla dříve implementována také pomocí návrhového vzoru `Strategy` za účelem rozšíření pro různé formáty pixelu ([`System.Drawing.Imaging.PixelFormat`](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging.pixelformat?view=net-5.0)). `DirectBitmap` byla vytvořena z instance `Bitmap` a v jejím konstruktoru byl zvolen algoritmus (strategy), který z pozice v bufferu bytů dokázal najít a spočítat barvu pixelu. Tento postup se ukázal jako příliš těžkopádný a značně zpomaloval výpočty, především kvůli volání funkce z `interface`.

`ColorAdjustingFilter` používá `IColorAdjuster` pro výpočet nové barvy pixelu z pouhé znalosti jeho staré barvy. I tady se ukazuje vzor Strategy jako přehnaný, protože třída `ColorAdjustingFilter` není vůbec složitá a ušetření kódu tímto způsobem je zanedbatelné.

### Projekt BatchImageEditor

Delší čas jsem strávil rozhodováním, jaký návrh vybrat pro editor. Hlavním kandidátem byl návrhový vzor [MVP](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter), ale nepodařilo se mi vymyslet, jak jednotlivé komponenty propojit. Nakonec jsem se rozhodl komponenty rozdělit do samostatných [`UserControl`](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.usercontrol?view=net-5.0), kde vnější `UserControl` ovládá pomocí rozhraní další `UserControl`-s, která sama vlastní. Tímto způsobem je hlavní formulář rozdělen na scény, které jsou dále děleny na další samostatné části. Některé komponenty tak mohly být použity na více různých místech, jako například náhled obrázku.

Dalšími problémy bylo propojení knihovny `ImageFilters` a umožnění uživateli jednotlivé filtry nastavovat. Nastavení musí být uložena v polymorfním seznamu, kde jsou připravena pro vytvoření filtrů nebo další úpravu.

Všechna nastavení byla vytvořena jako `UserControl`-s se společným rozhraním definovaným v abstraktní třídě `FilterSettingsBase` a společnou implementací (částečnou) v odvozené generické třídě `FilterSettings<TModel>`. Každé nastavení obsahuje *model*, ve kterém jsou uložena všechna data nutná pro vytvoření filtru. Tyto modely mají společné rozhraní `IFilterSettingsModel<TModel>`, které jim předepisuje funkci `IEnumerable<IImageFilter> CreateFilters()`. Pokud je nastavení filtru potvrzeno, model se uloží a nastavení (`UserControl`) se začlení do seznamu, kde je připraveno na další použití.

Toto řešení má háček v tom, že kvůli abstraktním či generickým předkům (`FilterSettingsBase` a `FilterSettings<TModel>`) nelze nastavení zobrazit v designeru *Visual Studia*. Provizorním řešením je při práci s designerem předka dočasně nahradit za `UserControl`. 

Za zmínku stojí třída `UIUpdater`, která byla použita pro asynchronní výpočet náhledu obrázku. Pokud by se 







Při spouštění aplikace na různých počítačích vyvstaly problémy s rozlišením. Ty byly vyřešeny uzavřením komponent do `Panel`-ů, kterým byla nastavena vlastnost `Dock` na hodnotu jinou než `None`.

## Možná vylepšení

TODO

- hlavně MVP - testovatelnost
- Lepší návrh filtrů