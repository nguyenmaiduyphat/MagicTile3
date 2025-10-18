Magic Tiles 3 (Simplified) – Unity 2021.3 LTS
🕹️ Overview

This project is a simplified rhythm game inspired by Magic Tiles 3.
Tiles fall down rhythmic lanes, and the player taps them in time with the background music to score points.
Developed using Unity 2021.3 LTS, targeting mobile platforms (Android/iOS).

🚀 How to Run

Open the project in Unity 2021.3.x LTS.

Open the Game.unity scene.

Assign references in the Inspector if missing:

SpawnAction.music → background music AudioSource

SpawnAction.tap → tap sound AudioSource

Score → scoreText, comboText, accuracyText (TextMeshProUGUI)

ClickingEvent.menu → pause or game over menu GameObject

Press Play in the Editor (use mouse clicks), or build to Android/iOS for touch control.

Tap on the tiles in rhythm with the song. Missing or tapping off-beat ends the game.

⚙️ Design Choices
🎵 Music Synchronization

The game uses AudioSource.time as the main clock for precise rhythm tracking.

Each tile is spawned early and moves at a dynamically calculated fall speed, so it reaches the hit line exactly when the beat occurs:

fallSpeed = fallDistance / timeUntilBeat;

🧩 Tile Spawning & Timing

SpawnAction.cs spawns tiles 1.5 beats before the target hit time based on BPM.

Works consistently across devices and frame rates.

⏱️ Scoring & Accuracy

Accuracy levels: Perfect, Great, Good, and Miss.

Each tap is judged by vertical distance from the hit line.

Score and combo values are displayed briefly (2 seconds) after every hit.

💥 Feedback System

Tap sound plays on every successful hit.

Colored accuracy text gives immediate feedback.

Easily extendable for particle or animation effects.

🔢 Combo System

Consecutive hits increase combo count.

Miss resets combo to 0.

Can be extended with score multipliers for longer streaks.

🌀 Performance & Structure

Clean, modular scripts separated by purpose (spawning, scoring, UI, music).

Designed for easy extension to object pooling or beatmap data systems.

📜 Attribution

Music & Sound Effects: Royalty-free assets from Pixabay Music

Font: TextMeshPro (Unity built-in)

Particles & Visuals: Unity default particle system (customized)

Code: All gameplay and logic scripts authored by Nguyễn Mai Duy Phát
