﻿/*
1) "космический корабль" (можно использовать ассет, можно стандартные фигуры юнити)
1.1) Перемещение корабля в 3д пространстве осуществляется кнопками WASD, поворот стрелками или ПКМ.
1.2) Камера привязана к кораблю, прокрутка мышки отдаляет или приближает камеру.
1.2) использовать skybox
1.3) у корабля есть форс пламени, увеличивающийся в зависимости от движения <particles system>
1.4) в сцене существуют объект "метеорит" (стоящие на месте, либо медленно движущиеся), при столкновении с котором корабль отталкивает
1.5) в сцене существует объект "портал", при соприкосновении с котором корабль перемещается в другую подобную сцену <переключение сцен>
1.6) корабль стреляет ракетами, уничтожающими метеориты

2) 2д интерфейс (не должен ломаться и съезжать при разнвх разрешениях).
2.1) Главное меню (вызывается кнопкой Esc или через кнопку интерфейса):
Кнопки:
"Рестарт". <сбрасывает все объекты, координаты и состояния>
"Выход" из приложения.
2.2) Окно настройки качества (вызывается через интерфейс).
Выпадающее меню - "низкое, среднее, высокое".
2.3) Лог с прокруткой. Лог вызывается и скрывается с экрана отдельной кнопкой.
В лог пишутся события:
"корабль столкнулся с метеоритом"
"ракета уничтожила метеорит"
"корабль переместился через портал"
2.4) счетчик уничтоженных метеоритов
*/