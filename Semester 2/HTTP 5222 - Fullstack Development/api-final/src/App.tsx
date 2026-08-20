import { useEffect, useState } from "react";

import "./App.css";
import useAPI from "./utils/API";
export default function App() {
  const [country, setCountry] = useState(null);

  // const {
  //   data: forex,
  //   loading: forex_loading,
  //   error: forex_error,
  // } = useAPI(
  //   "https://v6.exchangerate-api.com/v6/144f7f43573e8acf4ae9aaa7/latest/CAD",
  //   "",
  // );

  // console.log(forex);
  const {
    data: countries,
    loading: countries_loading,
    error: countries_error,
  } = useAPI(
    "https://api.restcountries.com/countries/v5?limit=100",
    "rc_live_2dc3bdd6f7f44d46838bf8661f149ad5",
  );
  useEffect(() => {
    console.log("asdfads");
  }, []);
  return (
    <main className="max-2xl mx-auto w-1/3 bg-gray-50">
      <div className="flex gap-2 p-6">
        <div className="border-2 border-gray-200 rounded-md">
          <ul className="bg-gray-200 p-2 overflow-auto h-10">
            {countries?.data?.objects.map((country: any, index: number) => (
              <li key={index} className="flex  justify-between my-2">
                {country?.names?.common}  <img src={`${country?.flag?.url_svg}`} alt="" className="h-10 w-10" />
              </li>
            ))}
          </ul>
        </div>
        <div className="border-2 border-gray-200 rounded-md">
          <input type="text" />
        </div>
      </div>
    </main>
  );
}
