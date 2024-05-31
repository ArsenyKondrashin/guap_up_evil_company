# Evil Company
«Evil Company» — игра платформер, цель которой собирать металлолом, преодолевать препятствия и стараться улучшить результат на уровне.  
Игрок перемещается по поверхности планеты от начала до тех пор, пока не найдет аппаратус, а потом возвращается с ним на корабль.  
Попутно нужно собирать металлолом, чтобы получить дополнительные очки и повысить ранг прохождения.  
Игра имеет два варианта завершения. Первый из них достигается после смерти космонавта от ловушек и монстров. Второй после возвращения на корабль с аппаратусом и удачного завершения уровня.  

### Схема алгоритма решения:
1.	Инициализация главного меню:
		- Запуск сцены меню;
		- Ожидать нажатия на кнопку «PLAY».
2.	Инициализация уровня:
		- Запуск сцены уровня;
		- Отобразить информацию о здоровье в левом верхнем углу;
3.	Основной игровой цикл:
		- Пока игра не завершена:
			- Ждать действий игрока.
4.	Обработка нажатий на кнопки перемещения (A, D, SPACE):
		- При нажатии клавиш A, D:
			- Переместить игрока перемещать игрока по горизонтали;
- При нажатии клавиши SPACE:
			- Прыгнуть;
5.	Проверка смерти персонажа:
- Если hp персонажа на нуле:
		- Вывести экран «Вы погибли»;
		- Через 8 секунд перенести в главное меню.

6.	Проверка завершения уровня
	- Если аппаратус собран и персонаж вернулся к кораблю:
		- Вывести экран завершения уровня
		- Через 8 секунд перенести в главное меню.

