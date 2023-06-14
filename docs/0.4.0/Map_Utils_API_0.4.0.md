# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## `SpellicDamageTrigger`

Deal damage to players when they enter the trigger. Used for death barriers.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `damage` | `int` | MaxValue | The amount of damage to deal. |
| `applyOnLeave` | `bool` | false | Whether to apply the damage when the player leaves the trigger. |

---

## `SpellicFloatingObject` - (**Client Side**)

These are used to create a floating like effect for your game object inside your scene. This should only be used for visible effects.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `bounceHeight` | `float` | 0.0001f | How high the object should bounce. |
| `bounceRate` | `float` | 3f | How often the object should float. |
| `bounceSync` | `float` | 0.5f | Honestly I don't know anymore. I got this script from Stackoverflow and forgor the link. |

---

## `SpellicRotatingObject`

A networked rotating object. This is used for rotating objects that are visible to all players.
This can be triggered with a `SpellicMapTrigger`.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `rotationSpeed` | `float` | 1f | The speed of the rotation. |
| `rotationVector` | `Vector3` | Vector3.up | The direction of the rotation. |
| `trigger` | `SpellicMapTrigger` | | The trigger that activates the rotation. |
| `activateOnStart` | `bool` | false | Whether the rotation should be activated on start. |

---

## `SpellicMapSpawnPoint`

A spawn point for players, mobs and other entities. You need these for your map to work.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `SpellicSpawnTeam` | `int` | 0 | The entity that should spawn at this point. |

---

## `SpellicNetworkSoundTrigger`

You can trigger sounds if something enters these triggers, and the sound will be synced to all players.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `hasBeenPlayed` | `bool` | false | Whether the sound has been played or not. |
| `playOnce` | `bool` | true | Whether the sound should only be played once. |
| `audioClip` | `AudioClip` | | The sound to play. |
| `source` | `AudioSource` | | The source to play the sound from. |

---

## `SpellicShaderFixer` - (**Client Side**)

The **MOST IMPORTANT** utility. Unity has a bug, where your map won't render correctly. With the shader fixer appended to any root object, all objects inside this root object will have their shaders "fixed". This object sets the shader you used to the shader found inside the games runtime. I cannot confirm if custom shaders work.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| None | | | |

## `SpellicMapTrigger`

A trigger that can be used to activate other objects.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `activeOnStart` | `bool` | true | Whether the trigger can be used from the start of the game. |
| `playerTrigger` | `bool` | false | Whether the trigger can be activated by players. |
| `spellTrigger` | `bool` | false | Whether the trigger can be activated by spells. |
| `triggerOnEnter` | `bool` | false | Whether the trigger should be activated when something enters it. |
| `triggerOnExit` | `bool` | false | Whether the trigger should be activated when something exits it. |
| `executeOnce` | `bool` | false | Whether the trigger should be executed only once. |

---

## `SpellicAnimationTrigger`

A trigger that can be used to activate animations.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `animationSteps` | `List<SpellicNetworkAnimation>` | | List of animations that will be played. |
| `playReverse` | `bool` | false | Set this to true if you want the animation to be played in reverse. |
| `loop` | `bool` | false | Set this to true if you want the animation to be looped. |
| `animateFromStart` | `bool` | false | Set this to true if you want the animation to be played from the start. |
| `trigger` | `SpellicMapTrigger` | | Reference Trigger that can enable section. |
| `executeOnce` | `bool` | false | Set this to true if the trigger should only execute once. |

---

## `SpellicPlatform`

A platform that can be used to move players and mobs.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `loop` | `bool` | false | The platform will move to the first waypoint after reaching the last one. |
| `waypoints` | `List<SpellicPlatformWaypoint>` | | A list of waypoints the platform will move to. |
| `activeOnStart` | `bool` | true | Set this to true if the platform should be active on start. |
| `trigger` | `SpellicMapTrigger` | | Reference Trigger that can enable this platform. |
| `triggerOnce` | `bool` | false | Set this to true if the trigger should only execute once. |
| `advanceOnTrigger` | `bool` | false | Set this to true if the trigger should advance the platform one step. |

---

## `SpellicNetworkConveyor`

A conveyor belt that can be used to move players, mobs and props.

### Parameters

| Name | Type | Default Value | Description |
| --- | --- | --- | --- |
| `direction` | `Vector3` | Vector3.forward | The direction of the conveyor. |
| `speed` | `float` | 1f | The speed of the conveyor. |
| `propForce` | `float` | 1f | The speed of the conveyor for props. |