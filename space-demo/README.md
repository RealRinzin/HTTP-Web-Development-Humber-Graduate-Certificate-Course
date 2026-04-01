# Pivot Rotation Demo — Next.js + TypeScript

A Next.js TypeScript conversion of the Three.js pivot rotation demo.  
Uses **React Three Fiber** (R3F) + **@react-three/drei** + **leva** GUI.

## Tech Stack

| Original          | Next.js Equivalent          |
|-------------------|-----------------------------|
| Three.js (ESM)    | `three` + `@react-three/fiber` |
| OrbitControls     | `@react-three/drei` → `<OrbitControls>` |
| lil-gui           | `leva` → `useControls()`    |
| Plain HTML/JS     | React components + hooks    |

## Getting Started

```bash
npm install
npm run dev
```

Open [http://localhost:3000](http://localhost:3000).

## Project Structure

```
src/
├── app/
│   ├── page.tsx          # Root page (dynamic import, no SSR)
│   ├── layout.tsx        # HTML shell + metadata
│   └── globals.css       # Reset styles
└── components/
    └── PivotScene.tsx    # Full 3D scene + GUI
```

## Key Concepts

- **`'use client'`** — Required on any component using R3F/Three.js (browser-only APIs)
- **`dynamic(() => import(...), { ssr: false })`** — Prevents Three.js from running on the server
- **`useFrame`** — R3F's per-frame hook (replaces the `animate()` loop)
- **`useControls`** (leva) — Replaces lil-gui, returns reactive values directly
- **Refs for mutable 3D state** — Position/quaternion are mutated each frame via refs, not React state (avoids re-renders)

## Controls

- **Drag** — Orbit camera
- **Scroll** — Zoom in/out
- **GUI panel (top-right)** — Adjust pivot position, cube position, orbit axis/speed, spin, wireframe toggle
