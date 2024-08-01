import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)
  useEffect(() => {
    fetch('http://localhost:5178/login?useCookies=true', {
      credentials: 'include',
      headers: {
     "Content-Type": "application/json",
   }, method: 'POST', body: JSON.stringify({email: 'l.flahive93@gmail.com', password: 'Pass123$'})}).then((r) => console.log(r));
  }, [count])

 


 fetch('http://localhost:5178/api/test', { credentials: 'include'}).then((r) => console.log(r)).catch((e) => console.log(e));

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
