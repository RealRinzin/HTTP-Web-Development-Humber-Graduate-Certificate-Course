import { StrictMode, useState } from 'react'
import { createRoot } from 'react-dom/client'
import { ThemeContext } from './context/Context.tsx'
import App from './App.tsx';

const [themeMode,setThemeMode] = useState("red");
createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ThemeContext.Provider value={{themeMode,setThemeMode}}>
    <App />
    </ThemeContext.Provider>
  </StrictMode>
)
