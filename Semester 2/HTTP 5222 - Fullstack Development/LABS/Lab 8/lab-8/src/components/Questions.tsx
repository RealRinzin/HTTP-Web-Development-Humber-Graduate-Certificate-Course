import { useEffect, useState } from "react";

export default function Questions() {
  const [category, setCategory] = useState(null);
  const [question, setQuestion] = useState(null);
  const [answer, setAnswer] = useState(null);
  const [revealed, setRevealed] = useState(false);
  const [type, setType] = useState(null);
  const [options, setOptions] = useState([]);

  // Questions
  async function getQuestion() {
    try {
      const res = await fetch("https://opentdb.com/api.php?amount=1");
      if (!res.ok) return console.log(res.status);
      const data = await res.json();
      // Set the data
      console.log(data.results[0]);
      setCategory(data.results[0]?.category);
      setQuestion(data.results[0]?.question);
      setAnswer(data.results[0]?.correct_answer);
      setType(data.results[0]?.type);
      setOptions(data?.results[0]?.incorrect_answers);
    } catch (error) {
      console.log(error);
    }
  }
  // Mount the load state
  useEffect(() => {
    getQuestion();
  }, []);
  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 my-10">
      <div className="flex flex-col gap-4">
        <h1 className="font-bold text-xl ">Welcome to Trivai</h1>
        <p className="text-xs text-gray-400">Here's your random question.</p>
        <div className="flex justify-between">
          {type === "multiple" ? (
            <div>
              <p className="py-1 font-medium text-sm">Options</p>
              <ul className="flex gap-4">
                {options.map((option, index) => {
                  return (
                    <li
                      className="bg-blue-600 text-sm rounded-md px-2 py-1 text-white"
                      key={index}
                    >
                      {option}
                    </li>
                  );
                })}
                <li className="bg-blue-600 text-sm rounded-md px-2 py-1 text-white">
                  {" "}
                  {answer}
                </li>
              </ul>
            </div>
          ) : (
            <p className="font-bold text-sm">True or False:</p>
          )}
          <button
            className="rounded-md text-sm px-2 py-1 bg-slate-700 text-white h-fit"
            onClick={getQuestion}
          >
            Refresh New Question
          </button>
        </div>
      </div>
      <div className="flex flex-col gap-4 items-start rounded-md bg-gray-100 py-4 px-4 my-2">
        <p className="text-gray-500 text-sm">{category}</p>
        <h2 className="font-medium">{question}</h2>
        {revealed && <p className="text-green-600 font-medium">{answer}</p>}
        <button
          type="button"
          className="rounded-md text-sm bg-slate-900 text-white px-2 py-1"
          onClick={() => setRevealed((prev) => !prev)}
        >
          Reveal answer
        </button>
      </div>
    </div>
  );
}
