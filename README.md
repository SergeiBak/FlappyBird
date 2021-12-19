# Flappy Bird
<img width="276.48" height="155.52" src="https://github.com/SergeiBak/PersonalWebsite/blob/master/images/flappybird.png?raw=true">

## Table of Contents
* [Overview](#Overview)
* [Test The Project!](#test-the-project)
* [Code](#Code)
* [Technologies](#Technologies)
* [Resources](#Resources)
* [Donations](#Donations)

## Overview
This project is a recreation of the sidescrolling hit know as Flappy Bird! This solo project was developed in Unity using C# as 
part of my minigames series where I utilize various resources to remake simple games in order to further my learning as well as to have fun!   

Flappy Bird consists of a simple scrolling level in which the player can tap to make the bird jump up from its fall. The goal of the game is to get the highest score possible by avoiding hitting the ground & pipes. For each pipe passed, the player gets a point added to their score!

## Test The Project!
In order to play this version of Flappy Bird, follow the [link](https://sergeibak.github.io/PersonalWebsite/FlappyBird.html) to a in-browser WebGL build (No download required!).

## Code
A brief description of all of the classes is as follows:
- The `GameController` class is a singleton class that handles many of the interactions such as the player state, game state, and the playing of audio.
- The `Parallax` class creates the effect of the Quad it is attached to having the appearance as if its texture is constantly moving.
- The `Pipes` class handles the movement of the pipes left, as well as their destruction when they are offscreen.
- The `Player` class handles player input & movement, as well as checking for collisions.
- The `Spawner` class handles the spawning of pipes.

## Technologies
- Unity
- Visual Studio
- GitHub
- GitHub Desktop

## Resources
- Credit goes to [Zigurous](https://www.youtube.com/channel/UCyaKsKqYTghxgAqywfefAzg) for the helpful base game tutorial!
- For the saving stats system, I made use of playprefs, here is some [helpful scripting documentation](https://docs.unity3d.com/ScriptReference/PlayerPrefs.html) on how that works!
- I derived my formula for calculating which medal to award based on this [reference](https://flappybird.fandom.com/wiki/Flappy_Bird).

## Donations
This game, like many of the others I have worked on, is completely free and made for fun and learning! If you would like to support what I do, you can donate at my metamask wallet address: ```0x32d04487a141277Bb100F4b6AdAfbFED38810F40```. Thank you very much!
