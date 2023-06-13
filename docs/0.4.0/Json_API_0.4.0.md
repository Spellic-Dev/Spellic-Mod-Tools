# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## Mod Info `Json`

The Mod Info file is a JSON file that contains information about the mod.
It is used by the game to display information about the mod in the mod menu and export and load assets.

| Property | Type | Description |
| --- | --- | --- |
| `name` | `string` | The name of the mod. |
| `author` | `string` | The author of the mod. |
| `version` | `string` | The version of the mod. |
| `gameVersion` | `string` | The API version of Spellic this mod is compatible with. |
| `thumbnail` | `string` | The path to the thumbnail image for the mod. |
| `dependencies` | `array of strings` | An array of dependencies for the mod. |
| --- | --- | --- |
| `map` | `object` | An object containing information about the map that the mod adds. |
| `map.name` | `string` | The name of the map. |
| `map.description` | `string` | A description of the map. |
| `map.gamemodes` | `array of strings` | An array of game modes that the map is compatible with. |
| `map.mobs` | `array of objects` | An array of mobs that can spawn in the map. |
| `map.mobs.name` | `string` | The name of the mob. |
| `map.mobs.spawnChance` | `float` | The chance of the mob spawning. |
| `map.path` | `string` | The path to the scene file for the map. |
| `map.settings` | `object` | An object containing custom settings for the map. |
| `map.settings.gravityMultiplier` | `float` | The gravity multiplier for the map. |
| `map.settings.contrastLevel` | `int` | The contrast level for the map. |
| --- | --- | --- |
| `gamemode` | `object` | An object containing information about the game mode that the mod adds. |
| `gamemode.name` | `string` | The name of the game mode. |
| `gamemode.path` | `string` | The path to the file containing the game mode script. |
| `gamemode.teamBased` | `boolean` | Whether the game mode is team-based. |
| `gamemode.allowMobs` | `boolean` | Whether mobs are allowed in the game mode. |
| `gamemode.hasDifficulty` | `boolean` | Whether the game mode has a difficulty setting. |
| `gamemode.hasRounds` | `boolean` | Whether the game mode has rounds. |
| `gamemode.hasRoundTime` | `boolean` | Whether the game mode has a round time limit. |
| `gamemode.compatible` | `string` | The game mode that the mod is compatible with. |
| `gamemode.rounds` | `array of integers` | An array of round numbers. |
| `gamemode.roundTimes` | `array of integers` | An array of round time limits. |