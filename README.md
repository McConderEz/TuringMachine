# Программа-эмулятор Машины Тьюринга
Этот проект представляет собой программную реализацию одноленточной и многоленточной машины Тьюринга, которая проверяет соответствует ли заданное пользователем слово условию.

## Цель работы
Цель – сформировать формальное определение алгоритма в виде
трех аналитических моделей, написать программную реализацию машины
Тьюринга, распознающей язык L = { wcv│w, v ∈ {0, 1}* & │w│=2k & │v│=2n+1
& k!=n & k, n≥0}, построить график временной сложности.
Результат – формальное определение алгоритмов на основе
рекурсивных функций, машин Тьюринга и нормальных алгоритмов Маркова,
программная реализация машины Тьюринга, распознающей язык L = {
wcv│w, v∈{0, 1}* & │w│=2k & │v│=2n+1 & k!=n & k, n≥0}, график временной
сложности машины Тьюринга, файловый вариант протокола работы машины
Тьюринга.

## Система команд алгоритма для ОМТ
![](https://private-user-images.githubusercontent.com/59931307/309400280-4b02cb1d-5c6a-483e-933a-385797366635.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDkzMzAzNjgsIm5iZiI6MTcwOTMzMDA2OCwicGF0aCI6Ii81OTkzMTMwNy8zMDk0MDAyODAtNGIwMmNiMWQtNWM2YS00ODNlLTkzM2EtMzg1Nzk3MzY2NjM1LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzAxVDIxNTQyOFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTE5MmUzMWJlY2Y1YzIyODRmODJhNGE2YTY0OGQ3MjQ3OTUxOWY3NzlhNDgxZTEzNWU0MDI5NjgyODE5M2EwYTYmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.bwUMkfLGTItmO81qjBEMyBljL8zTnDtIVVXfGsC740I)

## Словесное описание алгоритма для ОМТ
На ленту подаётся слово сначала мы проверяем условие (k!=n) для этого
мы по очереди передвигаем каретку из слова w,заменяя его на пометку, к слову
v,также заменяя его. Если слова w полностью заменено, а слово v имеет
символ 1/0 то мы двигаем каретку вправо, и если там пустой символ, значит
условие ложно, мы стираем запись и ставим 0, иначе делаем обратную замену
и переходим к условию (|w| = 2k && |v| = 2n+1). Здесь мы заменяем символы
и стираем их попарно, если следующий символ “c” (для w) или пустой
символ(для v), то ставим 0 слева или справа, что означает нечетность, иначе 1,
если справа или слева “c” пустой символ. Верное условие будет, когда
предфинальный вид слова обретает вид “1c0”, это будет означать, что слова w
и v соответствуют условиям четности/нечестности. Далее на основании этих
результатов, “c” будет равно либо 1,либо 0.

## Cистема команд алгоритма для ММТ 
![](https://private-user-images.githubusercontent.com/59931307/309400803-35efe0b0-9a81-453b-a286-6c44c95a4ed0.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDkzMzA0NzksIm5iZiI6MTcwOTMzMDE3OSwicGF0aCI6Ii81OTkzMTMwNy8zMDk0MDA4MDMtMzVlZmUwYjAtOWE4MS00NTNiLWEyODYtNmM0NGM5NWE0ZWQwLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzAxVDIxNTYxOVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWQ4ZjE1ZjU2NDYwZTlkNzlkYWI1NGU3OWRhOGJmMzA5YjYxMDkzZDcxMDU4YWI1NWFmMWZkODUwMGE3NWRmZmEmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.pk0w_uxYQ0Pr7E66ZX3A5PJNslyQH0mfXBUI-lK1nfE)

## Словесное описание алгоритма для ММТ
На вход подаётся слово, проверяем наличие символов 1/0/c, если их нет,
то ставим 0, если символов c больше 1, то 0, иначе записываем на вторую ленту
пошагово символы с первой до встречи символа “c”, после мы его стираем.
Следующий шаг, проверяем условие (k!=n) одновременно сдвигаем каретки,
если достигаем конца слова второй ленты, но не достигаем конца слова первой
лент, то проверяем, стоит ли за ним символ, если да, то переходим к проверке
слов на четность/нечетность, иначе стираем слова с обеих лент и ставим в
первой ленте 0. Проверка на четность/нечетность аналогична одноленточной
машине. После проверки, смотрим, если первая лента в результате выдаёт 0, а
вторая 1, то стираем вторую, а в первой ставим 1, иначе стираем вторую и в
первой ставим 1.
Алгоритмы похожи, однако за счёт дополнительной памяти (второй
ленты) двуленточная машина Тьюринга работает быстрее и требует меньше
тактов для вычислений.


## Особенности
- Проект написан с применением Windows Forms
- При написании проекта было применено асинхронное программирование, позволяющее вести одновременное вычисление слова для ОМТ и ММТ
- Построения графика временной сложности 
- Логгирование команд вычисления в файл

## Наглядная работа программы
![](https://private-user-images.githubusercontent.com/59931307/309401543-45ec6d95-44db-422d-8b5a-f32544ceaa7d.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDkzMzA4MzUsIm5iZiI6MTcwOTMzMDUzNSwicGF0aCI6Ii81OTkzMTMwNy8zMDk0MDE1NDMtNDVlYzZkOTUtNDRkYi00MjJkLThiNWEtZjMyNTQ0Y2VhYTdkLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzAxVDIyMDIxNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWMyMTcyMjM5ZGJiODY2NDEwMzE2Nzg3MzYwM2Y3YjBkODI0OGU3NzkzZmE4ZGRkMTRiODQ5MWY3M2VlNjYzNDkmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0._kMaLst90LPaiTw09YaLdIwh9IyDTIP9zvbC0L4Z0Ws)
![](https://private-user-images.githubusercontent.com/59931307/309401607-c22f8864-9cfc-4dd2-8579-2d410131f8f1.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDkzMzA4MzUsIm5iZiI6MTcwOTMzMDUzNSwicGF0aCI6Ii81OTkzMTMwNy8zMDk0MDE2MDctYzIyZjg4NjQtOWNmYy00ZGQyLTg1NzktMmQ0MTAxMzFmOGYxLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzAxVDIyMDIxNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTQwNzQzNzc0ZTUzMDUzZTVmZmExNzVhZTM2Y2FhZGVlYTkwMmEzODdmYTVkYmVlOTJmNTc2YmRiYTk3MDMwYTYmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.SMzs0-DY9R5v1MLnL5rjsMJD2g44Qe-8wavzEFVvgVQ)
![](https://private-user-images.githubusercontent.com/59931307/309401655-7fb235e7-abaf-4b1b-85e4-3dfe753320bc.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDkzMzA4MzUsIm5iZiI6MTcwOTMzMDUzNSwicGF0aCI6Ii81OTkzMTMwNy8zMDk0MDE2NTUtN2ZiMjM1ZTctYWJhZi00YjFiLTg1ZTQtM2RmZTc1MzMyMGJjLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAzMDElMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMzAxVDIyMDIxNVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTllMDJkMTI2MTQ1NGE4ZTFhMGUxZjg4MTg0MWJiNWQ2MTc2YWYzMDc1NmYwYzM5NzFjMzNkYTEwZjJlMzEzYmQmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.Nm6m-DDCh02SUUWj4eNVYEzCNnHGJbJbsaNeBb1xx9I)
## Как запустить
### Для запуска приложения выполните следующие шаги:

1. Клонируйте репозиторий.
2. Откройте файл решения в Visual Studio.
3. Постройте решение.
4. Запустите приложение.
