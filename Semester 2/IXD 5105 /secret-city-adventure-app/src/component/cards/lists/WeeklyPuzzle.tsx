"use client"
import React, { useCallback, useState } from "react";
export default function WeeklyPuzzle() {
  const [puzzles, setPuzzles] = useState([
    { id: 1, status: true, question: "Decode the opening clue" },
    { id: 1, status: true, question: "Identity the hidden patterns" },
    { id: 1, status: false, question: "Crack the final chiper" },
  ]);
   const toggleItem = useCallback((id: number) => {
      setPuzzles((prev) =>
        prev.map((item) =>
          item.id === id ? { ...item, status: !item.status } : item,
        ),
      );
    }, []);
  return (
    <ul className="flex flex-col gap-2 justify-center">
      {puzzles.map((puzzle, index) => (
        
        <li className={`${ puzzle.status ?'line-through text-gray-500' :'text-gray-800'}`} key={index}>
          <input
            type="checkbox"
            // className="appearance-none w-4 h-4 rounded-full border border-gray-300"
            className="rounded-full border border-gray-300"
            defaultChecked={puzzle.status}
            onChange={() => false}
          />{" "}
          {puzzle.question}
        </li>
      ))}
    </ul>
  );
}
