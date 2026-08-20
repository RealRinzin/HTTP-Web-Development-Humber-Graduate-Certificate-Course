import ButtonLarge from "@/component/button/ButtonLarge";
import { faChevronDown } from "@fortawesome/free-solid-svg-icons/faChevronDown";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Image from "next/image";
import React from "react";

export default function CheckoutPage() {
  return (
    <section className="m-4 flex flex-col gap-4">
      <h1>Chechout</h1>
      <div className="bg-yellow-500/50 rounded-lg p-4">
        <div className="flex justify-between">
          <p className="font-medium">Your Game Summary</p>
          <a href="/" className="text-blue-800 underline text-sm">
            Make changes
          </a>
        </div>
        <div className="flex flex-col gap-1 my-2">
          <h2>Where dark things dwell</h2>
          <p className="uppercase text-xs text-stone-500">
            Saturday, 1 August 2026 @ 9:00pm
          </p>
          <p className="uppercase text-xs text-stone-500">1 Adults, 2 Kids</p>
        </div>
      </div>
      <ul className="border text-gray-600 text-sm font-medium border-gray-200 p-4 flex flex-col gap-4 rounded-lg">
        <li className="border-b border-b-gray-200 pb-3 flex justify-between">
          Acknowledgement
          <FontAwesomeIcon icon={faChevronDown} />
        </li>
        <li className="border-b border-b-gray-200 pb-3 flex justify-between">
          Cancellation Policy
          <FontAwesomeIcon icon={faChevronDown} />
        </li>
        <li className="border-b border-b-gray-200 pb-3 flex justify-between">
          Terms & Conditions
          <FontAwesomeIcon icon={faChevronDown} />
        </li>
      </ul>
      {/* Billing */}
      <div className="my-2">
        <h2>Billing information</h2>
        <p className="text-xs">
          Required <span className="text-red-700">*</span>
        </p>
        <div className="flex justify-between my-2 gap-4">
          <label
            htmlFor="first_name"
            className="border-2 flex flex-col border-gray-200 px-4 py-2 rounded-lg "
          >
            <p className="text-gray-500 font-normal text-xs">
              First Name <span className="text-red-700">*</span>
            </p>
            <input
              type="text"
              placeholder="John"
              className="text-sm font-medium "
            />
          </label>
          <label
            htmlFor="first_name"
            className="border-2 flex flex-col border-gray-200 px-4 py-2 rounded-lg "
          >
            <p className="text-gray-500 font-normal text-xs">
              First Name <span className="text-red-700">*</span>
            </p>
            <input
              type="text"
              placeholder="Doe"
              className="text-sm font-medium "
            />
          </label>
        </div>
        <div className="my-2">
          <label
            htmlFor="email"
            className="border-2 flex flex-col border-gray-200 px-4 py-2 rounded-lg "
          >
            <p className="text-gray-500 font-normal text-xs">
              Email Address <span className="text-red-700">*</span>
            </p>
            <input
              type="email"
              placeholder="jhndoe@gmail.com"
              className="text-sm font-medium "
            />
          </label>
        </div>
      </div>
      <div className="flex flex-col gap-2">
        <div className="flex gap-2">
          <input type="checkbox" name="email" defaultChecked={true} />
          <p className="text-xs">
            Keep me updated on more events and news from this event organiser.
          </p>
        </div>
        <div className="flex gap-2">
          <input type="checkbox" name="email" defaultChecked={true} />
          <p className="text-xs">
            Send me emails about the best events happening nearby or online.
          </p>
        </div>
      </div>
      {/*  */}
      <div className="my-2">
        <h2>Order summary</h2>
        <ul className="my-2">
          <li className="flex justify-between text-gray-900 font-thin text-xs">
            <p>Total Ticket price</p>
            <p>4* $9</p>
          </li>
          <li className="flex justify-between text-gray-900 font-thin text-xs">
            <p>Fulfilment and service fee</p>
            <p>$10</p>
          </li>
          <li className="flex justify-between text-gray-900 font-medium text-sm">
            <p>Total price</p>
            <p className="text-green-700 font-bold"> CA$ 102</p>
          </li>
        </ul>
      </div>
      {/*  */}
      <div className="my-2">
        <h2 className="text-lg font-medium py-4">Payment details</h2>
        <div className="flex justify-between rounded-lg border-gray-200 border-2 p-2">
          <div className="basis-1/3 flex flex-col gap-2">
            <p className="font-medium">Card number</p>
            <p className="bg-gray-300 rounded h-4 w-auto"></p>
          </div>
          <p className="basis-1/3 flex justify-end ">
            <Image
              src="/img/icons/master_card.png"
              alt="money"
              width={40}
              height={40}
              className="bg-gray-200 rounded"
            />
          </p>
        </div>
        <div className="flex justify-between rounded-lg border-gray-200 border-2 p-2 my-4">
          <div className="flex flex-col gap-2 w-full">
            <p className="font-medium">Card holder</p>
            <p className="bg-gray-300 rounded h-4 w-50"></p>
          </div>
        </div>

        <div className="my-4 flex gap-4 justify-between">
          <div className="flex flex-col gap-2  rounded-md border-gray-200 border-2 p-2 my-4">
            <p className="font-medium">MM/YY</p>
            <p className="bg-gray-300 rounded h-4 w-50"></p>
          </div>
          <div className="flex flex-col gap-2  rounded-md border-gray-200 border-2 p-2 my-4">
            <p className="font-medium">CVV</p>
            <p className="bg-gray-300 rounded h-4 w-50"></p>
          </div>
        </div>
        <ButtonLarge text="Pay Now" link="/dashboard/checkout/confirmation"/>
      </div>
    </section>
  );
}
