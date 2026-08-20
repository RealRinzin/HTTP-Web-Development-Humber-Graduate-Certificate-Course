"use client";

import Progress from "@/component/progress/Progress";

export default function PuzzleCard({ puzzle }: any) {
  return (
    <div className="rounded-lg shadow-md my-10 mx-2">
      <a href="/dashboard/puzzles/category">
        <img src={`/img/sample/${puzzle.img}`} alt="" className="rounded-t-2xl w-full" />
      </a>
      <div className="flex flex-col p-4">
        <p className="text-lg text-gray-900 font-medium">{puzzle.category}</p>
        <p className="text-sm text-gray-500">{puzzle.description}</p>
        <p className="text-xs text-gray-500 py-3">{`${puzzle.total_complete} of ${puzzle.total} PUZZLES COMPLETED`}</p>
        <a href="/dashboard/puzzles/category">
        <Progress width={puzzle.progress} />
        </a>
      </div>
    </div>
  );
}
