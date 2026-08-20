import ButtonLarge from "@/component/button/ButtonLarge";
import WeeklyPuzzle from "@/component/cards/lists/WeeklyPuzzle";
import Progress from "@/component/progress/Progress";
import Image from "next/image";
import React from "react";

export default function HomePage() {
  return (
    <main className="bg-gray-200/20 px-4 h-screen overflow-y-auto ">
      {/* Level - Welcome */}
      <div className="py-4">
        <div className="flex justify-between py-2">
          <ul>
            <li className="text-sm text-gray-400">Your Rank</li>
            <li className="text-gray-700 font-bold">Level 7</li>
            <li className="text-xs text-gray-400">Senior Investigator</li>
          </ul>
          <ul>
            <li className="text-gray-400">POINTS</li>
            <li className="text-gray-800">2,840</li>
          </ul>
        </div>
      </div>
      {/* Progress / Redeem */}
      <div className="py-4">
        <p className="text-xs text-gray-500 py-1">XP PROGRESS</p>
        <Progress width="w-1/3" />
        <ul className="p-4 text-xs font-medium text-gray-800 list-disc mx-2">
          <li>700 pts = 20% off next booking</li>
          <li>1500 pts = 50% off next booking</li>
          <li>2,100 pts = free guest when booking for parties of 6</li>
        </ul>
        <ButtonLarge text="Redeem Discount" link="/dashboard" />
      </div>
      <div>
        <p className="text-gray-700 ">We Miss You! Let's Meet Again</p>
        <Image
          src="/img/sample.png"
          className="w-full my-4"
          alt="Test"
          width={400}
          height={160}
        />
        <ButtonLarge text="Book a Room" link="/dashboard/games" />
      </div>

      {/* Weekly */}
      <div className="my-4">
        <p className="text-gray-700">Weekly Puzzles</p>
        <div className="flex gap-2 py-4">
          <div className="basis-1/3">
            <Image src="/img/sample.png" alt="Test" width={120} height={80} />
          </div>
          <div className="basis-2/3">
            <ul>
              <li className="text-gray-800 font-bold">
                The Black Creek Riddle
              </li>
              <li className="text-gray-600 text-sm">Description</li>
            </ul>
          </div>
        </div>
        <WeeklyPuzzle/>
        <div className="py-2">
          <Progress width="w-1/5" />
          <p className="my-1 text-gray-700 text-xs">2/3 steps completed</p>
        </div>
        <ButtonLarge text="Play" link="/dashboard/activities" />
      </div>
    </main>
  );
}
