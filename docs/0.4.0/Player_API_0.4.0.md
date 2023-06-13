# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## Player `ValMap` API

A `ValMap` is a map containing the following player information:
- `playerId`: `ValString` - The player's id.
- `username`: `ValString` - The player's username.
- `kills`: `ValNumber` - The number of kills the player has.
- `deaths`: `ValNumber` - The number of deaths the player has.
- `team`: `ValString` - The team the player is on.
- `isDead`: `ValNumber` - Whether or not the player is dead.

---

## Mob `ValMap` API

A `ValMap` is a map containing the following mob information:
- `mobHealth`: `ValNumber` - The mob's current health.
- `mobMaxHealth`: `ValNumber` - The mob's maximum health.
- `mobAttackDamage`: `ValNumber` - The mob's attack damage.
- `mobAttackSpeed`: `ValNumber` - The mob's attack speed.
- `mobDetectRange`: `ValNumber` - The mob's detection range.
- `mobAttackRange`: `ValNumber` - The mob's attack range.
- `mobSpeed`: `ValNumber` - The mob's speed.
- `name`: `ValString` - The game object name of the mob.