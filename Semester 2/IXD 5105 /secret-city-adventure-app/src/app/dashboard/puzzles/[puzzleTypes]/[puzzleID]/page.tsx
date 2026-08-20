"use client";
import React, { useState, useEffect, useMemo, useRef } from "react";
import { ArrowLeft, Settings, Home, Compass, Puzzle as PuzzleIcon, User } from "lucide-react";

// --- Puzzle definition -----------------------------------------------
// row/col are 0-indexed grid coordinates. Words that cross must agree
// on the shared letter (validated below in dev via console.assert).
const WORDS = [
  { num: 1, dir: "down", row: 0, col: 6, answer: "FIRE", clue: "Element the witch fears" },
  { num: 2, dir: "across", row: 3, col: 2, answer: "CURSE", clue: "What binds the victim" },
  { num: 3, dir: "down", row: 4, col: 1, answer: "MOON", clue: "Lights the ritual night" },
  { num: 4, dir: "across", row: 7, col: 1, answer: "NIGHT", clue: "When the ritual happens" },
] as const;

const GRID_ROWS = 8;
const GRID_COLS = 8;

type Cell = {
  letter: string;
  number?: number;
  wordIds: number[]; // which WORDS[] indices use this cell
};

function buildGrid() {
  const cells = new Map<string, Cell>();
  WORDS.forEach((word, wordIdx) => {
    word.answer.split("").forEach((letter, i) => {
      const row = word.dir === "down" ? word.row + i : word.row;
      const col = word.dir === "across" ? word.col + i : word.col;
      const key = `${row},${col}`;
      const existing = cells.get(key);
      if (existing) {
        console.assert(
          existing.letter === letter,
          `Grid conflict at ${key}: "${existing.letter}" vs "${letter}"`
        );
        existing.wordIds.push(wordIdx);
      } else {
        cells.set(key, {
          letter,
          number: i === 0 ? word.num : undefined,
          wordIds: [wordIdx],
        });
      }
    });
  });
  return cells;
}

const TOTAL_SECONDS = 3 * 60 + 14; // 03:14

function formatTime(totalSeconds: number) {
  const m = Math.floor(totalSeconds / 60);
  const s = totalSeconds % 60;
  return `${String(m).padStart(2, "0")}:${String(s).padStart(2, "0")}`;
}

