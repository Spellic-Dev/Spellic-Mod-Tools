# API VERSION 0.4.0
## Compatible from Game Version 0.4.0 onwards

---

## Public Array `Variables`
- `_events: ValArray` - The list of events that are currently registered.
- `_timers: ValArray` - The list of timers that are currently registered.

You don't need to worry about these, they are used internally.

## Gamestate `Variables`
- `PREGAME: ValNumber` - The game state for when the game is in the pregame state, this gets overwritten immediately when the game starts.
- `GAMESTART: ValNumber` - The game state for when the game is in the game start state. This is set `automatically` when the script loads.
- `ROUNDSTART: ValNumber` - The game state for when the game is in the round start state. This is set `automatically` when calling `StartRound()`.
- `ROUNDRUNNING: ValNumber` - Set this game state when the round is running. This **won't** be set automatically!
- `ROUNDFINALE: ValNumber` - This game state should be set in the last 10 seconds of the round and is used for music and other effects. This **won't** be set automatically!
- `ROUNDEND: ValNumber` - The game state for when the game is in the round end state. This is set `automatically` when calling `EndRound()`.
- `GAMEEND: ValNumber` - The game state for when the game is in the game end state. This is set `automatically` when calling `EndGame()`.

You can use this with the `ChangeGameState(state: ValNumber)` function to change the game state.

## Team `Variables`
- `TEAM_BLUE: ValString` - The identifier for the blue team.
- `TEAM_RED: ValString` - The identifier for the red team.
- `NO_TEAM: ValString` - The identifier if the player has no team / free for all.
- `DRAW: ValString` - Used for the Win Screen, when the game is a draw.

---

## `WaitForSeconds(seconds: ValNumber, callback: @Function)`

This function will wait for the specified amount of seconds and then call the callback function.
This is asynchronous, so the game will continue to run while this is waiting.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `seconds` | `ValNumber` | `0` | Yes |
| `callback` | `@Function` | `nil` | Yes |

### Output

| Name | Type | Description |
| --- | --- | --- |
| `id` | `ValNumber` | The id of the async callback. |

---

## `CancelWait(id: ValNumber)`

This function will cancel the async callback with the specified id.

### Parameters

| Name | Type | Default Value | Required |
| --- | --- | --- | --- |
| `id` | `ValNumber` | | Yes |

### Output

| Name | Type | Description |
| --- | --- | --- |
| `success` | `bool` | Whether the callback was cancelled. |

---

### Important Notes

- Functions in Miniscript will always be executed on call, so you have to pass your function with a leading `@` to make it a function reference.
- Passing in arguments to the callback function is not supported, you have to use a local function that is called without arguments, and then call your function with the arguments you want.

**You don't have to implement this yourself**, it is already implemented in the `Event Loop`.
```lua
// UTIL FUNCTIONS
WaitForSeconds = function(seconds, callback)
    // Calc end time
    end_time = time + seconds
    // Add to timers
    _timers.push({"time": end_time, "callback": @callback})
end function
```

---

## The `Event Loop`

The event loop is a function that is called every frame of the game. This is implemented by default within Spellic. **You don't have to implement this yourself**.
The event loop will be appended on the bottom of the script, so you can override it if you want to.

```lua
// GAME LOOP
while true
    // Process Events
    while _events.len > 0
        _nextEvent = _events.pull
        _nextEvent.invoke(_nextEvent.args)
    end while
    // Process Timers
    if _timers.len > 0 then
        for i in range(0, _timers.len - 1)
            timer = _timers[i]
            if timer.time < time then
                timer.callback()
                _timers.remove(i)
            end if
        end for
    end if
    yield
end while
```