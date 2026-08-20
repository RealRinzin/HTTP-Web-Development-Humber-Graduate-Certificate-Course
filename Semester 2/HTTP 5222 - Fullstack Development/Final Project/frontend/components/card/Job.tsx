import React from "react";

export default function Job({job}:any) {
  return (
    <div className="border border-gray-200 bg-gray-50/50 rounded-md shadow-sm p-4 my-4">
      <div className="flex gap-2">
        <img
          src={`/img/companies/${job.logo}`}
          alt=""
          className="h-10 w-10 rounded-md"
        />
        <div className="flex justify-between w-full">
          <div className="flex flex-col">
            <h2 className="text-gray-700 font-medium">{job.role}</h2>
            <ul className="flex  flex-col gap-1 text-xs ">
                <li className="text-gray-800">{job.comany}</li>
                <li>{job.location}</li>
                <li>{job.type}</li>
            </ul>
            <p className="text-gray-500 text-xs">Line Remote $900k</p>
          </div>
          <p className="text-gray-400 text-sm">2 hours ago</p>
        </div>
      </div>
    </div>
  );
}
