
'use client';
import { useToggle } from "@/utils/toggle";
import { faGear} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default function Nagivation() {
  const { isOn: isOpen, toggle } = useToggle(false);

  return (
    <header className="bg-gray-700">
      <nav className="bg-gray-200 p-4 rounded-t-2xl">
        <ul className="flex justify-end">
          <li className="text-md cursor-pointer" onClick={toggle}>
                <FontAwesomeIcon icon={faGear} className="text-gray-800 text-2xl"  />
          </li>
        </ul>
        {isOpen && (
          <ul className="flex flex-col gap-4 text-center">
            <li>
              <a href="/dashboard/profile">Personal Info</a>
            </li>
            <li>
              <a href="/dashboard">Booking History</a>
            </li>
            <li>
              <a href="/dashboard">Privacy & Data</a>
            </li>
            <li>
              <a href="/dashboard">Help & FAQ</a>
            </li>
            <li>
              <a href="/dashboard">Notifications</a>
            </li>
            <li>
              <a href="/login">Sign Out</a>
            </li>
          </ul>
        )}
      </nav>
    </header>
  );
}
