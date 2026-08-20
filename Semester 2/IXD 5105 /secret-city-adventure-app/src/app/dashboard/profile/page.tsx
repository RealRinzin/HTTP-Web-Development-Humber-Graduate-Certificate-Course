import ButtonLarge from "@/component/button/ButtonLarge";
import Progress from "@/component/progress/Progress";
import { faStar, faUser } from "@fortawesome/free-solid-svg-icons";
import { faPlus } from "@fortawesome/free-solid-svg-icons/faPlus";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Image from "next/image";
import React from "react";

export default function ProfilePage() {
  return (
    <main className="m-4">
      <div className="py-4">
        <h1 className="text-lg font-bold">Hello, Anna</h1>
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
      <h2 className="font-medium">Previous Experience</h2>
      <div className="flex flex-col gap-2 my-2">
        <div className="flex gap-4 border border-gray-200 p-4 rounded-lg">
          <Image
            src="/img/login-back.png"
            alt="profile"
            height={80}
            width={60}
            className="rounded-md"
          />
          <ul>
            <li className="font-medium">Where dark things dewll</li>
            <li className="text-xs text-gray-400">Jun 14, 2026</li>
            <li className="text-xs text-gray-400 flex">
              <FontAwesomeIcon icon={faStar}  className="text-yellow-500"/>
              <FontAwesomeIcon icon={faStar}  className="text-yellow-500"/>
              <FontAwesomeIcon icon={faStar} />
            </li>
          </ul>
        </div>
        <div className="flex gap-4 border border-gray-200 p-4 rounded-lg">
          <Image
            src="/img/signup.png"
            alt="profile"
            height={80}
            width={60}
            className="rounded-md"
          />
          <ul>
            <li className="font-medium">Station M</li>
            <li className="text-xs text-gray-400">Jun 14, 2026</li>
            <li className="text-xs text-gray-500 flex">
              <FontAwesomeIcon icon={faStar} className="text-yellow-500" />
              <FontAwesomeIcon icon={faStar} />
              <FontAwesomeIcon icon={faStar} />
            </li>
          </ul>
        </div>
        <section className="my-4">
          <h2 className="font-medium"> Your Friends</h2>
          <div className="flex gap-4 my-4">
            <div className="bg-gray-200 text-4xl p-4 rounded-full text-gray-400">
              <FontAwesomeIcon icon={faUser} />
            </div>
            <div className="bg-gray-200 text-4xl p-4 rounded-full text-gray-400">
              <FontAwesomeIcon icon={faUser} />
            </div>
            <div className="bg-gray-200 text-4xl p-4 rounded-full text-gray-400">
              <FontAwesomeIcon icon={faUser} />
            </div>
          </div>
          <div className="flex gap-4 my-4">
            <div className="bg-gray-200 text-4xl p-4 rounded-full text-gray-400">
              <FontAwesomeIcon icon={faUser} />
            </div>
            <div className="bg-gray-200 text-4xl p-4 rounded-full text-gray-600">
              <FontAwesomeIcon icon={faPlus} />
            </div>
          </div>
        </section>
      </div>
    </main>
  );
}
