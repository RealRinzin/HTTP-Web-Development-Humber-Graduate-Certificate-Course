
export default function Header(){
    return(
        <header className="flex justify-between px-20 py-5 bg-blue-500 text-white">
            <h1>My Movie List</h1>
            <nav>
                <ul className="flex flex-row gap-4 font-semibold">
                    <li><a href="/">Home</a></li>
                    <li><a href="/">Latest</a></li>
                    <li><a href="/">Movies</a></li>
                    <li><a href="/">TV</a></li>
                    <li><a href="/">Logout</a></li>
                </ul>
            </nav>
        </header>
    )
}