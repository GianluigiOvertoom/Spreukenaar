# Spreukenaar
A multiplayer team-based platform fighter with wizards.<br />

## Installations
Unity version: 6000.0.23f1.<br />

## Coding conventions

### Casing terminology

You can’t define variables with spaces in the name because C# uses the space character to separate identifiers. Casing schemes can alleviate the issue of having to use compound names or phrases in source code.<br />

Listed below are several well-known naming and casing conventions:<br />

__Camel case__<br />

Also known as camel caps, camel case is the practice of writing phrases without spaces or punctuation, separating words with a single capitalized letter. The very first letter is in lowercase.<br />

Typically, local variables and method parameters appear in camel case. For example:<br />
``` csharp
examplePlayerController
maxHealthPoints
endOfFile
```
__Pascal case__<br />

Pascal case is a variation of camel case, where the initial letter is capitalized. Use this for class and method names in Unity development. Public fields can be pascal case as well. For example:<br />
``` csharp
ExamplePlayerController
MaxHealthPoints
EndOfFile
```
__Snake case__<br />

In this case, spaces between words are replaced with an underscore character. For example:<br />
``` csharp
example_player_controller
max_health_points
end_of_file
```
__Kebab case__<br />

Here, spaces between words are replaced with dashes. The words then appear on a sort of “skewer” of dash characters. For example:<br />
``` csharp
example-player-controller
Max-health-points
end-of-file
```
The problem with kebab case is that many programming languages use the dash as a minus sign. Additionally, some languages interpret numbers separated by dashes as calendar dates.<br />

__Hungarian notation__<br />

The variable or function name often indicates its intention or type. For example:<br />
``` csharp
int iCounter
string strPlayerName
```
<br />

### Fields and variables

Consider these rules for your variables and fields:

* Use nouns for variable names: Variable names should be clear and descriptive because they represent a specific thing or state. Use a noun when naming them except when the variable is of the type bool (see below).<br />
* Prefix Booleans with a verb: These variables indicate a true or false value. Often they are the answer to a question, such as: Is the player running? Is the game over?<br />
  - Prefix them with a verb to make their meaning more apparent. Often this is paired with a description or condition, e.g., isDead, isWalking, hasDamageMultiplier, etc.<br />
* Use meaningful names. Don’t abbreviate (unless it’s math): Your variable names will reveal their intent. Choose names that are easy to pronounce and search for.<br />
  - While single-letter variables are fine for loops and math expressions, don’t abbreviate in other situations. Clarity is more important than any time saved from omitting a few vowels.<br />
  - For quick prototyping, you can use short “junk” names temporarily, and then refactor to more meaningful names later on.<br />
* Use pascal case for public fields, and use camel case for private variables: For an alternative to public fields, use properties with a public “getter” (see previous and following sections).<br />
* Avoid too many prefixes or special encoding: You can prefix private member variables with an underscore (_) to differentiate them from local variables.<br />
  - Alternatively, use the this keyword to distinguish between member and local variables in context and skip the prefix. Public fields and properties generally don’t have prefixes.<br />
  - Some style guides use prefixes for private member variables (m_), constants (k_), or static variables (s_), so the name can reveal more about the variable at a glance.<br />
  - Many developers eschew these and rely on the Editor instead. However, not all IDEs support highlighting and color coding, and some tools can’t show rich context at all. Consider this when deciding how (or if) you will apply prefixes together as a team.<br />
* Specify (or omit) access level modifiers consistently: If you leave off the access modifier, the compiler will assume the access level should be private. This works well, but be consistent in how you omit the default access modifier.<br />
  - Remember that you’ll need to use protected if you want this in a subclass later.<br />
<br />

### Classes and interfaces

Follow these standard rules when naming your classes and interfaces:<br />
**Use pascal case nouns for class names:** This will keep your classes organized.<br />
**If you have a MonoBehaviour in a file, the source file name must match:** You might have other internal classes in the file, but only one MonoBehaviour should exist per file.<br />
**Prefix interface names with a capital “I”:** Follow this with an adjective that describes the functionality.<br />
<br />