export default function WitchHuntPuzzle() {
  const grid = useMemo(() => buildGrid(), []);
  const [values, setValues] = useState<Record<string, string>>({});
  const [checked, setChecked] = useState(false);
  const [secondsLeft, setSecondsLeft] = useState(TOTAL_SECONDS);
  const inputRefs = useRef<Record<string, HTMLInputElement | null>>({});

  useEffect(() => {
    if (secondsLeft <= 0) return;
    const id = setInterval(() => setSecondsLeft((s) => (s <= 1 ? 0 : s - 1)), 1000);
    return () => clearInterval(id);
  }, [secondsLeft <= 0]);

  const cellKeys = useMemo(() => {
    // ordered list of active cell keys, row-major, for tab/auto-advance
    const keys: string[] = [];
    for (let r = 0; r < GRID_ROWS; r++) {
      for (let c = 0; c < GRID_COLS; c++) {
        const key = `${r},${c}`;
        if (grid.has(key)) keys.push(key);
      }
    }
    return keys;
  }, [grid]);

  const handleChange = (key: string, raw: string, row: number, col: number) => {
    const char = raw.slice(-1).toUpperCase();
    setValues((prev) => ({ ...prev, [key]: char }));
    setChecked(false);

    if (!char) return;
    // advance to the next cell to the right if one exists, else the next cell below
    const rightKey = `${row},${col + 1}`;
    const downKey = `${row + 1},${col}`;
    if (grid.has(rightKey)) inputRefs.current[rightKey]?.focus();
    else if (grid.has(downKey)) inputRefs.current[downKey]?.focus();
  };

  const isWordSolved = (word: (typeof WORDS)[number]) => {
    for (let i = 0; i < word.answer.length; i++) {
      const row = word.dir === "down" ? word.row + i : word.row;
      const col = word.dir === "across" ? word.col + i : word.col;
      if ((values[`${row},${col}`] || "") !== word.answer[i]) return false;
    }
    return true;
  };

  const allSolved = WORDS.every(isWordSolved);

  return (
    <div className="min-h-screen bg-slate-100 flex flex-col">
      {/* Hero */}
      <div className="bg-[#0b1b33] px-6 pt-6 pb-10 text-center">
        <h1 className="text-white text-3xl font-serif">The Witch Hunt</h1>
        <p className="text-white/80 text-sm mt-1">Solve the crossword to lift the curse</p>
      </div>

      {/* Main card */}
      <div className="px-4 -mt-6 flex-1">
        <div className="bg-slate-400 rounded-2xl p-4">
          {/* Timer */}
          <div className="bg-slate-100 rounded-xl flex flex-col items-center py-4">
            <p className="text-xs tracking-widest text-slate-500">MISSION TIMER</p>
            <p className={`text-3xl font-bold mt-1 ${secondsLeft <= 0 ? "text-red-500" : "text-slate-900"}`}>
              {formatTime(secondsLeft)}
            </p>
            <p className="text-xs text-slate-500 mt-1">
              {secondsLeft <= 0 ? "TIME'S UP" : "REMAINING"}
            </p>
          </div>

          {/* Grid */}
          <div className="py-6 flex justify-center overflow-x-auto">
            <div
              className="grid gap-1"
              style={{ gridTemplateColumns: `repeat(${GRID_COLS}, minmax(0, 1fr))` }}
            >
              {Array.from({ length: GRID_ROWS }).flatMap((_, row) =>
                Array.from({ length: GRID_COLS }).map((_, col) => {
                  const key = `${row},${col}`;
                  const cell = grid.get(key);
                  if (!cell) {
                    return <div key={key} className="w-9 h-9" />;
                  }
                  const correct = values[key] === cell.letter;
                  return (
                    <div key={key} className="relative w-9 h-9">
                      {cell.number && (
                        <span className="absolute top-0.5 left-1 text-[9px] text-slate-500 leading-none">
                          {cell.number}
                        </span>
                      )}
                      <input
                        ref={(el) => {
                          inputRefs.current[key] = el;
                        }}
                        value={values[key] || ""}
                        onChange={(e) => handleChange(key, e.target.value, row, col)}
                        maxLength={1}
                        className={`w-9 h-9 text-center rounded-sm font-bold uppercase text-sm outline-none border
                          ${checked && correct ? "bg-emerald-200 border-emerald-500" : ""}
                          ${checked && !correct && values[key] ? "bg-rose-200 border-rose-400" : ""}
                          ${!checked ? "bg-white border-slate-300 focus:border-slate-600" : ""}
                        `}
                      />
                    </div>
                  );
                })
              )}
            </div>
          </div>

          {/* Clues */}
          <div className="bg-slate-500 rounded-xl p-5 text-slate-100">
            <div className="grid grid-cols-2 gap-4">
              <div>
                <h3 className="font-serif text-lg text-center mb-2">Across</h3>
                <ul className="text-xs space-y-2">
                  {WORDS.filter((w) => w.dir === "across").map((w) => (
                    <li key={w.num} className={isWordSolved(w) ? "line-through opacity-60" : ""}>
                      {w.num}. {w.clue}
                    </li>
                  ))}
                </ul>
              </div>
              <div>
                <h3 className="font-serif text-lg text-center mb-2">Down</h3>
                <ul className="text-xs space-y-2">
                  {WORDS.filter((w) => w.dir === "down").map((w) => (
                    <li key={w.num} className={isWordSolved(w) ? "line-through opacity-60" : ""}>
                      {w.num}. {w.clue}
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>

          <button
            onClick={() => setChecked(true)}
            className="w-full bg-slate-800 text-white rounded-xl py-3 font-medium mt-4"
          >
            Check Answers
          </button>

          {allSolved && (
            <p className="text-center text-emerald-700 font-semibold mt-3">
              🎉 The curse is lifted!
            </p>
          )}
        </div>
      </div>
    </div>
  );
}
