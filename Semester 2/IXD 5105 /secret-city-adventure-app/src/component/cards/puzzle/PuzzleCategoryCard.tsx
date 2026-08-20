"use client";

import ButtonLarge from "@/component/button/ButtonLarge";
import Progress from "@/component/progress/Progress";
import { faCircleCheck } from "@fortawesome/free-regular-svg-icons";
import { faCheck } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function PuzzleCategoryCard({ puzzle }: any) {
  return (
    <div className="rounded-lg shadow-md my-10 mx-2">
      <a href="/dashboard/puzzles/category">
        <img src={`/img/sample/${puzzle.img}`} alt="" className="rounded-t-2xl w-full" />
      </a>
      <div className="flex flex-col p-4">
        {puzzle.completed ? (
          <>
            <p className="text-lg text-gray-900 font-medium">{puzzle.name}</p>
            <p className="text-sm text-gray-500">{puzzle.type}</p>
            <p className="text-xs text-gray-500 py-3">{`${puzzle.total} WORDS FOUND`}</p>
            <div className="flex flex-col gap-2">
              <Progress width={puzzle.progress} />
              <ButtonLarge text="Play" link="/dashboard/puzzles/category/play" />
            </div>
          </>
        ) : (
          <>
            <p className="text-lg text-gray-900 font-medium flex justify-between">
              {puzzle.name}
              <span className="text-xs bg-green-600 rounded-full h-4 w-4 flex justify-center items-center">
                <FontAwesomeIcon icon={faCheck} className="text-white" />
              </span>
            </p>
            <p className="text-sm text-gray-500">Completed</p>
          </>
        )}
      </div>
    </div>
  );
}