### Methods

In C#, every executed instruction is performed in the context of a method.<br />
Methods perform actions, so apply these rules to name them accordingly:<br />
**Start the name with a verb:** Add context if necessary (e.g., **GetDirection, FindTarget**, etc.)<br />
**Use camel case for parameters:** Format parameters passed into the method like local variables.<br />
**Methods returning bool should ask questions:** Much like Boolean variables themselves, prefix methods with a verb if they return a true-false condition. This phrases them in the form of a question (e.g., **IsGameOver, HasStartedTurn**).<br />
**Note:** The terms “function” and “method” are often used interchangeably in Unity development. However, because you can’t write a function without incorporating it into a class in C#, “method” is the correct term.<br />
<br />

### Events and event handlers

Events in C# implement the observer pattern. This software design pattern defines a relationship in which one object, the subject (or publisher), can notify a list of dependent objects called observers (or subscribers). Thus, the subject can broadcast state changes to its observers without tightly coupling the objects involved.<br />
Several naming schemes exist for events and their related methods in the subject and observers. Try the practices in the following sections.<br />
<br />

### Use verbs

Name the event with a verb phrase. Be sure to choose one that communicates the state change accurately.<br />
Use the present or past participle to indicate the state of events as before or after. For example, specify “OpeningDoor” for an event before opening a door and “DoorOpened” for an event afterward.<br />
<br />

### Use System.Action

Use the System.Action delegate for events. In most cases, the Action<T> delegate can handle the events needed for gameplay.<br />
You can pass up to 16 input parameters of different types with a return type of void. Using the predefined delegate saves code.<br />
**Note:** You can also use the EventHandler or EventHandler<TEventArgs> delegates. Agree as a team on how everyone should implement events.<br />
<br />

### Prefix method with "On"

Prefix the event raising method (in the subject) with “On.” The subject that invokes the event typically does so from a method prefixed with “On” (e.g., “OnOpeningDoor” or “OnDoorOpened”).<br />
<br />

### Prefix with subject's name and underscore

Prefix the event handling method (in the observer) with the subject’s name and an underscore (_). If the subject is named “GameEvents,” your observers can have a method called “GameEvents_OpeningDoor” or “GameEvents_DoorOpened.”<br />
Decide on a consistent naming scheme for your team and implement those rules in your style guide.<br />
**Note:** This “event handling method” is not to be confused with the EventHandler delegate.<br />
<br />

### Use EventArgs carefully

Create custom EventArgs only if necessary. If you need to pass custom data to your Event, create a new type of EventArgs, either inherited from **System.EventArgs** or from a custom struct.<br />
<br />

### Namespaces

Use namespaces to ensure that your classes, interfaces, enums, etc. don’t conflict with those already existing from other namespaces, or the Global Namespace. Namespaces can also prevent conflicts with third-party assets from the Unity Asset Store or other test scenes that won’t be part of the final version of the project.<br />

When applying namespaces:<br />

Use pascal case without special symbols or underscores.<br />
Add a using directive at the top of the file to avoid repeated typing of the namespace prefix.<br />
Create sub-namespaces as well. Use the dot(.) operator to delimit the name levels, allowing you to organize your scripts into hierarchical categories. For example, you can create “MyApplication.GameFlow,” “MyApplication.AI,” “MyApplication.UI,” and so on, to hold different logical components of your game.<br />
<br />

### Prefixes

In code, these classes are referred to as **Enemy.Controller1** and **Enemy.Controller2**, respectively. Add a using line to save typing out the prefix (e.g., **using Enemy;**).<br />
When the compiler finds the class names **Controller1** and **Controller2**, it understands you mean **Enemy.Controller1** and **Enemy.Controller2**.<br />
If the script needs to refer to classes with the same name from different namespaces, use the prefix to differentiate them. For instance, if you have a Controller1 and Controller2 class in the Player namespace, you can write out **Player.Controller1** and **Player.Controller2** to avoid any conflicts. Otherwise, the compiler will report an error.<br />
<br />

Sources: <br />
Rules: https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity<br />
Styling: https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax<br />
