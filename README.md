Magic Tiles 3 (Simplified) – Unity 2021.3 LTS
Overview

Simplified rhythm game inspired by Magic Tiles 3.
Tiles fall down rhythmic lanes, and the player taps on the beat to score.
Built with Unity 2021.3 LTS, targeting mobile (Android/iOS).

How to Run

Open the project in Unity 2021.3.x LTS.

Open the scene Game.unity.

Assign references in the Inspector:

SpawnAction.music → background music AudioSource

SpawnAction.tap → tap sound AudioSource

Score → TextMeshProUGUI references (scoreText, comboText, accuracyText)

ClickingEvent.menu → pause/game-over menu GameObject

Press Play in the Editor (use mouse), or build to Android/iOS for touch testing.

Controls

Tap or click anywhere on the screen when a tile reaches the hit line.

Game ends on first missed tile or off-beat tap (configurable).

Each tap gives accuracy feedback:

🟢 Perfect

🔵 Great

🟡 Good

🔴 Miss

Design Choices
🎵 Timing

Uses AudioSource.time from the background music as the authoritative clock.

Ensures spawning and tap detection remain perfectly in sync with the song.

🧩 Spawner

SpawnAction.cs spawns tiles 1.5 beats early so they reach the hit line exactly on the beat.

Tile fall speed is calculated dynamically:

fallSpeed = fallDistance / timeUntilBeat;

⏱️ Hit Windows

Perfect: within 0.1f units of the tap line.

Great: within 0.25f units.

Good: within 0.4f units.

Miss: beyond 0.4f (ends game).

💥 Feedback

Tap sound (tap AudioSource) plays when a tile is hit.

Text feedback (“Perfect”, “Great”, “Good”, “MISS!”) shows for 2 seconds.

Accuracy text color changes by result.

Optional particle prefabs can be added for visual effects.

🔢 Combo & Multiplier

Combo increases on every successful hit.

Combo resets to zero on “Miss.”

Future extension: multiplier increments every 10 hits.

🌀 Object Pooling (Future-Ready)

Current design uses Instantiate, but easily upgradable to ObjectPool for optimization.

Spawn system and tile lifecycle are already modular and compatible with pooling.

Files of Interest
Script	Description
ClickingEvent.cs	Manages UI, menu, restart, and scene transitions.
DestroyerCheckScript.cs	Removes off-screen tiles.
MusicManager.cs	Controls background music timing and playback.
PositionScript.cs	Draws grid positions for spawn and tap lines (editor only).
Score.cs	Handles score, combo, and accuracy feedback (text shown for 2s).
SpawnAction.cs	Spawns tiles rhythmically in sync with music BPM and calculates fall speed.
TileAction.cs	Manages tile falling motion, tap detection, and accuracy scoring.
Attribution

Music & SFX: Royalty-free from Pixabay Music

Font: TextMeshPro (Unity built-in)

Particles: Unity’s default particle system

Sprites/Prefabs: Custom-built or Unity primitives
