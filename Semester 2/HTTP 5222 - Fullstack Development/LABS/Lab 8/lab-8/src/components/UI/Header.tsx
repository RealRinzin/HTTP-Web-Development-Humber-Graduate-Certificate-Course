
export default function Header() {
  return (
    <header className="bg-slate-900 text-white py-3 items-center">
        <nav className="flex justify-between max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <h1 className="text-2xl font-bold">Site Name</h1>
            <ul className="flex gap-4 font-medium text-gray-100 ">
                <li>Quiz</li>
                <li>Category</li>
                <li>Login</li>
            </ul>
        </nav>
    </header>
  )
}
