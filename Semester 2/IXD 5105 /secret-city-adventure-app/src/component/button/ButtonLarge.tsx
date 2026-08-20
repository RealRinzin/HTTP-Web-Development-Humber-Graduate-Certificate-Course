import React from "react";

export default function ButtonLarge({ text, link }: any) {
  return (
    <button className="rounded-3xl bg-sky-800 text-white w-full py-1">
      <a href={link}>{text}</a>
    </button>
  );
}
