"use client";
import GameCard from "@/component/cards/game/GameCard";
import React, { useState } from "react";
export default function GamePage() {
  const [games, setGames] = useState([
    { id: 1, name: "Lost & Found", completed: true, total: 4, img: "lost_found.png" },
    {
      id: 2,
      name: "Where Dark Things Dwell",
      completed: false,
      total: 4,
      img: "sample1.png",
    },
    { id: 3, name: "Station M", completed: false, total: 4, img: "sample2.png" },
  ]);
  return (
    <div className="px-4 h-screen overflow-y-auto my-4">
      <h1 className="text-lg">Browser all of our games!</h1>
      <div className="flex flex-col my-4 w-2/5">
        <label
          htmlFor="location"
          className="text-xs rounded-t-md border border-gray-200/70 py-1 px-4"
        >
          LOCATION
        </label>
        <select
          name=""
          id=""
          className="border border-gray-200/70 rounded-b-md px-4 py-1 text-xs"
        >
          <option value="">Toronto</option>
          <option value="">Etobicoke</option>
        </select>
      </div>
      {games.map((games, index) => (
        <GameCard key={index} games={games}/>
      ))}
    </div>
  );
}
