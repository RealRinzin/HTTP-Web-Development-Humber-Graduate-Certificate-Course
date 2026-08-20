import ButtonLarge from "@/component/button/ButtonLarge";
import { faCompass } from "@fortawesome/free-regular-svg-icons";
import { faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";

export default function GameBookPage() {
  return (
    <section className="m-4 flex flex-col gap-4">
      <h1 className="font-medium">Where Dark Things Dweel</h1>
      <img
        src="/img/games/dark_things_logo.png"
        alt=""
        height={100}
        width={100}
        className="w-full"
      />
      <p className="text-sm">
        {" "}
        <span className="mr-4 bg-gray-200 h-4 w-4 rounded-full p-1 text-red-700">
          <FontAwesomeIcon icon={faLocationDot} />
        </span>
        1000 Murray Ross Pkwy, North York, Ontario M3J 2P3
      </p>
      <p>Choose your time & date</p>
      <div className="flex gap-4 flex-nowrap w-full">
        <div className="bg-gray-200 p-2 rounded-md text-sm font-light">
          <input
            type="datetime-local"
            id="meeting-time"
            name="meeting-time"
            defaultValue="2018-06-12T19:30"
            min="2018-06-07T00:00"
            max="2018-06-14T00:00"
          />
        </div>
        <div className="bg-gray-200 p-2 rounded-md text-sm font-light">
          <input
            type="datetime-local"
            id="time"
            name="time"
            defaultValue="2018-06-12T19:30"
            min="2018-06-07T00:00"
            max="2018-06-14T00:00"
          />
        </div>
      </div>
      <p className="text-xs text-gray-400 font-light">
        Arrive 15 minutes early for check-in
      </p>

      <div className="flex flex-col">
        <p>Guests</p>
        <div className="grid grid-cols-4 gap-2">
          <div className="flex items-center gap-1 bg-gray-200 border border-gray-400 p-2 rounded-md">
            <input type="text" defaultValue={2} className="w-full rounded" />
            <p className="text-sm font-medium">Adults</p>
          </div>
          <div className="flex items-center gap-1 bg-gray-200 border border-gray-400 p-2 rounded-md">
            <input type="text" defaultValue={4} className="w-full rounded" />
            <p className="text-sm font-medium">Adults</p>
          </div>
          <div className="flex items-center gap-1 bg-gray-200 border border-gray-400 p-2 rounded-md">
            <input type="text" defaultValue={6} className="w-full rounded" />
            <p className="text-sm ont-medium">Adults</p>
          </div>
          <div className="flex items-center gap-1 bg-gray-200 border border-gray-400 p-2 rounded-md">
            {/* <input type="text" defaultValue="" className="w-full rounded"/> */}
            <p className="text-sm font-medium">Custom Mix</p>
          </div>
        </div>
        <p className="text-xs  text-gray-400 font-light my-1">
          We'll show pricing for 2 + kids
        </p>
      </div>
      <div className="flex flex-col">
        <p>Kids Count</p>
        <ul className="flex gap-4 items-center text-sm">
          <li className="rounded-md bg-gray-200 w-fit px-6  py-1 border border-gray-400 text-gray-600">
            0
          </li>
          <li className="rounded-md bg-gray-200 w-fit px-6 py-1 border border-gray-400 text-gray-600">
            1
          </li>
          <li className="rounded-md bg-gray-200 w-fit px-6 py-1 border border-gray-400 text-gray-600">
            2
          </li>
          <li className="rounded-md bg-gray-200 w-fit px-6 py-1 border border-gray-400 text-gray-600">
            3+
          </li>
        </ul>
        <p className="text-xs  text-gray-400 font-light my-1">Ages 3 -12</p>
      </div>
      {/*  */}
      <div className="my-4">
        <h2>Venue & entry info</h2>
        <p className="text-xs  text-gray-400 font-light my-1">
          Everything you need before you go
        </p>
        <div className="my-4 flex flex-col gap-4">
          <div className="flex items-center gap-4 text-sm border-b border-b-gray-200 pb-2">
            <div className="h-10 w-10 bg-gray-200 rounded-full"></div>
            <div className="flex flex-col">
              <h3>Doors open</h3>
              <p className="text-xs  text-gray-400 font-light my-1">
                5 min before the game
              </p>
            </div>
          </div>
          <div className="flex items-center gap-4 text-sm border-b border-b-gray-200 pb-2">
            <div className="h-10 w-10 bg-gray-200 rounded-full"></div>
            <div className="flex flex-col">
              <h3>ID policy</h3>
              <p className="text-xs  text-gray-400 font-light my-1">
                Photo ID required for some ticket types
              </p>
            </div>
          </div>
          <div className="flex items-center gap-4 text-sm border-b border-b-gray-200 pb-2">
            <div className="h-10 w-10 bg-gray-200 rounded-full"></div>
            <div className="flex flex-col">
              <h3>Assistive Listening</h3>
              <p className="text-xs  text-gray-400 font-light my-1">
                Available at the box office
              </p>
            </div>
          </div>
          <div className="flex items-center gap-4 text-sm border-b border-b-gray-200 pb-2">
            <div className="h-10 w-10 bg-gray-200 rounded-full"></div>
            <div className="flex justify-between">
              <div className="flex flex-col">
                <h3>Parking</h3>
                <p className="text-xs  text-gray-400 font-light my-1">
                  Limited street parking Garage nearby
                </p>
              </div>
              <p>Discounted Validation (select days)</p>
            </div>
          </div>
        </div>
      </div>
      {/*  */}
      <h2 className="text-lg text-gray-800">Pricing Summary</h2>
      <div className="flex justify-between">
        <p className="text-xs text-gray-400/80">
          Here, the total summary of your tickets
        </p>
        <button className="border border-gray-500 text-xs text-gray-600 rounded px-1">
          Make Changes
        </button>
      </div>
      <div className="flex gap-4 justify-between">
        <div className="border border-gray-200 p-4 rounded-2xl">
          <p className="text-sm text-gray-400">Adults</p>
          <p className="text-2xl py-2">2 * $28 = $56</p>
        </div>
        <div className="border border-gray-200 p-4 rounded-2xl">
          <p className="text-sm text-gray-400">Adults</p>
          <p className="text-2xl py-2">2 * $18 = $36</p>
        </div>
      </div>
      <div className="flex justify-between border border-gray-300 p-4 rounded-md">
        <p className="font-medium text-gray-400">Total summary of Tickets</p>
        <p className="text-lg"> $92</p>
      </div>
      <ButtonLarge text="Process to Checkout - $92" link="/dashboard/checkout"/>
    </section>
  );
}
