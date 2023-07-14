Ниже есть описание на русском

# What is this

This game is a copy of another hypercasual game named Helix Jump. It has simple mechanic of a ball falling down through platforms. Game has no sense. This whole project is about making an infrastructure of code to fully control all processes of the game.

## Infrastructure

### Entry point

Here I am going to show you steps what happen in code before game starts:

1. Game launches **Initial** scene

2. **GameRunner** object on scene creates **GameBootstrapper** and then destroys himself

> There are two scenes in this game: **Main** and **Initial**. **GameRunner** is located on both scenes. Its purpose is to create **GameBootstrapper** object if one doesnot exist.

3. **GameBootstrapper** keeps **Game** object inside which keeps **GameStateMachine** object inside. **GameBootstrapper** switches State Machine into **BootstrapState**

4. **BootstrapState** registers services, loads **Initial** scene and enters into **LoadProgressState**

5. **LoadProgressState** loads player progress and enters into **LoadLevelState**

6. **LoadLevelState** loads **Main** scene and calls **GameFactory** to make a level and make camera to observe the ball. Then it enters into **GameLoopState**

7. **GameLoopState** enables **InputService**

8. Game is ready to be played. Yay.

### Services

There is a custom service locator, written as a singleton. Services are passed into states constructors when states are initialized. Also, there are some objects which get services from **GameFactory** when objects are being spawned by the factory.

I've wrote four services:

- Input Service

> Transforms inputs into a convenient form

- Asset Provider

> Responsible for location of prefabs by address

- Persistent Progress Service

> Responsible for loading and saving player progress (Each level has one more platform)

- Game Factory

> Spawns objects and initializes them

## How to see if it works

You can test it out by installing it with an apk. [Here is a link to my google drive](https://drive.google.com/drive/folders/15_YAz65qGckdl-5bpF7n-3S03EIBnZ0o?usp=drive_link)

Though, playing it has no sense.  
Project is all about infrastructure, so, better read the code and leave me comments about my code condition.

...

...

...

# А теперь на русском. Что это?

Эта игра является копией другой гиперказуальной игры, которая называется "Helix Jump". Игра строится на механике того, как мячик падает вниз через платформы. Игра не имеет смысла. Весь этот проект про то, что я сделал архитектуру в коде, чтобы полностью контроллировать все процессы игры.

## Архитектура

### Точка входа

Я собираюсь объяснить шаги, которые происходят в коде, прежде чем в игру можно будет играть:

1. Игра запускается на сцене **Initial**

2. Объект **GameRunner** на сцене создает **GameBootstrapper** и уничтожает себя

> В игре две сцены: **Main** и **Initial**. **GameRunner** находится на обеих сценах. Его цель в том, чтобы создать объект **GameBootstrapper**, если его еще нет.

3. **GameBootstrapper** хранит объект **Game** внутри, который в свою очередь хранит объект **GameStateMachine** внутри. **GameBootstrapper** переключает машину состояний **GameStateMachine** в начальное состояние **BootstrapState**

4. **BootstrapState** регистрирует сервисы, загружает **Initial** сцену и переходит в состояние **LoadProgressState**

5. **LoadProgressState** загружает прогресс игрока и переходит в состояние **LoadLevelState**

6. **LoadLevelState** загружает **Main** сцену и вызывает **GameFactory**, чтобы сделать уровень и привязать камеру к мячу. Затем переход в состояние **GameLoopState**

7. **GameLoopState** активирует **InputService**

8. Игра готова к тому, чтобы в неё играли. Ура.

### Сервисы

Есть самодельный локатор сервисов, написанный как синглтон. Сервисы подаются в конструкторы состояний, когда состояния инициализируются. Также, есть некоторые объекты, которые получают сервисы от **GameFactory** на моменте создания.

Я написал четыре сервиса:

- Input Service (Сервис вводных данных)

> Переводит входные данные в удобную форму

- Asset Provider (Поставщик ассетов)

> Ответственен за местонахождение префабов

- Persistent Progress Service (Сервис постоянного прогресса)

> Ответственен за загрузку и сохранение прогресса игрока (На кажом уровне одна дополнительная платформа)

- Game Factory (Игровая фабрика)

> Создает объекты и инициализирует их

## Работает ли оно?

Вы можете проверить работоспособность, установив apk. [Ссылка на мой google drive](https://drive.google.com/drive/folders/15_YAz65qGckdl-5bpF7n-3S03EIBnZ0o?usp=drive_link)

Хотя, играть в это бессмысленно.  
Весь проект про архитектуру, так что, лучше смотрите код и оставьте комментарий о состоянии моего кода.