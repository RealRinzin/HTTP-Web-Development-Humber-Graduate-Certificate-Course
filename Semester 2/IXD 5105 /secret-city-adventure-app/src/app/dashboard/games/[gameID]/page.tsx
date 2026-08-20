import ButtonLarge from "@/component/button/ButtonLarge";
import Image from "next/image";
import React from "react";

export default function GameDetail() {
  return (
    <>
      <h1 className="font-medium py-2 text-lg">Lost & Found</h1>
      <Image
        src="/img/games/lost_found.png"
        alt="lost_found"
        className="w-full"
        height={100}
        width={200}
      />
      <section style={{ backgroundColor: "#463F35" }} className="p-6">
        <h2 className="text-white text-md">What to expect</h2>
        <p className="text-stone-400 my-4">
          Lost & Found is Canada’s largest immersive open world puzzle
          adventure, where you get to wander freely through The Village at Black
          Creek, choose which characters to follow and which quests to take on.
        </p>
        <h2 className="text-white text-md">Find the hidden treasure</h2>
        <p className="text-stone-400 my-4">
          The villagers of Black Creek need your help! The creek has run dry,
          the mill has been abandoned, and people are leaving town. If you and
          your party can earn the villagers’ trust and locate the hidden
          treasure, Black Creek just might have a chance.
        </p>
        <h2 className="text-white text-md">Choose your adventure</h2>
        <p className="text-stone-400 my-4">
          Do you love puzzles? Or do you prefer a scavenger hunt? Maybe a bit of
          romance? Some ghost busting? Mingle with characters and check out the
          job board to choose which quests fit your fancy. There's something for
          everyone!
        </p>
        <h2 className="text-white text-md">Eat, Drink and be merry</h2>
        <p className="text-stone-400 my-4">
          You'll probably need to take a breather with all the excitement going
          on. The Village Snack Shack and Gift Shop serve pizza, nachos, donuts,
          patties, soft drinks and snacks galore. Take a break whenever you need
          it.
        </p>
      </section>

      <section style={{ backgroundColor: "#3D4A35" }} className="p-6">
        <div className="flex flex-col items-center gap-18 my-10">
          <div className="flex flex-col gap-4">
            <p className="text-gray-50">Make friends with</p>
            <ul className="flex gap-6 items-center">
              <li>
                <Image
                  src="/img/icons/hat.png"
                  width={80}
                  height={10}
                  alt="asfda"
                />
              </li>
              <li className="text-gray-50 text-center">
                <p className="text-3xl font-semibold">11</p>
                <p>Characters</p>
              </li>
            </ul>
          </div>
          <div className="flex flex-col gap-4">
            <p className="text-gray-50">Explore a village with</p>
            <ul className="flex gap-6 items-center">
              <li>
                <Image
                  src="/img/icons/key.png"
                  width={80}
                  height={10}
                  alt="key"
                />
              </li>
              <li className="text-gray-50 text-center">
                <p className="text-3xl font-semibold">43</p>
                <p>Building</p>
              </li>
            </ul>
          </div>
          {/*  */}
          <div className="flex flex-col gap-4 text-gray-50">
            <p>Play at your pace</p>
            <ul className="flex gap-6 items-center">
              <li>
                <Image
                  src="/img/icons/time.png"
                  width={80}
                  height={10}
                  alt="key"
                />
              </li>
              <li className="text-center">
                <p className="text-3xl font-semibold">2-4</p>
                <p>Hours</p>
              </li>
            </ul>
          </div>
          {/*  */}
          <div className="flex flex-col gap-4 text-gray-50">
            <p>Pick & choose from</p>
            <ul className="flex gap-6 items-center">
              <li>
                <Image
                  src="/img/icons/map.png"
                  width={80}
                  height={10}
                  alt="key"
                />
              </li>
              <li className="text-center">
                <p className="text-3xl font-semibold">20</p>
                <p>Quests</p>
              </li>
            </ul>
          </div>
          <div className="flex flex-col gap-4 text-gray-50">
            <p>Go back in time to an</p>
            <ul className="flex gap-6 items-center">
              <li>
                <Image
                  src="/img/icons/windmill.png"
                  width={80}
                  height={10}
                  alt="windmill"
                />
              </li>
              <li className="text-center">
                <p className="text-3xl font-semibold">1800s</p>
                <p>villages</p>
              </li>
            </ul>
          </div>
        </div>
      </section>

      {/*  */}
      <section
        style={{ backgroundColor: "#E2AA57" }}
        className="p-6 font-thin text-sm"
      >
        <h2 className="font-bold text-gray-800 text-lg py-6">The details</h2>
        <p className="font-medium py-4">SCHEDULES</p>
        <p>Running from June – November 2026</p>
        <p>Saturdays & Sundays 11AM – 4PM</p>

        <h2 className="font-medium py-4">TEAMS & MISSIOIN</h2>
        <p>
          Choose your party wisely! The recommended team size is 2–4 players /
          team. Lost & Found is a sprawling adventure, including puzzles,
          scavenger hunts and mini games intended for you to play at your own
          pace and come back for multiple visits.
        </p>
        <h2>Exclusive Group Bookings</h2>
        <p>
          If you have a very large group and would like to organize an exclusive
          private game, please email
          <a href="" className="font-semibold px-2">
            team@secretcityadventures.com.
          </a>
        </p>

        <h2 className="font-medium py-4">Venue information</h2>
        <p className="font-medium my-2">ARRIVAL</p>
        <p>The Village at Black Creek</p>
        <p>1000 Murray Ross Pkwy</p>
        <p>Toronto, ON M3J 2P3</p>
        <p>by Car</p>
        <p>
          Convenient onsite parking is available at $9.30 + HST per car, per
          day.
        </p>
        <p>Via TTC</p>
        <p>
          The closest TTC subway stop is Pioneer Village, an 11 minute walk
          away. Get directions
        </p>
        <h2 className="font-medium py-4">ACCESSIBILITY</h2>
        <p>
          The entrance to The Village at Black Creek is located through the main
          electronic doors of the Visitor’s Centre. Wheelchair accessible
          parking spaces are available in the parking lot and a drop- off circle
          is located in front of the main doors for any drop-off or pick-up
          needs.
        </p>
        <h2 className="font-medium py-4">Children</h2>
        <p>
          Kids are welcome and encouraged to join the fun. This experience has
          something for everyone. Kids 3 and under have free admission.
        </p>
      </section>
      <section
        style={{ backgroundColor: "#DEDDC0" }}
        className="p-6 font-thin text-sm"
      >
        <div className="flex justify-center items-center">
          <Image
            src="/img/video-placeholder.png"
            height={200}
            width={200}
            alt="Video Placeholder"
          />
        </div>
      </section>
      <section
        style={{ backgroundColor: "#F3EAD8" }}
        className="p-6 font-thin text-sm"
      >
        <h2 className="font-medium text-lg">VIP Package</h2>
        <p className="py-2 font-medium">Our VIP package includes</p>
        <ul className="flex flex-col gap-4 list-disc py-2 text-md font-medium text-gray-600">
          <li>Free Parking</li>
          <li>9" Medium Pizza & Pop voucher</li>
          <li>Limited Edition Lost & Found Pin</li>
          <li>Lost & Found Poster</li>
          <li>Secrety City Tote Bag</li>
        </ul>
        <p className="font-medium py-2">Upgrade to VIP for only $ 65</p>
      </section>
      <section
        style={{ backgroundColor: "#3A4A34" }}
        className="p-6 font-thin text-sm text-white"
      >
        <h2 className="font-medium text-lg py-4">
          Food & Drink at the Village
        </h2>
        <p>
          Visitors can purchase snacks, sandwiches, soups, old-fashioned ice
          cream, and drinks at the on-site Gift Shop & Café (Open 11AM to 4PM),
          or pick up casual bites like pizza and nachos at the Pavilion Snack
          Bar (Open 11AM to 3PM). For something lighter, the To Go menu offers
          Summer Fresh Salads, with gluten and dairy free options available.
          Guests are also welcome to bring their own food and drinks in a bag or
          small cooler.
        </p>
        <p className="underline py-4 font-medium">
          The Village Food & Drink Menu
        </p>
        <div className="flex flex-col gap-4 items-center">
          <Image
            src="/img/games/village.png"
            alt="Image"
            width={300}
            height={100}
          />
          <Image
            src="/img/games/emporium.png"
            alt="Image"
            width={300}
            height={100}
          />
          <Image
            src="/img/games/horse.png"
            alt="Image"
            width={300}
            height={100}
          />
          <Image
            src="/img/games/paintbrush.png"
            alt="Image"
            width={300}
            height={100}
          />
        </div>
      </section>
      <section
        style={{ backgroundColor: "#E2AA57" }}
        className="p-6 font-thin text-sm text-white flex flex-col items-center gap-4"
      >
        <p className="text-gray-800">
          A Secret City Adventure, in partnership with....
        </p>
        <Image
          src="/img/games/black_creek_logo.png"
          alt="Image"
          width={150}
          height={100}
        />
      </section>
      <div className="my-4 fixed z-50 w-fit md:w-1/6 bottom-20 mx-10">
        <div className="text-center flex justify-center items-center">
        <button className="rounded-3xl bg-sky-800 text-white w-full py-2 px-10">
          <a href="/dashboard/games/1/books">Get tickets</a>
        </button>
        </div>
      </div>
    </>
  );
}
