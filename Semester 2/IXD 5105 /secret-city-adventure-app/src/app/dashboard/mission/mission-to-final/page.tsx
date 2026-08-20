"use client";
import React, { useState, useEffect, useCallback } from "react";
import Image from "next/image";
import ButtonLarge from "@/component/button/ButtonLarge";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faInfo } from "@fortawesome/free-solid-svg-icons";

const INITIAL_SECONDS = 20 * 60 + 20; // 00:45:20

function formatTime(totalSeconds: number) {
  const h = Math.floor(totalSeconds / 3600);
  const m = Math.floor((totalSeconds % 3600) / 60);
  const s = totalSeconds % 60;
  const pad = (n: number) => String(n).padStart(2, "0");
  return `${pad(h)}:${pad(m)}:${pad(s)}`;
}

export default function MissionToFinal() {
  const [checkList, setCheckList] = useState([
    { id: 1, title: "Find the sound cipher", status: true },
    { id: 2, title: "Unlock the greenhouse gate", status: true },
    { id: 3, title: "Decode the fountain inscription", status: false },
    { id: 4, title: "Reach the clock tower", status: false },
    { id: 5, title: "Retrieve the final key", status: false },
  ]);

  const [secondsLeft, setSecondsLeft] = useState(INITIAL_SECONDS);
  const [isRunning, setIsRunning] = useState(true);

  useEffect(() => {
    if (!isRunning) return;

    if (secondsLeft <= 0) {
      setIsRunning(false);
      return;
    }

    const intervalId = setInterval(() => {
      setSecondsLeft((prev) => {
        if (prev <= 1) {
          clearInterval(intervalId);
          setIsRunning(false);
          return 0;
        }
        return prev - 1;
      });
    }, 1000);

    return () => clearInterval(intervalId);
  }, [isRunning, secondsLeft <= 0]);

  const toggleItem = useCallback((id: number) => {
    setCheckList((prev) =>
      prev.map((item) =>
        item.id === id ? { ...item, status: !item.status } : item,
      ),
    );
  }, []);
  return (
    <div className="px-4 h-screen overflow-y-auto  bg-slate-400 py-6">
      <h1 className="text-white text-lgs">Welcome to</h1>
      <Image
        src="/img/games/mission-to-final.png"
        alt="Mission To Final"
        width={400}
        height={100}
      />
      <div className="bg-white rounded-md flex flex-col gap-1 items-center py-4 font-medium text-lg my-4">
        <p>MISSION</p>
        <p>TIMER</p>
        <p className={secondsLeft <= 0 ? "text-red-500" : ""}>
          {formatTime(secondsLeft)}
        </p>
        <p className="text-sm text-gray-500 font-thin">
          {secondsLeft <= 0 ? "TIME'S UP" : "REMAINING"}
        </p>
      </div>

      <div className="bg-white rounded-md flex flex-col gap-1 p-6 my-4">
        <h2 className="text-md">YOUR CHECKLIST</h2>
        <ul className="flex flex-col gap-2 text-sm my-2">
          {checkList.map((list, index) => (
            <li key={index} className="flex gap-2">
              <input
                type="checkbox"
                checked={list.status}
                onChange={() => toggleItem(list.id)}
              />
              <p className={list.status ? "line-through text-gray-400" : ""}>
                {list.title}
              </p>
            </li>
          ))}
        </ul>
      </div>

      <div className="bg-white rounded-md flex flex-col gap-1 my-4">
        <div className="border-b border-gray-200 p-6 flex justify-between">
          <div className="flex gap-2 items-center">
            <p className="h-10 w-10 rounded-full border border-gray-500"></p>
            <p className="text-gray-600 text-sm">Mission Guide</p>
          </div>
          <FontAwesomeIcon icon={faInfo}/>
        </div>
        <div className="p-6">
          <p className="text-gray-600 text-sm">
            "I found something interesting nearby... the fountain isn't just
            decorative. Look at where the shadows fall at noon."
          </p>
          <p className="text-xs text-gray-400 mb-4">- 3 min ago</p>
          <ButtonLarge text="Open Conversation" link='/dashboard/games'/>
        </div>
      </div>
    </div>
  );
}
