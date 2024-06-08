# Arena Battle Simulation API

Welcome to the **Arena Battle Simulation API** project! This API simulates a battle arena where different heroes - archers, swordsmen, and cavalry - engage in combat according to predefined rules. Each hero type has specific abilities and interactions with other types.

## Overview

This API simulates a series of battles between heroes in an arena. The rules governing the battles are:
- **Archers** have different probabilities when attacking other hero types.
- **Swordsmen** only have a direct impact on the defending hero depending on the type.
- **Cavalry** have a clear attack outcome against each hero type.

The battles proceed in rounds, with each round randomly selecting an attacker and a defender. Heroes not participating in the round will recover some of their health. The combat continues until only one hero remains alive.

## Features

- Simulates combat between three types of heroes: Archers, Swordsmen, and Cavalry.
- Rules-based attack and defense logic.
- Heroes recover health if they rest in a round.
- Comprehensive logging of battle history.
- API endpoints to manage and monitor the arena battles.
- Unit tests to ensure the correctness of the battle logic.
