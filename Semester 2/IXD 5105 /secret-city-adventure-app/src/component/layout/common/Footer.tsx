"use client";
import Link from "next/link";
import { usePathname } from "next/navigation";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCompass,
  faHouse,
  faUser,
  IconDefinition,
} from "@fortawesome/free-regular-svg-icons";
import { faPuzzlePiece } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";

export default function Footer() {
  const pathname = usePathname();
  const iconMap: Record<string, IconDefinition> = {
    faHouse: faHouse,
    faCompass: faCompass,
    faPuzzlePiece: faPuzzlePiece,
    faUser: faUser,
  };
  const [menus, setMenus] = useState([
    { name: "Home", path: "/dashboard", icon: "faHouse" },
    { name: "Mission", path: "/dashboard/mission", icon: "faCompass" },
    { name: "Puzzles", path: "/dashboard/puzzles", icon: "faPuzzlePiece" },
    { name: "Profile", path: "/dashboard/profile", icon: "faUser" },
  ]);
  // Check the path match
  const isActive = (path: string) => path === "/dashboard" ? pathname === "/dashboard" : pathname.startsWith(path);
  return (
    <footer className="bg-gray-700">
      <ul className="flex justify-around  bg-gray-50 text-sm py-4 rounded-b-2xl ">
        {menus.map((menu, index) => (
          <li
            className={`${isActive(menu.path) ? "text-sky-950 border-t-4 border-sky-950" : " text-gray-400 "} pt-2`}
            key={index}
          >
            <Link
              href={menu.path}
              className="flex flex-col gap-2 justify-center  items-center"
            >
              <FontAwesomeIcon icon={iconMap[menu.icon]} />
              <span className="font-medium">{menu.name}</span>
            </Link>
          </li>
        ))}
 
      </ul>
    </footer>
  );
}
