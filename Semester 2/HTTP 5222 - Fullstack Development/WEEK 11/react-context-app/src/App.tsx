
import { useContext, useReducer } from 'react';
import { ThemeContext } from './context/Context';
import toggleReducer from './reducer/toggleReducer';


function App() {
  const theme = useContext(ThemeContext);
  const [state,dispatch] = useReducer (toggleReducer,{status:false})
  return (
    <>
    {/* <button onClick={()=>}>Click</button> */}
    <p >{theme} </p>
    </>
  )
}

export default App
