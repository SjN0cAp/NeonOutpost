# Neon Outpost — Production Readiness Checklist

**Question:** Is Neon Outpost ready for a playtest build?
**Date checked:** October 22, 2026 (end of Lab 6 setup)

| Status | Check | Notes |
|---|---|---|
| [ ] | Builds have been stable for 7+ days. | CI was only set up today, so there is no 7-day history yet. |
| [x] | No critical bugs open in the tracker. | No critical bugs reported so far. |
| [ ] | Performance meets target (60 FPS, 100 enemies). | Stress test not run yet; object pooling not built. |
| [ ] | All core mechanics implemented (movement, enemy AI, waves). | Enemy chase and wave spawner are done; movement and shooting are still in progress. |
| [x] | Git workflow followed (no direct pushes to `main`). | All features merged to `develop` through PRs. |
| [ ] | CI is green on `develop` for the last 5 commits. | CI is new; need 5 green runs in a row. |

## Verdict: **NOT READY** for a playtest build.

## Blockers Added to the Backlog
Each unchecked box becomes a blocker:

| Blocker | Linked story / task |
|---|---|
| B1: Keep CI green for 7 days | Track daily on `develop` |
| B2: Run 100-enemy stress test + add object pooling | New task (R7 mitigation) |
| B3: Finish player movement and shooting | US-01, US-04 |
| B4: Get 5 green CI runs in a row on `develop` | Fix any red builds right away |

**Target:** re-check readiness on the last day of Sprint 1.
