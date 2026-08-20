"use client";
import PuzzleCard from '@/component/cards/puzzle/PuzzleCard';
import React, { useState } from 'react'
export default function PuzzlePage() {
      const [puzzles,setPuzzles] = useState([
    { id: 1, total: 10,total_complete:3, description:"Where Dark Things Dwell",category: "The Witch Returns",img:'sample1.png',progress:"w-1/6" },
    { id: 1, total: 10,total_complete:6, description:"Escape From theTower",category: "Mayday! Mayday!",img:'sample5.png',progress:"w-1/6" },
    { id: 1, total:4,total_complete:6, description:"The Treasure Hunt",category: "Treasure Rich",img:'sample7.png',progress:"w-1/6" },
    ])
  return (
    <div className='px-4 h-screen overflow-y-auto my-4'>
      <h1 className='text-center text-2xl font-bold'>Puzzles</h1>
      <p className='my-2 text-gray-700 text-sm'>Complete daily challenges to earn points and redeem them for discounts</p>
      {
        puzzles.map((puzzle, index)=>(
          <PuzzleCard key={index} puzzle={puzzle}/>
        ))
      }
    </div>
  )
}
