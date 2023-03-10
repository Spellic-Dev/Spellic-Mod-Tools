# Spellic Modding
## About
Spellic is a 2.5D Wizard Shooter. This is the official modding repository. Currently you can create custom maps for Spellic, but more will come.
## Requirements
- Unity Version 2021.3.10f1
- This repository
- To publish your Mod, you need to download the `Spellic Workshop Tools` in your Steam Library.

## Map Utils
We provide many different utility classes for map creation, which we will develop further with ongoing development of Spellic. Most of these classes and tools are the same ones that we use to create built in maps, however we cannot guarantee that every tool that we build will be available as a utility class for creating maps.

## Mod Info JSON
The ModInfo JSON is bundled inside your mod folder and used for metadata and asset loading.
The following attributes contribute to the JSON file.
| Attribute        | Type          | Description                                                                                     | Example              |
|------------------|---------------|-------------------------------------------------------------------------------------------------|----------------------|
| **name**         | string        | The Name of the mod you are creating.                                                           | Example Mod          |
| **author**       | string        | The name of the original author (you).                                                          | SteffTek             |
| **version**      | string        | Mod Version                                                                                     | 0.0.1                |
| **thumbnail**    | string        | Path to the Thumbnail inside the assets folder.                                                 | Assets/Thumbnail.png |
| **dependencies** | Array[string] | A list of IDs that are neccessary for this mod to work. Without these, the mod won't be loaded. | ["00001","00002"]    |
| **map**          | Map           | See [Map Definition](#Map-Definition)                                                           |                      |
| **gamemode**     | Game Mode     | See [Gamemode Defintion](#GameMode-Definition)                                                  |                      |
### Map Definition
| Attribute       | Type          | Description                                                                      | Example                        |
|-----------------|---------------|----------------------------------------------------------------------------------|--------------------------------|
| **name**        | string        | The name of your map in the map viewer.                                          | The Sample                     |
| **description** | string        | A description of your map for the loading screen.                                | A simple sample.               |
| **gamemodes**   | Array[string] | All gamemodes available with your map. See [Valid Gamemodes](#Valid-Gamemodes)   | ["TDM","FFA"]                  |
| **mobs**        | Array[string] | The mobs your map will be able to spawn. See [Valid Mobs](#Valid-Mobs)           | ["FireSlime"]                  |
| **path**        | string        | The path to your Unity Scene.                                                    | Assets/Scene/SampleScene.unity |
### GameMode Definition
This is currently not viable.

### Valid GameModes
Since you currently cannot create your own game modes you have to rely on the given ones.
- TDM
- FFA
- CTF
- PvE

### Valid Mobs
Currently available mobs are:
- Rat
- VoidSlime
- FireSlime
- Skeleton

## Mirror
Mirror is the Networking Library of Spellic. We use Mirror for synchronizing data between clients and servers. Some scripts need Mirror and the Network Identity Component and will attach it on apply.

If you get an error loading up your map, it's probably because Mirror thinks you should resave & rebuild your scene, until every component with a Network Identity has it's own SceneId. It is however important to never encapsule multiple Network Identities in another.