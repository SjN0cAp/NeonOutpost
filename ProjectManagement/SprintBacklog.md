# Neon Outpost — Sprint 1 Backlog

**Sprint length:** 2 weeks (10 working days)
**Team:** 2 programmers, 1 artist, 1 designer
**Sprint goal:** A playable core loop — the player can move, shoot, survive enemy waves from four directions, and collect scrap.
**Team capacity:** about 30 story points (based on 4 people, part-time lab pace).

## Story Points Scale
1 = trivial, 2 = small, 3 = medium, 5 = large, 8 = very large (split if possible)

## Backlog (sorted by priority)

### US-01: Player movement
As a player, I want to move my character with WASD so that I can dodge enemies.
- AC1: W/A/S/D moves the player up/left/down/right.
- AC2: Movement speed is 5 units per second.
- AC3: The player cannot leave the arena walls.

**Points:** 2 **MoSCoW:** Must **Owner:** Programmer 1

### US-02: Enemy waves from four directions
As a player, I want enemies to spawn in waves from all four sides so that I must watch every direction.
- AC1: Each wave spawns enemies from the North, East, South, and West spawn points.
- AC2: Each wave has 2 more enemies than the last one (wave 1 = 4).
- AC3: The next wave starts only after all enemies are defeated and a 10-second break ends.

**Points:** 5 **MoSCoW:** Must **Owner:** Programmer 2 **Branch:** `feature/wave-spawner`

### US-03: Enemy chase
As a player, I want enemies to chase me when I am close, so that the world feels threatening.
- AC1: Enemy detects the player within 5 units.
- AC2: Enemy moves toward the player at speed 3.
- AC3: Enemy stops chasing beyond 10 units.

**Points:** 3 **MoSCoW:** Must **Owner:** Programmer 2 **Branch:** `feature/enemy-chase`

### US-04: Shooting
As a player, I want to aim with the mouse and shoot so that I can defeat enemies.
- AC1: The player faces the mouse cursor.
- AC2: Left-click fires a bullet in the facing direction.
- AC3: A bullet that hits an enemy removes 1 health; an enemy with 0 health is destroyed.

**Points:** 3 **MoSCoW:** Must **Owner:** Programmer 1

### US-05: Base health and game over
As a player, I want my base to have health so that I know what I am defending and when I lose.
- AC1: The base starts with 100 health.
- AC2: An enemy that touches the base deals 10 damage and is destroyed.
- AC3: At 0 health, a "Game Over" screen appears with a Restart button.

**Points:** 3 **MoSCoW:** Must **Owner:** Programmer 1

### US-06: Scrap drops
As a player, I want defeated enemies to drop scrap so that I am rewarded for fighting.
- AC1: Each defeated enemy drops 1 scrap item.
- AC2: Walking over scrap adds it to my total and removes it from the ground.
- AC3: The scrap total is shown on the HUD.

**Points:** 2 **MoSCoW:** Should **Owner:** Programmer 2

### US-07: Weapon upgrade between waves
As a player, I want to spend scrap on upgrades between waves so that I feel stronger over time.
- AC1: An upgrade menu opens during the break between waves.
- AC2: "Fire Rate +20%" costs 10 scrap and is greyed out if I cannot afford it.
- AC3: The menu closes when the next wave starts.

**Points:** 5 **MoSCoW:** Should **Owner:** Designer + Programmer 1

### US-08: Neon art pass
As a player, I want neon-style sprites for the player, enemies, and base so that the game has a clear look.
- AC1: Player, enemy, base, and bullet each have a final sprite.
- AC2: All sprites use the agreed neon color palette.
- AC3: Sprites are imported at the same pixels-per-unit setting.

**Points:** 3 **MoSCoW:** Should **Owner:** Artist

### US-09: Wave counter on HUD
As a player, I want to see the current wave number so that I can track my progress.
- AC1: The HUD shows "Wave X" at the top of the screen.
- AC2: The number updates when a new wave starts.

**Points:** 1 **MoSCoW:** Could **Owner:** Designer

### US-10: Boss enemy
As a player, I want a boss every fifth wave so that the game has big moments.
- AC1: Wave 5 spawns one boss with 20 health.
- AC2: The boss moves at half normal speed.

**Points:** 8 **MoSCoW:** Won't (this sprint) — moved to Sprint 2 to protect scope.

## Sprint Summary

| Priority | Stories | Points |
|---|---|---|
| Must | US-01, US-02, US-03, US-04, US-05 | 16 |
| Should | US-06, US-07, US-08 | 10 |
| Could | US-09 | 1 |
| **Committed total** | | **27** |
| Won't | US-10 | (8, deferred) |

The committed total (27) stays under the team capacity (~30) to leave room for bug fixes and CI setup.
