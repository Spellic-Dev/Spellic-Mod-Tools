# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## `OnUpdate()`

This event is called every frame of the host game.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `delta` | `ValNumber` | Yes |

---

## `OnGameStart()`

This event is called when the game starts.
The game state is set to `GameState.GAMESTART` automatically.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| None | | |

---

## `OnRoundStart()`

This event is called when a round starts.
The game state is set to `GameState.ROUNDSTART` automatically.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| None | | |

---

## `OnRoundEnd()`

This event is called when a round ends.
The game state is set to `GameState.ROUNDEND` automatically.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| None | | |

---

## `OnGameEnd()`

This event is called when the game ends.
The game state is set to `GameState.GAMEEND` automatically.
Player Items are dropped automatically.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| None | | |

---

## `OnFlagCollected()`

This event is called when a capture the flag flag is collected.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `player` | `ValMap` | Yes |

---

## `OnPlayerDamage()`

This event is called when a player is damaged.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `victim` | `ValMap` | Yes |
| `attacker` | `ValMap` | No |
| `damage` | `ValNumber` | Yes |

---

## `OnPlayerDeath()`

This event is called when a player dies.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `victim` | `ValMap` | Yes |
| `killer` | `ValMap` | No |

---

## `OnMobDeath()`

This event is called when a mob dies.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `mob` | `ValMap` | Yes |
| `killer` | `ValMap` | No |

---

## `OnMobDamage()`

This event is called when a mob is damaged.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `victim` | `ValMap` | Yes |
| `attacker` | `ValMap` | No |
| `damage` | `ValNumber` | Yes |

---

## `OnPlayerLeave()`

This event is called when a player leaves the game.

### Arguments

| Name | Type | Always Set |
| --- | --- | --- |
| `player` | `ValMap` | Yes |
