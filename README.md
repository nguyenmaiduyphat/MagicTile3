# Magic Tiles 3 (Simplified) - Unity 2021.3 LTS

## Overview
Simplified rhythm game inspired by Magic Tiles 3. Tiles fall down lanes, player taps on beat to score. Built for Unity 2021.3 LTS targeting mobile (Android/iOS).

## How to run
1. Open in Unity 2021.3.x LTS.
2. Open scene `MainScene`.
3. Assign references in inspector:
   - `AudioManager.musicSource` -> music audio clip
   - `TileSpawner.pool` -> ObjectPool prefab containing Tile prefab
   - `UIManager` text references, lane rects, effect prefabs
4. Press Play in Editor to test (use mouse) or build to Android for touch.

## Controls
- Click or tap the tile when it's on the hitline.
- Game ends on first missed tile (can be configured).

## Design choices
- **Timing**: Uses `AudioSource.time` as authoritative clock so spawn & hit detection sync to audio.
- **Spawner**: Spawns tile `travelTime` seconds before expected hitTime (so tile reaches hitLine exactly on beat).
- **Hit windows**: Perfect 60ms, Good 130ms — adjustable in GameManager inspector.
- **Object pooling**: `ObjectPool` used to reduce GC and allocations.
- **Combo & multiplier**: Simple combo increments multiplier every 10 hits.
- **Feedback**: Particle prefabs instantiated at hit location; audio SFX not included by default but supported.

## Files of interest
- `ClickingEvent.cs`, `DestroyerCheckScript.cs`, `MusicManager.cs`, `PositionScript.cs`, `Score.cs`, `SpawnAction.cs`, `TileAction.cs`.

## Attribution
- Any third-party assets used (sprites, audio, particle prefabs) should be listed here. (If you used assets from the Unity Asset Store, include their package names & license.)
