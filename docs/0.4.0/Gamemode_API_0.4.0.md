# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## `GetGameSettings()`

This function retrieves the current game settings.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

### Output

- `gameSettings`: `ValMap` - A map containing the following game settings:
  - `teamBased`: `ValNumber` - Whether the game is team-based (1) or not (0).
  - `rounds`: `ValNumber` - The number of rounds in the game.
  - `roundTime`: `ValNumber` - The duration of each round in seconds.
  - `difficulty`: `ValNumber` - The difficulty multiplier of the game.
  - `mobs`: `ValNumber` - Whether mobs are enabled (1) or not (0).
  - `abbreviations`: `ValNumber` - Whether abbreviations are enabled (1) or not (0).

---

## `GetGameState()`

This function retrieves the current game state.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

### Output

- `gameState`: `ValNumber` - The current game state.

---

## `ChangeGameState(gameState: ValNumber)`

This function changes the current game state.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `gameState` | `ValNumber` | | Yes |

---

## `DisableMovement()`

This function disables movement for all players and mobs.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `EnableMovement()`

This function enables movement for all players and mobs.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `RespawnPlayers(reset: ValNumber, canMove: ValNumber)`

This function respawns all players.
If reset is `true`, the players will respawn even if they are alive.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `reset` | `ValNumber` | 0 | No |
| `canMove` | `ValNumber` | 0 | No |

---

## `RespawnPlayer(playerId: ValString, canMove: ValNumber)`

This function respawns a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |
| `canMove` | `ValNumber` | 0 | No |

---

## `GetAliveTeamSize(team: ValString)`

This function retrieves the number of alive players in a specific team.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `team` | `ValString` | | Yes |

### Output

- `aliveTeamSize`: `ValNumber` - The number of alive players in the specified team.

---

## `SpawnMobs()`

This function spawns mobs.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `KillMobs()`

This function kills all mobs.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `GetMobCount()`

This function retrieves the number of mobs.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

### Output

- `mobCount`: `ValNumber` - The number of mobs.

---

## `SpawnFlags()`

This function spawns capture the flag flags.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `ShowBestPlayers()`

This function shows the best players after the game ends.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `ShowWinner(winner: ValString, color: ValString)`

This function shows the winner of the round or game.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `winner` | `ValString` | | Yes |
| `color` | `ValString` | `ffffff` | Yes |

---

## `HideWinner()`

This function hides the winner.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `ReturnToLobby()`

This function returns all players to the lobby.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `ShowKillFeed(victimId: ValString, killerId: ValString)`

This function adds a kill feed entry.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `victimId` | `ValString` | | Yes |
| `killerId` | `ValString` | | Yes |

---

## `SetPoints(blueScore: ValNumber, redScore: ValNumber)`

This function sets the points for each team.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `blueScore` | `ValNumber` | | Yes |
| `redScore` | `ValNumber` | | Yes |

---

## `SetTimer(time: ValString)`

This function sets the timer text.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `time` | `ValString` | | Yes |

---

## `PlayTickAudio()`

This function plays an audible tick sound. Used for the timer.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `StartRound()`

This function triggers the start of the round.
It sets the current game state to `GameState.ROUNDSTART`.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `EndRound()`

This function triggers the end of the round.
It sets the current game state to `GameState.ROUNDEND`.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---

## `EndGame()`

This function triggers the end of the game.
It sets the current game state to `GameState.GAMEEND`.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

---
## `GetPlayers()`

This function retrieves all players in the game.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| None | | | |

### Output

- `players`: `ValArray` - An array containing all players in the game.

---

## `GetPlayer(playerId: ValString)`

This function retrieves a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |

### Output

- `player`: `ValObject` - The specified player.
    - `playerId`: `ValString` - The player's id.
    - `username`: `ValString` - The player's username.
    - `kills`: `ValNumber` - The number of kills the player has.
    - `deaths`: `ValNumber` - The number of deaths the player has.
    - `team`: `ValString` - The team the player is on.
    - `isDead`: `ValNumber` - Whether or not the player is dead.

---

## `SendPlayerMessage(playerId: ValString, message: ValString)`

This function sends a message to a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |
| `message` | `ValString` | | Yes |

---

## `SendTeamMessage(team: ValString, message: ValString)`

This function sends a message to a specific team.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `team` | `ValString` | | Yes |
| `message` | `ValString` | | Yes |

---

## `SendServerMessage(message: ValString)`

This function sends a message to the server.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `message` | `ValString` | | Yes |

---

## `ShowPlayerTitle(playerId: ValString, title: ValString, subtitle: ValString)`

This function shows a title to a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |
| `title` | `ValString` | | Yes |
| `subtitle` | `ValString` | `""` | No |

---

## `ShowTeamTitle(team: ValString, title: ValString, subtitle: ValString)`

This function shows a title to a specific team.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `team` | `ValString` | | Yes |
| `title` | `ValString` | | Yes |
| `subtitle` | `ValString` | `""` | No |

---

## `ShowServerTitle(title: ValString, subtitle: ValString)`

This function shows a title to the server.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `title` | `ValString` | | Yes |
| `subtitle` | `ValString` | `""` | No |

---

## `AddKill(playerId: ValString)`

This function adds a kill to a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |

---

## `AddDeath(playerId: ValString)`

This function adds a death to a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |

---

## `KillPlayer(playerId: ValString)`

This function kills a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |

---

## `DamagePlayer(playerId: ValString, damage: ValNumber)`

This function damages a specific player.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `playerId` | `ValString` | | Yes |
| `damage` | `ValNumber` | | Yes |

### Output

- `None`