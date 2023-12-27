Магический магазин

Проект представляет из себя витиру игрового магазина со списком бандлов для покупки.
Стоимость и награда бандлов настраиваются через ассет BundlesSettings (Assets/Data/BundlesSettings) и состоят из предоставленных логических "кирпичиков".
Код разделен на отдельные домены (папки-ассембли (с вложенными .asmdef)). Есть следующие домены: Health, Gold, Location и Shop. Все они имеют зависимости от Core. Shop знает о всех доменах и отображает информацию о бандлах в окне магазина. 

Настройка бандлов может состоять из:
- фиксированное кол-во золота;
- фиксированное кол-во здоровья;
- процентное кол-во здоровья от текущего;
- изменение текущей локации на заданную;
- и т.д.
  
На верхней панели отображается Здоровье, Золото и Локация (слева направо) игрока. Также присутствуют чит-кнопки для увеличения или уменьшения значений.
Как результат, весь UI реагирует на покупки, траты, обмен жизней на золото и наоборот. Некоторые путешествия уменьшают здоровье или стоят золота.
Каждый бандл можно перенастроить или добавить новые из представленных логических частей.