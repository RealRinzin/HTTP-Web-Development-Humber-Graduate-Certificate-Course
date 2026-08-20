
// import './App.css'
import Header from './components/Header'
import Footer from './components/Footer/footer'
import Movie from './components/Movies'
import { useState } from 'react'
function App() {
  const [movies, setMovies] = useState(
    [
      {
        "Title": "TN 2026",
        "Year": "2026",
        "imdbID": "tt38489752",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BNTk2NjNmYjUtMGEzNS00ZDFiLWE5NmItMDAzZDAyNDYwYTA1XkEyXkFqcGc@._V1_QL75_UX380_CR0,4,380,562_.jpg"
      },
      {
        "Title": "2026 Oscar Nominated Short Films: Documentary",
        "Year": "2026",
        "imdbID": "tt39396590",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BYzBlNWRkMzMtZDQ3ZC00Mjg0LTlkN2ItOTU4NWI1ZjY5YzM3XkEyXkFqcGc@._V1_QL75_UY562_CR310,0,380,562_.jpg"
      },
      {
        "Title": "FIFA World Cup 2026: Final Draw",
        "Year": "2025",
        "imdbID": "tt39122876",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BNTA0YjY4YjctZjgwYS00N2Q2LTgwYWQtOWMzNDE3MmY4MjQ2XkEyXkFqcGc@._V1_QL75_UY562_CR381,0,380,562_.jpg"
      },
      {
        "Title": "Las Culturistas Culture Awards 2026",
        "Year": "2026",
        "imdbID": "tt42028933",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BZDZlYjJlYjUtM2YyZS00MDhlLThjNWQtZTBhZWNmNGZmYThiXkEyXkFqcGc@._V1_QL75_UY562_CR1,0,380,562_.jpg"
      },
      {
        "Title": "Sidemen Charity Match 2026 (Sidemen FC VS Youtube Allstars)",
        "Year": "2026",
        "imdbID": "tt41888536",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BNDAyNDVkYjgtMjY2My00NTg0LWE0YjYtNDUzZTZhNmIxOWYxXkEyXkFqcGc@._V1_QL75_UY562_CR36,0,380,562_.jpg"
      },
      {
        "Title": "American Music Awards 2026",
        "Year": "2026",
        "imdbID": "tt39229678",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BM2Q4MTk5ZWMtMDgxMS00ZDNlLWI5ZWItNTVmNzBmNDhlYjU3XkEyXkFqcGc@._V1_QL75_UY562_CR35,0,380,562_.jpg"
      },
      {
        "Title": "2026 Oscar-Nominated Short Films: Live Action",
        "Year": "2026",
        "imdbID": "tt40229374",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BYzZjNzZiMmYtZmY0Zi00MzUzLTgwZGItOTNhMjE3ZDg3NzZiXkEyXkFqcGc@._V1_QL75_UY562_CR309,0,380,562_.jpg"
      },
      {
        "Title": "Dick Clark's New Year's Rockin' Eve with Ryan Seacrest 2026",
        "Year": "2025",
        "imdbID": "tt38870930",
        "Type": "movie",
        "Poster": "https://m.media-amazon.com/images/M/MV5BZWMxMDc2NjAtNWRkZC00ZDRjLWFlZDUtMDkzZDBjYTRmNjJmXkEyXkFqcGc@._V1_SX300.jpg"
      }
    ]
  )
  console.log(movies)
  return (
    <>
      <Header />
      <main className='min-h-screen m-6'>
      <h1 className='font-bold text-2xl'>List of Movies</h1>
      <div className='grid grid-cols-6 gap-10'>
        {
          movies.map((movie, index) => (
            <Movie key={movie.imdbID} movie={movie} />
          ))
        }

      </div>
      </main>
      <Footer />
    </>
  )
}

export default App
