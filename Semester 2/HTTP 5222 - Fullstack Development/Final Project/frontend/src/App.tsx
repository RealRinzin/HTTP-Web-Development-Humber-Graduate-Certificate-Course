import { useFetch } from "../hooks/fetch";
import Job from "../components/card/Job";
function App() {
  const { data: data, loading, error } = useFetch("http://localhost:9002/jobs");
  console.log(data)
  if (loading)
    return <p className="bg-gray-100 px-2 text-xs py-1 rounded">Loading...</p>;
  if (error) return <p className="text-red-700">Error: {error}</p>;

  return (
    <main className="mx-10 w-full md:w-1/4 mx-auto h-full">
      {
        data?.jobs.map((job,index:number)=>(
          <Job key={index} job={job}/>
        ))
      }
    </main>
  );
}

export default App;
