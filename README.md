# SanbornYearTwos
This is a repository for the 2023-2024 class of Sanborn second years to share assets and scripts

# Code Style Guide

All scripts in this repo should follow this guide, if not they need to be updated.
This guide is adapted from the [official unity style guide](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)

## Class Names
Class names should be in **PascalCase**, and should be named after the object they represent. For example, a class that represents a player should be named `Player`.
Class names should be **descriptive** and use **nouns**, not verbs. For example, a class that manages the player's health should be named `PlayerHealthManager`, not `Health` or `Damager`.
### Class Implementation
If a class requires a compontent to be attached to the same object, it should have a `RequireComponent` attribute.
Here is an example of a Player class that requires a rigidbody component:
```csharp
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	// ...
}
```

## Variable Names
Variable names should be in **camelCase**. For example, a variable that represents the player's health should be named `playerHealth`.
Variable names should be **descriptive** and use **nouns**, not verbs. For example, a variable that represents the player's health should be named `playerHealth`, not `health` or `damage`.
Prefix Boolean variables with a **verb**. For example, a variable that represents whether the player is dead should be named `isDead` instead of `dead`.
## Different types of variables
| Syntax | Description |
| ----------- | ----------- |
| Header | Title |
| Paragraph | Text |