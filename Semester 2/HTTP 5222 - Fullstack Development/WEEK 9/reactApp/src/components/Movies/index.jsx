export default function Movie({movie}){
    return(
        <>
        <div className="shadow border rounded-lg my-4">
            <div><img src={movie.Poster}/></div>
            <div className="p-2">
                <h1 className="font-bold text-lg text-gray-700 my-1">{movie.Title}</h1>
                <p className="font-semibold text-gray-500">{movie.Year}</p>
            </div>
        </div>
        </>
    )
}