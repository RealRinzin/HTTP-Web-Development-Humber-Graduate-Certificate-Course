import React from "react";

export default function Progress({width}:any) {
  return (
    <div className="bg-slate-300 w-full rounded-lg h-4 flex">
      <div className={`bg-sky-800 relative ${width} rounded-lg h-4`}></div>
    </div>
  );
}
