# SanbornYearTwos
This is a repository for the 2023-2024 class of Sanborn second years to share assets and scripts

# Code Style Guide

All scripts in this repo should follow this guide, if not they need to be updated.
This guide is adapted from the [official unity style guide](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)

## Namespace
Namespaces should be in **PascalCase**. 
Create sub-namespaces as well. Use the dot(.) operator for different levels, to organize scripts into hierarchical categories. For example, you can create “MyApplication.GameFlow,” “MyApplication.AI,” “MyApplication.UI” to hold different logical components of your game.
```csharp
namespace Enemy 
{
    public class Controller1 : MonoBehaviour 
    {
        ...
    }
    
    public class Controller2 : MonoBehaviour 
    {
        ...
    }
}
```

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

Variables only used in one class should be private, to change these in the editor use the [SerializeField](https://docs.unity3d.com/ScriptReference/SerializeField.html) attribute.
Variables that can be changed in the editor should have a tooltip to explain what they do, use the [Tooltip](https://docs.unity3d.com/ScriptReference/TooltipAttribute.html) attribute.

Variables should be written in a way that represents their privacy level.
| Type | Example |
| ----------- | ----------- |
| Private Member | Underscore (_) prefix |
| Public | PascalCase |
| Local | camelCase |

```csharp
// EXAMPLE: Public and private variables

public bool IsInvincible;

 [Tooltip("The value that damage is multiplied by if the damage is special.")]
 [SerializeField] float DamageMultiplier = 1.5f;
 
 [Tooltip("The maximum health of the player.")]
 [SerializeField] float MaxHealth = 100f;

private bool _isDead;
private float _currentHealth;

// parameters
public void InflictDamage(float damage, bool isSpecialDamage)
{
    // local variable
    int totalDamage = damage;

    // local variable versus public member variable
    if (isSpecialDamage)
    {
    	totalDamage *= DamageMultiplier;
    }

    // local variable versus private member variable
    if (totalDamage > _currentHealth)
    {
        /// ...
    }
}
```

## Methods
Every major executed action should be in the form of a method.
Method names should be in **PascalCase**. For example, a method that sets the player's health should be named `SetHealth`.
Method names should be **descriptive** and start with a **verb**. For example, a method that sets the player's health should be named `SetHealth`, not `Health` or `HealthChanger`.
Methods returning a bool should answer a question. For example, a method that checks if the game is over should be named `IsGameOver`, not `CheckGame` or `GameState`.

```csharp
// EXAMPLE: Methods start with a verb.
public void SetInitialPosition(float x, float y, float z)
{
    transform.position = new Vector3(x, y, z);
}

// EXAMPLE: Methods ask a question when they return bool.
public bool IsNewPosition(Vector3 currentPosition)
{
    return (transform.position == newPosition);
}
```

For methods that occur after an event should be named `OnEventName`. For example, a method that occurs after the player dies should be named `OnPlayerDeath`.

```csharp
// EXAMPLE: Methods that occur after an event should be named OnEventName.
public void OnPlayerDeath()
{
	// ...
}
```