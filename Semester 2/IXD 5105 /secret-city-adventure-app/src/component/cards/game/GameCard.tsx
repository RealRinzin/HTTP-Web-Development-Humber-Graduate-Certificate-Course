import ButtonLarge from '@/component/button/ButtonLarge'
import React from 'react'

export default function GameCard({games}:any) {
  return (
    <div className="rounded-lg shadow-md my-10 mx-2">
      <a href="/dashboard/games/1">
        <img src={`/img/sample/${games.img}`} alt="" className="rounded-t-2xl w-full" />
      </a>
      <div className="flex flex-col p-4 gap-4">
        <p className="text-lg text-gray-900 font-medium">{games.name}</p>
        <ButtonLarge link="/dashboard/games/1" text="Learn More"/>
      </div>
    </div>
  )
}

