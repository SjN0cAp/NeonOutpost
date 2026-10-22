# Neon Outpost — Risk Matrix

| # | Risk | Likelihood | Impact | Mitigation (concrete action) | Owner |
|---|---|---|---|---|---|
| R1 | **Feature creep** — designer keeps adding new weapons mid-sprint. | High | Med | New ideas go to the product backlog, not the current sprint. Only the product owner can add items during a sprint. | Product Owner |
| R2 | **Merge conflicts in Unity scene files** — two people edit `Main.unity` at once. | High | High | Force Text serialization; one scene owner at a time; build gameplay as prefabs; use Unity Smart Merge (UnityYAMLMerge). | Lead Dev |
| R3 | **Unstable CI builds** — Unity license errors or cache misses. | Med | High | Store the license as GitHub Secrets (`UNITY_LICENSE`, `UNITY_EMAIL`, `UNITY_PASSWORD`); cache the `Library` folder; use a Unity version that GameCI has a Docker image for; keep Unity jobs behind a switch until the license works. | Lead Dev |
| R4 | **Unrealistic 2-week scope.** | Med | High | Commit to only 27 of ~30 points; boss enemy (8 pts) moved to Sprint 2; mid-sprint check on day 5 to drop "Could" items if behind. | Product Owner |
| R5 | **Insufficient testing of enemy AI** — chase bugs found late. | Med | Med | Keep AI logic in pure static methods with EditMode unit tests that run in CI; designer playtests every merge to `develop`. | Programmer 2 |
| R6 | **Large art files bloat the repo** — slow clones and pushes. | Med | Med | Track `.psd`, `.wav`, `.fbx` with Git LFS; artist commits only exported, compressed assets to `Assets/`. | Artist |
| R7 | **Performance drops with many enemies** (below 60 FPS at 100 enemies). | Low | High | Use object pooling for enemies and bullets; run a 100-enemy stress test before the playtest build. | Programmer 1 |

## Rating Key
- **Likelihood:** Low = unlikely this sprint, Med = could happen, High = expected to happen.
- **Impact:** Low = minor delay, Med = a story slips, High = sprint goal or build at risk.

**Top priority risks (High/High):** R2 — handled first, before feature work starts.
