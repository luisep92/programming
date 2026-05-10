# programming — 1st-year DAM coursework

C# / Java coursework from 1º DAM (2022–2023). Public because the interesting parts deserve a pointer.

---

Mixed feelings about this repo. It's where I started programming for real — and it shows: 149 commits, plenty of them named `a`, `asd`, `yhujm`, or `pintar`. Lots of WIP folders that don't go anywhere. But there are pieces in here I'd still defend, and a couple of them aren't what you'd expect from a first-year student. This README is the index that picks them out so you don't have to spelunk.

## What's worth your time

### A custom GameObject + Component system

`Ev1/Space Invaders/SpaceInvaders/SpaceInvaders/Base classes/`

A small Unity-flavored framework (`GameObject.cs`, `Component.cs`, `Transform.cs`, `Renderer.cs`, `Animator.cs`, `Collider.cs`) with lifecycle queues for safe instantiation/destruction and a tag enum for filtering. It started life inside the "ratón y gato" iterations and got reused all year — Space Invaders, the chess game in Ev2, the minesweeper variants. The cleanest version is the one bundled with Space Invaders.

I had a couple of years of Unity under my belt when I wrote this, which is why a first-year DAM student ended up shipping a Unity-shaped framework on top of the teacher's graphics library.

### Space Invaders

`Ev1/Space Invaders/`

Around 42 source files built on the GameObject system: particles, sprite animations, screen shake, parallax, multiple enemy types, power-ups. The piece I pushed hardest because I already knew the toolbox.

### Minesweeper with three implementations behind one interface

`Ev3/Buscaminas/`

`IBoard` (in `BuscaminasLib/`) exposes `Init`, `IsBombAt`, `GetBombsAround` (with a default implementation in the interface), `OpenCell`, `PutFlagAt`, `RemoveFlagAt`, `IsFlagAt`, `IsOpenCell`, `HasWin`, `DrawOnConsole`. Three concrete classes (`Board1`, `Board2`, `Board3`) implement it differently. A clean small example of abstraction-by-design rather than abstraction-because-the-textbook-said-so.

### A shortest-path solver with non-textbook abstractions

`Ev3/Pathfinding/`

I remember writing this thinking "A\*". Reading it back today, there's no heuristic — it's hand-rolled Dijkstra with a few non-standard moves: a `Way` struct that pairs the cumulative weight with the previous node (path reconstruction is a back-walk through `_wayInfo[node].PreviousNode`), the frontier (`_nodes`) gets mutated mid-iteration as nodes get processed, and the next-node selection does `OrderByDescending(...).Reverse().First()` instead of using a priority queue. It works. I wouldn't write it like this today, and that's the point — it's the shape the algorithm took before I'd seen anyone else's version.

### A horse-rating WPF app with a partial-fill star trick

`Ev3/Tinder/`

SQL Server with stored procedures + XAML. The fun bit lives in `Tinder/UserCell.xaml` (lines 28–38): two stacked `<Image>` elements (empty-star outlines as a base, filled stars as an overlay), with the overlay using `Image.OpacityMask = LinearGradientBrush` whose `EndPoint` is data-bound to `ValorationEndPoint`. Both gradient stops sit at `Offset=1` (Black → Transparent), giving a sharp visibility boundary that slides as the rating changes — partial-fill stars from a single mask binding.

## Also in here, briefly

- **Monty Hall (Java, Maven)** — `Ev3/MontyHall/`. 1M-iteration simulation to confirm the paradox.
- **Chess** — `Ev2/Chess/`. Reuses the GameObject system, with a generic `Board` and a piece hierarchy. **Incomplete** — the teacher's review comments are still in the code (sample from `ChessLib/Board.cs`: `// Javi: No entiendo, ..., está función por fuerza tiene que estar mal`). Kept for honesty, not as a portfolio piece.
- Plus exam folders, exercises, scratch experiments, and three iterations of the "ratón y gato" toy that the GameObject system grew out of. Worth ignoring.

## About the graphics library

`Framework dam/net6.0/DAMGL.dll` is the teacher's library — distributed as a binary only, so the source isn't in the repo. From the surface used by the projects above, it provides: an `ICanvas` for filled polygons, rectangles, and sprites with transparency; an `IAssetManager` for PNGs, fonts, and effects; `IKeyboard` and `IMouse`; and a `Camera` for viewport control. The GameObject + Component layer is what I built on top of it.

## Stack

C# (.NET 6) for almost everything, Java (Maven) for the Monty Hall sim, WPF for the horse-rating app. Teacher's `DAMGL.dll` for graphics in the Ev1 / Ev2 pieces.

## License

[MIT](LICENSE).
