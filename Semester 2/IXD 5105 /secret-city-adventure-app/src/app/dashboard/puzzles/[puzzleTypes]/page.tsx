"use client";
import PuzzleCard from '@/component/cards/puzzle/PuzzleCard';
import PuzzleCategoryCard from '@/component/cards/puzzle/PuzzleCategoryCard';
import React, { useState } from 'react'
export default function PuzzleType() {
      const [puzzles,setPuzzles] = useState([
        {id:1,name:"Missing Tarrot Cards",completed:true, total:4, type:"crossword",img:"sample4.png"},
        {id:2,name:"The witch Hunts",completed:false, total:4, type:"crossword",img:"sample6.png"},
        {id:3,name:"The witch Hunts",completed:false, total:4, type:"crossword",img:"sample3.png",},
    ])
  return (
    <div className='px-4 h-screen overflow-y-auto my-4'>
      <h1 className='text-center text-2xl font-bold'>The Witch Returns</h1>
      < p  className='my-2 text-gray-700 text-sm'>Can you complete the challenges and save the village from the evils forces?</p>
      {
        puzzles.map((puzzle, index)=>(
          <PuzzleCategoryCard key={index} puzzle={puzzle}/>
        ))
      }
    </div>
  )
}
